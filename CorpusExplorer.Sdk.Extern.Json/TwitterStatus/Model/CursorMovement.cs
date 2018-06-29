using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Model
{
  public class CursorMovement
  {
    [JsonProperty("Next")] public ulong Next { get; set; }

    [JsonProperty("Previous")] public ulong Previous { get; set; }
  }
}