using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Model
{
  public class ExtendedEntities
  {
    [JsonProperty("HashTagEntities")] public object[] HashTagEntities { get; set; }

    [JsonProperty("MediaEntities")] public MediaEntity[] MediaEntities { get; set; }

    [JsonProperty("SymbolEntities")] public object[] SymbolEntities { get; set; }

    [JsonProperty("UrlEntities")] public UrlEntity[] UrlEntities { get; set; }

    [JsonProperty("UserMentionEntities")] public UserMentionEntity[] UserMentionEntities { get; set; }
  }
}