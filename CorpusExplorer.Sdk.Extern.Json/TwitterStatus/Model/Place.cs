using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Model
{
  public class Place
  {
    [JsonProperty("Attributes")] public object Attributes { get; set; }

    [JsonProperty("BoundingBox")] public object BoundingBox { get; set; }

    [JsonProperty("ContainedWithin")] public object ContainedWithin { get; set; }

    [JsonProperty("Country")] public object Country { get; set; }

    [JsonProperty("CountryCode")] public object CountryCode { get; set; }

    [JsonProperty("FullName")] public object FullName { get; set; }

    [JsonProperty("Geometry")] public object Geometry { get; set; }

    [JsonProperty("ID")] public object ID { get; set; }

    [JsonProperty("Name")] public object Name { get; set; }

    [JsonProperty("PlaceType")] public object PlaceType { get; set; }

    [JsonProperty("PolyLines")] public object PolyLines { get; set; }

    [JsonProperty("Url")] public object Url { get; set; }
  }
}