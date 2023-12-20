using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Extern.Json.OpenLegalData.Model
{
  public class OpenLegalDataEntry
  {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("slug")]
    public string Slug { get; set; }

    [JsonProperty("court")]
    public Court Court { get; set; }

    [JsonProperty("file_number")]
    public string FileNumber { get; set; }

    [JsonProperty("date")]
    public string Date { get; set; }

    [JsonProperty("created_date")]
    public DateTime CreatedDate { get; set; }

    [JsonProperty("updated_date")]
    public DateTime UpdatedDate { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("ecli")]
    public string Ecli { get; set; }

    [JsonProperty("content")]
    public string Content { get; set; }
  }  
}