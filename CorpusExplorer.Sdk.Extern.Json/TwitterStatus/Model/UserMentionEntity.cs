using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Model
{
  public class UserMentionEntity
  {
    [JsonProperty("End")] public ulong End { get; set; }

    [JsonProperty("Id")] public ulong Id { get; set; }

    [JsonProperty("Name")] public string Name { get; set; }

    [JsonProperty("ScreenName")] public string ScreenName { get; set; }

    [JsonProperty("Start")] public ulong Start { get; set; }
  }
}