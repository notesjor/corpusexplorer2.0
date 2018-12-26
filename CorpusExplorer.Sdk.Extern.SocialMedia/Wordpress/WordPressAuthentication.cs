using System.Collections.Generic;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using WordPressPCL;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Wordpress
{
  public class WordPressAuthentication : AbstractAuthentication
  {
    public override object OpenConnection()
    {
      try
      {
        if (string.IsNullOrEmpty(Settings["Url"]))
          return null;

        if (string.IsNullOrEmpty(Settings["Username"]))
          return new WordPressClient($"{Settings["Url"]}/wp-json/".Replace("//wp-json/", "/wp-json/")); // NoAuth

        var res = new WordPressClient($"{Settings["Url"]}/wp-json/".Replace("//wp-json/", "/wp-json/")) { AuthMethod = WordPressPCL.Models.AuthMethod.JWT };
        res.RequestJWToken(Settings["Username"], Settings["Password"]).Wait();
        var valid = res.IsValidJWToken();
        valid.Wait();

        return valid.Result ? res : null;
      }
      catch
      {
        return null;
      }
    }

    public override string ProviderName => "WordPress User-Access";
    public override Dictionary<string, string> Settings { get; set; }
      = new Dictionary<string, string>
      {
        {"Url", ""},
        {"Username", ""},
        {"Password", ""},
      };
  }
}