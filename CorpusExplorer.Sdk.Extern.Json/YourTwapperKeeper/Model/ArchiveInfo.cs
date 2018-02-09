#region

using Newtonsoft.Json;

#endregion

namespace CorpusExplorer.Sdk.Extern.Json.YourTwapperKeeper.Model
{
  public class ArchiveInfo
  {
    [JsonProperty("count")]
    public string Count { get; set; }

    [JsonProperty("create_time")]
    public string CreateTime { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("keyword")]
    public string Keyword { get; set; }

    [JsonProperty("screen_name")]
    public string ScreenName { get; set; }

    [JsonProperty("tags")]
    public string Tags { get; set; }

    [JsonProperty("user_id")]
    public string UserId { get; set; }
  }
}