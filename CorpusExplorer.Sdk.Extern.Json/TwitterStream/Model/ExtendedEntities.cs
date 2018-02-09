#region

using Newtonsoft.Json;

#endregion

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStream.Model
{
  public class ExtendedEntities
  {
    [JsonProperty("media")]
    public Media[] Media { get; set; }
  }
}