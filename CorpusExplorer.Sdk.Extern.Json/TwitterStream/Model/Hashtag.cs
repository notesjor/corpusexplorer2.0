#region

using Newtonsoft.Json;

#endregion

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStream.Model
{
  public class Hashtag
  {
    [JsonProperty("indices")] public ulong[] Indices { get; set; }

    [JsonProperty("text")] public string Text { get; set; }
  }
}