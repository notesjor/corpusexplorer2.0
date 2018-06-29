using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Model
{
  public class MediaEntity
  {
    [JsonProperty("DisplayUrl")] public string DisplayUrl { get; set; }

    [JsonProperty("End")] public ulong End { get; set; }

    [JsonProperty("ExpandedUrl")] public string ExpandedUrl { get; set; }

    [JsonProperty("ID")] public long ID { get; set; }

    [JsonProperty("Indices")] public ulong[] Indices { get; set; }

    [JsonProperty("MediaUrl")] public string MediaUrl { get; set; }

    [JsonProperty("MediaUrlHttps")] public string MediaUrlHttps { get; set; }

    [JsonProperty("Sizes")] public Size[] Sizes { get; set; }

    [JsonProperty("Start")] public ulong Start { get; set; }

    [JsonProperty("Type")] public string Type { get; set; }

    [JsonProperty("Url")] public string Url { get; set; }

    [JsonProperty("VideoInfo")] public VideoInfo VideoInfo { get; set; }
  }
}