using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Model
{
  public class UrlEntity
  {
    [JsonProperty("DisplayUrl")] public string DisplayUrl { get; set; }

    [JsonProperty("End")] public ulong End { get; set; }

    [JsonProperty("ExpandedUrl")] public string ExpandedUrl { get; set; }

    [JsonProperty("Start")] public ulong Start { get; set; }

    [JsonProperty("Url")] public string Url { get; set; }
  }
}