#region

using Newtonsoft.Json;

#endregion

namespace CorpusExplorer.Sdk.Extern.Json.YourTwapperKeeper.Model
{
  public class Tweet
  {
    [JsonProperty("archivesource")]
    public string Archivesource { get; set; }

    [JsonProperty("created_at")]
    public string CreatedAt { get; set; }

    [JsonProperty("from_user")]
    public string FromUser { get; set; }

    [JsonProperty("from_user_id")]
    public string FromUserId { get; set; }

    [JsonProperty("geo_coordinates_0")]
    public string GeoCoordinates0 { get; set; }

    [JsonProperty("geo_coordinates_1")]
    public string GeoCoordinates1 { get; set; }

    [JsonProperty("geo_type")]
    public string GeoType { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("iso_language_code")]
    public string IsoLanguageCode { get; set; }

    [JsonProperty("profile_image_url")]
    public string ProfileImageUrl { get; set; }

    [JsonProperty("source")]
    public string Source { get; set; }

    [JsonProperty("text")]
    public string Text { get; set; }

    [JsonProperty("time")]
    public string Time { get; set; }

    [JsonProperty("to_user_id")]
    public string ToUserId { get; set; }
  }
}