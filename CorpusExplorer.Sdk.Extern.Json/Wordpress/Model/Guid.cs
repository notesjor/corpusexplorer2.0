﻿using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.Wordpress.Model
{
  public class Guid
  {

    [JsonProperty("raw")]
    public object Raw { get; set; }

    [JsonProperty("rendered")]
    public string Rendered { get; set; }
  }
}