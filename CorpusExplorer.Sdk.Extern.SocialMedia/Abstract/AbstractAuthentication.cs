using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bcs.IO;
using Bcs.Security;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.SocialMedia.Helper;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Abstract
{
  public abstract class AbstractAuthentication
  {
    public abstract string ProviderName { get; }
    public abstract Dictionary<string, string> Settings { get; set; }

    private string SettingsPath => Path.Combine(Configuration.MyDataSources, $"{ProviderName}.api");

    public abstract object OpenConnection();

    public void SettingsLoad()
    {
      try
      {
        var text = FileIO.ReadText(SettingsPath);
        var data =
          Serializer.DeserializeFromBase64String<Dictionary<string, string>>
            (CryptoHelper.UseRijndael(KeyGenerator
                                     .GenerateRijndael(ProviderName)
                                     .CreateDecryptor(),
                                      text));

        var keys = Settings.Keys.ToArray();
        foreach (var key in keys)
        {
          if (data.ContainsKey(key))
            Settings[key] = data[key];
        }
      }
      catch
      {
        // ignore
      }
    }

    public void SettingsSave()
    {
      try
      {
        var text = Serializer.SerializeToBase64String(Settings);
        FileIO.Write(SettingsPath,
                     CryptoHelper.UseRijndael(KeyGenerator.GenerateRijndael(ProviderName).CreateEncryptor(),
                                              text));
      }
      catch
      {
        // ignore
      }
    }
  }
}