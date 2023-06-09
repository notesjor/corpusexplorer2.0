using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Model
{
  public class Place
  {

    [JsonProperty("Name")]
    public string Name { get; set; }

    [JsonProperty("CountryCode")]
    public string CountryCode { get; set; }

    [JsonProperty("ID")]
    public string ID { get; set; }

    [JsonProperty("Country")]
    public string Country { get; set; }

    [JsonProperty("PlaceType")]
    public string PlaceType { get; set; }

    [JsonProperty("Url")]
    public string Url { get; set; }

    [JsonProperty("FullName")]
    public string FullName { get; set; }

    [JsonProperty("Attributes")]
    public string Attributes { get; set; }
    
    [JsonProperty("BoundingBox")]
    public string BoundingBox { get; set; }

    [JsonProperty("Geometry")]
    public string Geometry { get; set; }

    [JsonProperty("PolyLines")]
    public string PolyLines { get; set; }

    [JsonProperty("ContainedWithin")]
    public string ContainedWithin { get; set; }
  }
  
}
