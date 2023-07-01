using Bcs.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Utils.Drm
{
  public class DrmDb : IDisposable
  {
    private static int _minSec = 500;
    private static int _maxSec = 10000;
    private static SHA512 _SHA512 = SHA512.Create();

    private string _token;

    private string Salt { get; set; }
    private string Hash500 { get; set; }
    private Dictionary<string, string> Users { get; set; }

    private DrmDb() { }

    public static void Create(string token, Dictionary<string, string> userPasswordCombinations, string path)
    {
      var db = Create(token);
      foreach (var x in userPasswordCombinations)
        db.UserAdd(x.Key, x.Value);
      db.Save(path);
    }

    public static DrmDb Create(string token)
    {
      byte[] saltBytes = new byte[64];
      using (var rng = new RNGCryptoServiceProvider())
      {
        rng.GetBytes(saltBytes);
      }

      var salt = Convert.ToBase64String(saltBytes);
      var hash500 = GetHash(token + salt, _minSec);

      return new DrmDb()
      {
        Salt = salt,
        Hash500 = hash500,
        Users = new Dictionary<string, string>(),
        _token = token
      };
    }

    private static string GetHash(string data, int rounds)
    {
      var res = string.Empty;
      for (int i = 0; i < rounds; i++)
        res = Convert.ToBase64String(_SHA512.ComputeHash(Encoding.UTF8.GetBytes(i % 2 == 0 ? res + data : data + res)));
      return res;
    }

    public static DrmDb Load(string path, string token)
    {
      try
      {
        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        using (var reader = new StreamReader(fs))
        {
          var salt = reader.ReadLine();
          var hash500 = reader.ReadLine();

          if (hash500 != GetHash(token + salt, _minSec))
            throw new Exception("Wrong password");

          var db = new DrmDb()
          {
            Salt = salt,
            Hash500 = hash500,
            Users = new Dictionary<string, string>(),
            _token = token
          };

          while (!reader.EndOfStream)
          {
            var line = reader.ReadLine();
            var split = line.Split(':');
            if (split.Length != 2)
              continue;

            db.Users.Add(split[0], split[1]);
          }

          return db;
        }
      }
      catch
      {
        return null;
      }
    }

    public void Save(string path)
    {
      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
      using (var writer = new StreamWriter(fs))
      {
        writer.WriteLine(Salt);
        writer.WriteLine(Hash500);

        foreach (var user in Users)
          writer.WriteLine($"{user.Key}:{user.Value}");
      }
    }

    public void UserAdd(string user, string password)
    {
      if(string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(password))
        return;

      user = user.Trim();
      password = password.Trim();

      var uHash = GetHash(user + Salt, user.Length + _minSec);
      var ePsw = CryptoHelper.UseRijndael(KeyGenerator.GenerateRijndael(GetHash(password + Salt + user, _maxSec)).CreateEncryptor(), Encoding.UTF8.GetBytes(_token));

      if (Users.ContainsKey(uHash))
        Users[uHash] = Convert.ToBase64String(ePsw);
      else
        Users.Add(uHash, Convert.ToBase64String(ePsw));
    }

    public bool UserExists(string user) => Users.ContainsKey(GetHash(user + Salt, user.Length + _minSec));

    public void UserRemove(string user)
    {
      var uHash = GetHash(user + Salt, user.Length + _minSec);
      if (Users.ContainsKey(uHash))
        Users.Remove(uHash);
    }

    public static string UserValidate(string path, string user, string password)
    {
      try
      {
        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        using (var reader = new StreamReader(fs))
        {
          var salt = reader.ReadLine();

          var uHash = $"{GetHash(user + salt, user.Length + _minSec)}:";
          while (!reader.EndOfStream)
          {
            var line = reader.ReadLine();
            if (!line.StartsWith(uHash))
              continue;

            line = line.Substring(uHash.Length);

            return Encoding.UTF8.GetString(CryptoHelper.UseRijndael(KeyGenerator.GenerateRijndael(GetHash(password + salt + user, _maxSec)).CreateDecryptor(), Convert.FromBase64String(line)));
          }
        }

        return string.Empty;
      }
      catch
      {
        return string.Empty;
      }
    }

    public void Dispose()
    {
      _SHA512.Dispose();
    }
  }
}
