#region

using Newtonsoft.Json;

#endregion

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStream.Model
{
  public class Geo
  {
    [JsonProperty("coordinates")] public double[] Coordinates { get; set; }

    [JsonProperty("type")] public string Type { get; set; }
  }
}