using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using Google.Apis.Services;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Blogger
{
  public class BloggerApiKeyAuthentication : AbstractSimpleAuthentication
  {
    public override string ProviderName => "Blogger via API-Key";

    public override Dictionary<string, string> Settings { get; set; }
      = new Dictionary<string, string>
      {
        {"ApplicationName", "CorpusExplorer"},
        {"ApiKey", ""}
      };

    protected override object OpenConnection()
    {
      return new Google.Apis.Blogger.v3.BloggerService(new BaseClientService.Initializer
      {
        ApplicationName = Settings["ApplicationName"],
        ApiKey = Settings["ApiKey"]
      });
    }
  }
}
