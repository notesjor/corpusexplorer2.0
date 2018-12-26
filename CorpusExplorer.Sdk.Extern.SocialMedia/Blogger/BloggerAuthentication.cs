using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using Google.Apis.Services;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Blogger
{
  public class BloggerAuthentication : AbstractAuthentication
  {
    public override string ProviderName => "Blogger via API-Key";

    public override Dictionary<string, string> Settings { get; set; }
      = new Dictionary<string, string>
      {
        {"ApplicationName", "CorpusExplorer"},
        {"ApiKey", ""}
      };

    public override object OpenConnection()
    {
      try
      {
        if(string.IsNullOrWhiteSpace(Settings["ApiKey"]))
          return null;

        return new Google.Apis.Blogger.v3.BloggerService(new BaseClientService.Initializer
        {
          ApplicationName = Settings["ApplicationName"]?.Trim(),
          ApiKey = Settings["ApiKey"]?.Trim()
        });
      }
      catch
      {
        return null;
      }
    }
  }
}
