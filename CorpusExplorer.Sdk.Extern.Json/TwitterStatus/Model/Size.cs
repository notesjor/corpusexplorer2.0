using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Model
{
  public class Size
  {
    [JsonProperty("Height")] public ulong Height { get; set; }

    [JsonProperty("Resize")] public string Resize { get; set; }

    [JsonProperty("Type")] public string Type { get; set; }

    [JsonProperty("Width")] public ulong Width { get; set; }
  }
}