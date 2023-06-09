using Newtonsoft.Json;
using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Model
{
  public class Description
  {

    [JsonProperty("user_mentions")]
    public IList<object> UserMentions { get; set; }

    [JsonProperty("urls")]
    public IList<object> Urls { get; set; }

    [JsonProperty("hashtags")]
    public IList<object> Hashtags { get; set; }

    [JsonProperty("MediaEntities")]
    public IList<object> MediaEntities { get; set; }

    [JsonProperty("symbols")]
    public IList<object> Symbols { get; set; }
  }
  
}
