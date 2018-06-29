#region

using Newtonsoft.Json;

#endregion

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStream.Model
{
  public class UserMention
  {
    [JsonProperty("id")] public ulong Id { get; set; }

    public string IdStr => Id.ToString();

    [JsonProperty("indices")] public ulong[] Indices { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("screen_name")] public string ScreenName { get; set; }
  }
}