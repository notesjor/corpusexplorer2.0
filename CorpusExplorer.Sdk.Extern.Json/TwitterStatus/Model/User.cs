using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Model
{
  public class User
  {

    [JsonProperty("Type")]
    public string Type { get; set; }

    [JsonProperty("UserID")]
    public ulong UserID { get; set; }

    [JsonProperty("UserIdList")]
    public object UserIdList { get; set; }

    [JsonProperty("ScreenName")]
    public object ScreenName { get; set; }

    [JsonProperty("ScreenNameList")]
    public object ScreenNameList { get; set; }
    
    [JsonProperty("Slug")]
    public object Slug { get; set; }

    [JsonProperty("Query")]
    public object Query { get; set; }

    [JsonProperty("IncludeEntities")]
    public bool IncludeEntities { get; set; }

    [JsonProperty("SkipStatus")]
    public bool SkipStatus { get; set; }

    [JsonProperty("UserIDResponse")]
    public string UserIDResponse { get; set; }

    [JsonProperty("ScreenNameResponse")]
    public string ScreenNameResponse { get; set; }
    
    [JsonProperty("TweetMode")]
    public string TweetMode { get; set; }
    
    [JsonProperty("Name")]
    public string Name { get; set; }

    [JsonProperty("Location")]
    public string Location { get; set; }

    [JsonProperty("Description")]
    public string Description { get; set; }

    [JsonProperty("ProfileImageUrl")]
    public string ProfileImageUrl { get; set; }

    [JsonProperty("ProfileImageUrlHttps")]
    public string ProfileImageUrlHttps { get; set; }

    [JsonProperty("DefaultProfileImage")]
    public bool DefaultProfileImage { get; set; }

    [JsonProperty("Url")]
    public object Url { get; set; }

    [JsonProperty("Entities")]
    public Entities Entities { get; set; }

    [JsonProperty("DefaultProfile")]
    public bool DefaultProfile { get; set; }

    [JsonProperty("Protected")]
    public bool Protected { get; set; }

    [JsonProperty("FollowersCount")]
    public ulong FollowersCount { get; set; }

    [JsonProperty("ProfileBackgroundColor")]
    public string ProfileBackgroundColor { get; set; }

    [JsonProperty("ProfileTextColor")]
    public string ProfileTextColor { get; set; }

    [JsonProperty("ProfileLinkColor")]
    public string ProfileLinkColor { get; set; }

    [JsonProperty("ProfileSidebarFillColor")]
    public string ProfileSidebarFillColor { get; set; }

    [JsonProperty("ProfileSidebarBorderColor")]
    public string ProfileSidebarBorderColor { get; set; }

    [JsonProperty("FriendsCount")]
    public ulong FriendsCount { get; set; }

    [JsonProperty("CreatedAt")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("FavoritesCount")]
    public ulong FavoritesCount { get; set; }

    [JsonProperty("UtcOffset")]
    public ulong UtcOffset { get; set; }

    [JsonProperty("TimeZone")]
    public object TimeZone { get; set; }

    [JsonProperty("ProfileBackgroundImageUrl")]
    public object ProfileBackgroundImageUrl { get; set; }

    [JsonProperty("ProfileBackgroundImageUrlHttps")]
    public object ProfileBackgroundImageUrlHttps { get; set; }

    [JsonProperty("ProfileBackgroundTile")]
    public bool ProfileBackgroundTile { get; set; }

    [JsonProperty("ProfileUseBackgroundImage")]
    public bool ProfileUseBackgroundImage { get; set; }

    [JsonProperty("StatusesCount")]
    public ulong StatusesCount { get; set; }

    [JsonProperty("Notifications")]
    public bool Notifications { get; set; }

    [JsonProperty("GeoEnabled")]
    public bool GeoEnabled { get; set; }

    [JsonProperty("Verified")]
    public bool Verified { get; set; }

    [JsonProperty("ContributorsEnabled")]
    public bool ContributorsEnabled { get; set; }

    [JsonProperty("IsTranslator")]
    public bool IsTranslator { get; set; }

    [JsonProperty("Following")]
    public bool Following { get; set; }

    [JsonProperty("Status")]
    public Tweet Status { get; set; }

    [JsonProperty("Categories")]
    public IList<object> Categories { get; set; }

    [JsonProperty("Lang")]
    public object Lang { get; set; }

    [JsonProperty("LangResponse")]
    public object LangResponse { get; set; }

    [JsonProperty("ShowAllInlineMedia")]
    public bool ShowAllInlineMedia { get; set; }

    [JsonProperty("ListedCount")]
    public ulong ListedCount { get; set; }

    [JsonProperty("FollowRequestSent")]
    public bool FollowRequestSent { get; set; }

    [JsonProperty("ProfileImage")]
    public object ProfileImage { get; set; }

    [JsonProperty("ProfileBannerUrl")]
    public string ProfileBannerUrl { get; set; }

    [JsonProperty("BannerSizes")]
    public IList<object> BannerSizes { get; set; }

    [JsonProperty("Email")]
    public object Email { get; set; }
  }
  
}
