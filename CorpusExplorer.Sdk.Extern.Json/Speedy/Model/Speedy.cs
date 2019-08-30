using System.Collections.Generic;
using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.Speedy.Model
{
  public class Speedy
  {

    [JsonProperty("properties")]
    public IList<Property> Properties { get; set; }

    [JsonProperty("text")]
    public string Text { get; set; }
  }
}
