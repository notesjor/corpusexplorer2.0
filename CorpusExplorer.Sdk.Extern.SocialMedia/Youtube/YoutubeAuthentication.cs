using System.Collections.Generic;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Youtube
{
  public class YouTubeAuthentication : AbstractAuthentication
  {
    public override string ProviderName => "YouTube via API-Key";

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
        if (string.IsNullOrWhiteSpace(Settings["ApiKey"]))
          return null;

        return new YouTubeService(new BaseClientService.Initializer
        {
          ApplicationName = Settings["ApplicationName"]?.Trim(),
          ApiKey = Settings["ApiKey"]?.Trim(), 
        });
      }
      catch
      {
        return null;
      }
    }
  }
}