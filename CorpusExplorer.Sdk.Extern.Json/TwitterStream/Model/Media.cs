#region

using Newtonsoft.Json;

#endregion

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStream.Model
{
  public class Media
  {
    [JsonProperty("display_url")]
    public string DisplayUrl { get; set; }

    [JsonProperty("expanded_url")]
    public string ExpandedUrl { get; set; }

    [JsonProperty("id")]
    public ulong Id { get; set; }

    public string IdStr { get { return Id.ToString(); } }

    [JsonProperty("indices")]
    public int[] Indices { get; set; }

    [JsonProperty("media_url")]
    public string MediaUrl { get; set; }

    [JsonProperty("media_url_https")]
    public string MediaUrlHttps { get; set; }

    [JsonProperty("sizes")]
    public Sizes Sizes { get; set; }

    [JsonProperty("source_status_id")]
    public ulong SourceStatusId { get; set; }

    public string SourceStatusIdStr { get { return SourceStatusId.ToString(); } }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }
  }
}