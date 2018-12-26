using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.Wordpress.Model
{
  public class Cury
  {

    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("templated")]
    public bool Templated { get; set; }
  }
}