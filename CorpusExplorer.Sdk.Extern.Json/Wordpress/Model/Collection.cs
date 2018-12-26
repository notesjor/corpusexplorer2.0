using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.Wordpress.Model
{
  public class Collection
  {

    [JsonProperty("href")]
    public string Href { get; set; }
  }
}