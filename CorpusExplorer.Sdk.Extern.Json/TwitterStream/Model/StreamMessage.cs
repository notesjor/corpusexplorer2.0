#region

using Newtonsoft.Json;

#endregion

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStream.Model
{
  public class StreamMessage
  {
    /* Nicht funktional laut Unit-Test mit über 5000 Sampels
    [JsonProperty("contributors")]
    public object Contributors { get; set; }
    */

    [JsonProperty("coordinates")]
    public Geo Coordinates { get; set; }

    [JsonProperty("created_at")]
    public string CreatedAt { get; set; }

    [JsonProperty("entities")]
    public Entities Entities { get; set; }

    [JsonProperty("extended_entities")]
    public ExtendedEntities ExtendedEntities { get; set; }

    [JsonProperty("favorite_count")]
    public int FavoriteCount { get; set; }

    [JsonProperty("favorited")]
    public bool Favorited { get; set; }

    [JsonProperty("filter_level")]
    public string FilterLevel { get; set; }

    [JsonProperty("geo")]
    public Geo Geo { get; set; }

    [JsonProperty("id")]
    public long Id { get; set; }

    public string IdStr { get { return Id.ToString(); } }

    [JsonProperty("lang")]
    public string Lang { get; set; }

    [JsonProperty("place")]
    public Place Place { get; set; }

    [JsonProperty("possibly_sensitive")]
    public bool PossiblySensitive { get; set; }

    [JsonProperty("retweet_count")]
    public int RetweetCount { get; set; }

    [JsonProperty("retweeted")]
    public bool Retweeted { get; set; }

    [JsonProperty("retweeted_status")]
    public StreamMessage RetweetedStatus { get; set; }

    [JsonProperty("source")]
    public string Source { get; set; }

    [JsonProperty("text")]
    public string Text { get; set; }

    [JsonProperty("timestamp_ms")]
    public string TimestampMs { get; set; }

    [JsonProperty("truncated")]
    public bool Truncated { get; set; }

    [JsonProperty("user")]
    public User User { get; set; }
  }
}