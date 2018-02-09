#region

using System.IO;
using System.Security.Cryptography;
using System.Text;

#endregion

namespace Bcs.Security
{
  /// <summary>
  ///   BCS.CryptoX Helper-Class zum einfachen Erstellen von A/Symetrischen
  ///   Schlüsseln
  /// </summary>
  // ReSharper disable once UnusedMember.Global
  public static class KeyGenerator
  {
    /// <summary>
    ///   Generate a new Rijndael (RandomGeneration)
    /// </summary>
    /// <returns>
    ///   Rijndael
    /// </returns>
    public static RijndaelManaged GenerateRijndael()
    {
      var rijn = new RijndaelManaged();
      rijn.GenerateIV();
      rijn.GenerateKey();
      return rijn;
    }

    /// <summary>
    ///   Generate a new Rijndael (GeneratFromPassword)
    /// </summary>
    /// <param name="password">The password.</param>
    /// <returns>
    ///   Rijndael
    /// </returns>
    public static RijndaelManaged GenerateRijndael(string password)
    {
      byte[] hash;
      var res = new RijndaelManaged();
      using (var sha = SHA512.Create())
      {
        hash = sha.ComputeHash(Encoding.ASCII.GetBytes(password));
      }

      var buffer = new byte[32];
      for (var i = 0; i < 32; i++)
        buffer[i] = hash[i];

      res.Key = buffer;
      buffer = new byte[16];
      for (var i = 32; i < 48; i++)
        buffer[i - 32] = hash[i];

      res.IV = buffer;
      return res;
    }

    /// <summary>
    ///   Generate a RSA-Key and save it
    /// </summary>
    /// <param name="fileName">
    ///   (filename + *.pri = PrivateKey / filename + *.pub = PublicKey)
    /// </param>
    public static void GenerateRsa(string fileName)
    {
      GenerateRsa($"{fileName}.pri", $"{fileName}.pub");
    }

    /// <summary>
    ///   Generate a RSA-KEy and sav it
    /// </summary>
    /// <param name="privateKeyFile">Filename of privateKey</param>
    /// <param name="publicKeyFile">Filename of publicKey</param>
    public static void GenerateRsa(string privateKeyFile, string publicKeyFile)
    {
      var prov = new RSACryptoServiceProvider();
      using (var stw = new StreamWriter(privateKeyFile))
      {
        stw.Write(prov.ToXmlString(true));
      }

      using (var stw = new StreamWriter(publicKeyFile))
      {
        stw.Write(prov.ToXmlString(false));
      }
    }
  }
}