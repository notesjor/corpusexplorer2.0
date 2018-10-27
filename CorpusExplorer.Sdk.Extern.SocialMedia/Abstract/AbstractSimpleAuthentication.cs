using System.Collections.Generic;
using System.IO;
using Bcs.IO;
using Bcs.Security;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.SocialMedia.Helper;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Abstract
{
  public abstract class AbstractSimpleAuthentication : AbstractAuthentication
  {
    public abstract string ProviderName { get; }
    public abstract Dictionary<string, string> Settings { get; set; }

    private string SettingsPath => Path.Combine(Configuration.MyDataSources, $"{ProviderName}.api");

    protected override bool LoadData()
    {
      try
      {
        var text = FileIO.ReadText(SettingsPath);
        Settings =
          Serializer.DeserializeFromBase64String<Dictionary<string, string>>
            (CryptoHelper.UseRijndael(KeyGenerator
                                     .GenerateRijndael(ProviderName)
                                     .CreateDecryptor(),
                                      text));
        return true;
      }
      catch
      {
        return false;
      }
    }

    protected override bool SaveData()
    {
      try
      {
        var text = Serializer.SerializeToBase64String(Settings);
        FileIO.Write(SettingsPath,
                     CryptoHelper.UseRijndael(KeyGenerator.GenerateRijndael(ProviderName).CreateEncryptor(),
                                              text));
        return true;
      }
      catch
      {
        return false;
      }
    }

    protected override bool RequestData()
    {
      Settings = GlobalSocialMediaConfiguration.AuthenticationForm.RequestData(Settings);
      return Settings != null;
    }
  }
}