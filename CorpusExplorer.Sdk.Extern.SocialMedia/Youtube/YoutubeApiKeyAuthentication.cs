using System.Collections.Generic;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Youtube
{
  public class YoutubeApiKeyAuthentication : AbstractSimpleAuthentication
  {
    public override string ProviderName => "YouTube via API-Key";

    public override Dictionary<string, string> Settings { get; set; }
      = new Dictionary<string, string>
      {
        {"ApplicationName", "CorpusExplorer"},
        {"ApiKey", ""}
      };

    protected override object OpenConnection()
    {
      return new YouTubeService(new BaseClientService.Initializer
      {
        ApplicationName = Settings["ApplicationName"],
        ApiKey = Settings["ApiKey"]
      });
    }
  }
}