using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Model
{
  public class MetaData
  {
    [JsonProperty("IsoLanguageCode")] public object IsoLanguageCode { get; set; }

    [JsonProperty("ResultType")] public object ResultType { get; set; }
  }
}