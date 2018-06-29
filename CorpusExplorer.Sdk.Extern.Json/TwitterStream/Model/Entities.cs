#region

using Newtonsoft.Json;

#endregion

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStream.Model
{
  public class Entities
  {
    [JsonProperty("hashtags")] public Hashtag[] Hashtags { get; set; }

    [JsonProperty("media")] public Media[] Media { get; set; }

    /* Nicht funktional laut Unit-Test mit über 5000 Sampels
    [JsonProperty("symbols")]
    public object[] Symbols { get; set; }

    [JsonProperty("trends")]
    public object[] Trends { get; set; }
    */

    [JsonProperty("urls")] public EntityUrl[] Urls { get; set; }

    [JsonProperty("user_mentions")] public UserMention[] UserMentions { get; set; }
  }
}