#region

using Newtonsoft.Json;

#endregion

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStream.Model
{
  public class User
  {
    [JsonProperty("contributors_enabled")]
    public bool ContributorsEnabled { get; set; }

    [JsonProperty("created_at")]
    public string CreatedAt { get; set; }

    [JsonProperty("default_profile")]
    public bool DefaultProfile { get; set; }

    [JsonProperty("default_profile_image")]
    public bool DefaultProfileImage { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("favourites_count")]
    public ulong FavouritesCount { get; set; }

    /* Nicht funktional laut Unit-Test mit über 5000 Sampels
    [JsonProperty("follow_request_sent")]
    public object FollowRequestSent { get; set; }
    */

    [JsonProperty("followers_count")]
    public ulong FollowersCount { get; set; }

    /* Nicht funktional laut Unit-Test mit über 5000 Sampels
    [JsonProperty("following")]
    public object Following { get; set; }
    */

    [JsonProperty("friends_count")]
    public ulong FriendsCount { get; set; }

    [JsonProperty("geo_enabled")]
    public bool GeoEnabled { get; set; }

    [JsonProperty("id")]
    public ulong Id { get; set; }

    public string IdStr { get { return Id.ToString(); } }

    [JsonProperty("is_translator")]
    public bool IsTranslator { get; set; }

    [JsonProperty("lang")]
    public string Lang { get; set; }

    [JsonProperty("listed_count")]
    public ulong ListedCount { get; set; }

    [JsonProperty("location")]
    public string Location { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    /* Nicht funktional laut Unit-Test mit über 5000 Sampels
    [JsonProperty("notifications")]
    public object Notifications { get; set; }
    */

    [JsonProperty("protected")]
    public bool Protected { get; set; }

    [JsonProperty("screen_name")]
    public string ScreenName { get; set; }

    [JsonProperty("statuses_count")]
    public ulong StatusesCount { get; set; }

    [JsonProperty("time_zone")]
    public string TimeZone { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("utc_offset")]
    public int? UtcOffset { get; set; }

    [JsonProperty("verified")]
    public bool Verified { get; set; }
  }
}