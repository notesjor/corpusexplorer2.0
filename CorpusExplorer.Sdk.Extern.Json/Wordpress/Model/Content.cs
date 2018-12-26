using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.Wordpress.Model
{
  public class Content
  {

    [JsonProperty("protected")]
    public bool Protected { get; set; }

    [JsonProperty("raw")]
    public object Raw { get; set; }

    [JsonProperty("rendered")]
    public string Rendered { get; set; }
  }
}