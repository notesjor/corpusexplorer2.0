using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Model
{
  public class Coordinates
  {
    [JsonProperty("IsLocationAvailable")] public bool IsLocationAvailable { get; set; }

    [JsonProperty("Latitude")] public double Latitude { get; set; }

    [JsonProperty("Longitude")] public double Longitude { get; set; }

    [JsonProperty("Type")] public object Type { get; set; }
  }
}