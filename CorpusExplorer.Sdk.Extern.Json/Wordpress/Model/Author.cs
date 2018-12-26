using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.Wordpress.Model
{
  public class Author
  {

    [JsonProperty("embeddable")]
    public bool Embeddable { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }
  }
}