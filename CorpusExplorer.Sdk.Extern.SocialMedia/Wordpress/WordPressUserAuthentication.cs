using System.Collections.Generic;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using WordPressPCL;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Wordpress
{
  public class WordPressUserAuthentication : AbstractSimpleAuthentication
  {
    protected override object OpenConnection()
    {
      var res = new WordPressClient($"{Settings["Url"]}/wp-json/".Replace("//", "/")) { AuthMethod = WordPressPCL.Models.AuthMethod.JWT };
      res.RequestJWToken(Settings["Username"], Settings["Password"]).Wait();
      var valid = res.IsValidJWToken();
      valid.Wait();

      return valid.Result ? res : null;
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