#region

using Newtonsoft.Json;

#endregion

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStream.Model
{
  public class Sizes
  {
    [JsonProperty("large")]
    public Dimension LargeSize { get; set; }

    [JsonProperty("medium")]
    public Dimension MediumSize { get; set; }

    [JsonProperty("small")]
    public Dimension SmallSize { get; set; }

    [JsonProperty("thumb")]
    public Dimension ThumbSize { get; set; }
  }
}