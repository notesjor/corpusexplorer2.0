using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Model
{
  public class Annotation
  {
    [JsonProperty("Type")] public object Type { get; set; }
  }
}