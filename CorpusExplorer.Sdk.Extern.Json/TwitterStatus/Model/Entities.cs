using Newtonsoft.Json;
using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Model
{
  public class Entities
  {
    [JsonProperty("url")]
    public Url Url { get; set; }

    [JsonProperty("description")]
    public Description Description { get; set; }

    [JsonProperty("user_mentions")]
    public IList<UserMention> UserMentions { get; set; }

    [JsonProperty("urls")]
    public IList<string> Urls { get; set; }

    [JsonProperty("hashtags")]
    public IList<Hashtag> Hashtags { get; set; }

    [JsonProperty("MediaEntities")]
    public IList<string> MediaEntities { get; set; }

    [JsonProperty("symbols")]
    public IList<string> Symbols { get; set; }
  }
  
}
