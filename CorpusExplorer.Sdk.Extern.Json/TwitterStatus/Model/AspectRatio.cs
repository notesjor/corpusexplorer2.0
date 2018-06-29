using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Model
{
  public class AspectRatio
  {
    [JsonProperty("Height")] public ulong Height { get; set; }

    [JsonProperty("Width")] public ulong Width { get; set; }
  }
}