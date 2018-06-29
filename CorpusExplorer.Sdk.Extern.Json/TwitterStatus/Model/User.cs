using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Model
{
  public class User
  {
    [JsonProperty("BannerSizes")] public object[] BannerSizes { get; set; }

    [JsonProperty("Categories")] public object[] Categories { get; set; }

    [JsonProperty("ContributorsEnabled")] public bool ContributorsEnabled { get; set; }

    [JsonProperty("Count")] public ulong Count { get; set; }

    [JsonProperty("CreatedAt")] public string CreatedAt { get; set; }

    [JsonProperty("Cursor")] public ulong Cursor { get; set; }

    [JsonProperty("CursorMovement")] public CursorMovement CursorMovement { get; set; }

    [JsonProperty("DefaultProfile")] public bool DefaultProfile { get; set; }

    [JsonProperty("DefaultProfileImage")] public bool DefaultProfileImage { get; set; }

    [JsonProperty("Description")] public string Description { get; set; }

    [JsonProperty("Email")] public object Email { get; set; }

    [JsonProperty("FavoritesCount")] public ulong FavoritesCount { get; set; }

    [JsonProperty("FollowersCount")] public ulong FollowersCount { get; set; }

    [JsonProperty("Following")] public bool Following { get; set; }

    [JsonProperty("FollowRequestSent")] public bool FollowRequestSent { get; set; }

    [JsonProperty("FriendsCount")] public ulong FriendsCount { get; set; }

    [JsonProperty("GeoEnabled")] public bool GeoEnabled { get; set; }

    [JsonProperty("ImageSize")] public ulong ImageSize { get; set; }

    [JsonProperty("IncludeEntities")] public bool IncludeEntities { get; set; }

    [JsonProperty("IsTranslator")] public bool IsTranslator { get; set; }

    [JsonProperty("Lang")] public object Lang { get; set; }

    [JsonProperty("LangResponse")] public string LangResponse { get; set; }

    [JsonProperty("ListedCount")] public ulong ListedCount { get; set; }

    [JsonProperty("Location")] public string Location { get; set; }

    [JsonProperty("Name")] public string Name { get; set; }

    [JsonProperty("Notifications")] public bool Notifications { get; set; }

    [JsonProperty("Page")] public ulong Page { get; set; }

    [JsonProperty("ProfileBackgroundColor")]
    public string ProfileBackgroundColor { get; set; }

    [JsonProperty("ProfileBackgroundImageUrl")]
    public string ProfileBackgroundImageUrl { get; set; }

    [JsonProperty("ProfileBackgroundImageUrlHttps")]
    public string ProfileBackgroundImageUrlHttps { get; set; }

    [JsonProperty("ProfileBackgroundTile")]
    public bool ProfileBackgroundTile { get; set; }

    [JsonProperty("ProfileBannerUrl")] public string ProfileBannerUrl { get; set; }

    [JsonProperty("ProfileImage")] public object ProfileImage { get; set; }

    [JsonProperty("ProfileImageUrl")] public string ProfileImageUrl { get; set; }

    [JsonProperty("ProfileImageUrlHttps")] public string ProfileImageUrlHttps { get; set; }

    [JsonProperty("ProfileLinkColor")] public string ProfileLinkColor { get; set; }

    [JsonProperty("ProfileSidebarBorderColor")]
    public string ProfileSidebarBorderColor { get; set; }

    [JsonProperty("ProfileSidebarFillColor")]
    public string ProfileSidebarFillColor { get; set; }

    [JsonProperty("ProfileTextColor")] public string ProfileTextColor { get; set; }

    [JsonProperty("ProfileUseBackgroundImage")]
    public bool ProfileUseBackgroundImage { get; set; }

    [JsonProperty("Protected")] public bool Protected { get; set; }

    [JsonProperty("Query")] public object Query { get; set; }

    [JsonProperty("ScreenName")] public object ScreenName { get; set; }

    [JsonProperty("ScreenNameList")] public object ScreenNameList { get; set; }

    [JsonProperty("ScreenNameResponse")] public string ScreenNameResponse { get; set; }

    [JsonProperty("ShowAllInlineMedia")] public bool ShowAllInlineMedia { get; set; }

    [JsonProperty("SkipStatus")] public bool SkipStatus { get; set; }

    [JsonProperty("Slug")] public object Slug { get; set; }

    [JsonProperty("Status")] public Status Status { get; set; }

    [JsonProperty("StatusesCount")] public ulong StatusesCount { get; set; }

    [JsonProperty("TimeZone")] public string TimeZone { get; set; }

    [JsonProperty("Type")] public ulong Type { get; set; }

    [JsonProperty("Url")] public string Url { get; set; }

    [JsonProperty("UserID")] public ulong UserID { get; set; }

    [JsonProperty("UserIdList")] public object UserIdList { get; set; }

    [JsonProperty("UserIDResponse")] public string UserIDResponse { get; set; }

    [JsonProperty("UtcOffset")] public int UtcOffset { get; set; }

    [JsonProperty("Verified")] public bool Verified { get; set; }
  }
}