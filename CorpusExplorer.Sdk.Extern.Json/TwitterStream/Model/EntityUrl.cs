#region

using Newtonsoft.Json;

#endregion

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStream.Model
{
  public class EntityUrl
  {
    [JsonProperty("display_url")] public string DisplayUrl { get; set; }

    [JsonProperty("expanded_url")] public string ExpandedUrl { get; set; }

    [JsonProperty("indices")] public int[] Indices { get; set; }

    [JsonProperty("url")] public string ShortUrl { get; set; }
  }
}