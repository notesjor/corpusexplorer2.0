using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Model
{
  public class Hashtag
  {

    [JsonProperty("text")]
    public string Text { get; set; }
  }
  
}
