using System.Collections.Generic;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Youtube
{
  public class YouTubeAuthentication : AbstractAuthentication
  {
    public override string ProviderName => "YouTube via API-Key";

    public override Dictionary<string, string> Settings { get; set; }
      = new Dictionary<string, string>
      {
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
          ApplicationName = "SSMDL",
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