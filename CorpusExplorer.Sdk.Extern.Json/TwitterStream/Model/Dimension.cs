#region

using Newtonsoft.Json;

#endregion

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStream.Model
{
  public class Dimension
  {
    [JsonProperty("h")]
    public int H { get; set; }

    [JsonProperty("resize")]
    public string Resize { get; set; }

    [JsonProperty("w")]
    public int W { get; set; }
  }
}