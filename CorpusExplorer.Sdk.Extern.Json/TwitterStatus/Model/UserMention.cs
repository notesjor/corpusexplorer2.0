using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Model
{
  public class UserMention
  {

    [JsonProperty("id")]
    public ulong Id { get; set; }

    [JsonProperty("screen_name")]
    public string ScreenName { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("id_str")]
    public string IdStr { get; set; }
  }
  
}
