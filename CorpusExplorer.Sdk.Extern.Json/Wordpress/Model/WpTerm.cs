using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.Wordpress.Model
{
  public class WpTerm
  {

    [JsonProperty("embeddable")]
    public bool Embeddable { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("taxonomy")]
    public string Taxonomy { get; set; }
  }
}