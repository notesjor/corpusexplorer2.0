using Newtonsoft.Json;
using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Model
{
  public class Url
  {

    [JsonProperty("user_mentions")]
    public IList<string> UserMentions { get; set; }

    [JsonProperty("urls")]
    public IList<string> Urls { get; set; }

    [JsonProperty("hashtags")]
    public IList<string> Hashtags { get; set; }

    [JsonProperty("MediaEntities")]
    public IList<string> MediaEntities { get; set; }

    [JsonProperty("symbols")]
    public IList<string> Symbols { get; set; }
  }
  
}
