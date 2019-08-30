using System.ComponentModel;
using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.Speedy.Model
{
  public class Property
  {
    [DefaultValue(-1)]
    [JsonProperty("endIndex", DefaultValueHandling = DefaultValueHandling.Populate)]
    public int EndIndex { get; set; }

    [JsonProperty("guid")]
    public string Guid { get; set; }

    [JsonProperty("index")]
    public int Index { get; set; }

    [DefaultValue(-1)]
    [JsonProperty("startIndex", DefaultValueHandling = DefaultValueHandling.Populate)]
    public int StartIndex { get; set; }

    [JsonProperty("text")]
    public string Text { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("userGuid")]
    public string UserGuid { get; set; }

    [JsonProperty("value")]
    public string Value { get; set; }
  }
}