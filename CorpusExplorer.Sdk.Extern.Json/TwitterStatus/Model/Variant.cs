using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Model
{
  public class Variant
  {
    [JsonProperty("BitRate")] public ulong BitRate { get; set; }

    [JsonProperty("ContentType")] public string ContentType { get; set; }

    [JsonProperty("Url")] public string Url { get; set; }
  }
}