#region

using Newtonsoft.Json;

#endregion

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStream.Model
{
  public class Place
  {
    [JsonProperty("bounding_box")] public BoundingBox BoundingBox { get; set; }

    [JsonProperty("country")] public string Country { get; set; }

    [JsonProperty("country_code")] public string CountryCode { get; set; }

    [JsonProperty("full_name")] public string FullName { get; set; }

    [JsonProperty("id")] public string Id { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("place_type")] public string PlaceType { get; set; }

    [JsonProperty("url")] public string Url { get; set; }
  }
}