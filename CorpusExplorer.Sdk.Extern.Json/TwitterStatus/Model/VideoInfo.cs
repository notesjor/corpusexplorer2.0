using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Model
{
  public class VideoInfo
  {
    [JsonProperty("AspectRatio")] public AspectRatio AspectRatio { get; set; }

    [JsonProperty("Duration")] public ulong Duration { get; set; }

    [JsonProperty("Variants")] public object Variants { get; set; }
  }
}