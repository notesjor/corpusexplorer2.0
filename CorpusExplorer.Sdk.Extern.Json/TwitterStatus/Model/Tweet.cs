using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Model
{
  public class Tweet
  {
    [JsonProperty("Annotation")] public Annotation Annotation { get; set; }

    [JsonProperty("Contributors")] public object[] Contributors { get; set; }

    [JsonProperty("Coordinates")] public Coordinates Coordinates { get; set; }

    [JsonProperty("Count")] public ulong Count { get; set; }

    [JsonProperty("CreatedAt")] public string CreatedAt { get; set; }

    [JsonProperty("CurrentUserRetweet")] public ulong CurrentUserRetweet { get; set; }

    [JsonProperty("Cursor")] public ulong Cursor { get; set; }

    [JsonProperty("CursorMovement")] public object CursorMovement { get; set; }

    [JsonProperty("EmbeddedStatus")] public object EmbeddedStatus { get; set; }

    [JsonProperty("Entities")] public Entities Entities { get; set; }

    [JsonProperty("ExcludeReplies")] public bool ExcludeReplies { get; set; }

    [JsonProperty("ExtendedEntities")] public ExtendedEntities ExtendedEntities { get; set; }

    [JsonProperty("FavoriteCount")] public ulong? FavoriteCount { get; set; }

    [JsonProperty("Favorited")] public bool Favorited { get; set; }

    [JsonProperty("FilterLevel")] public ulong FilterLevel { get; set; }

    [JsonProperty("ID")] public ulong ID { get; set; }

    [JsonProperty("IncludeContributorDetails")]
    public bool IncludeContributorDetails { get; set; }

    [JsonProperty("IncludeEntities")] public bool IncludeEntities { get; set; }

    [JsonProperty("IncludeMyRetweet")] public bool IncludeMyRetweet { get; set; }

    [JsonProperty("IncludeRetweets")] public bool IncludeRetweets { get; set; }

    [JsonProperty("IncludeUserEntities")] public bool IncludeUserEntities { get; set; }

    [JsonProperty("InReplyToScreenName")] public object InReplyToScreenName { get; set; }

    [JsonProperty("InReplyToStatusID")] public ulong InReplyToStatusID { get; set; }

    [JsonProperty("InReplyToUserID")] public ulong InReplyToUserID { get; set; }

    [JsonProperty("Lang")] public string Lang { get; set; }

    [JsonProperty("Map")] public bool Map { get; set; }

    [JsonProperty("MaxID")] public long MaxID { get; set; }

    [JsonProperty("MetaData")] public MetaData MetaData { get; set; }

    [JsonProperty("OEmbedAlign")] public ulong OEmbedAlign { get; set; }

    [JsonProperty("OEmbedHideMedia")] public bool OEmbedHideMedia { get; set; }

    [JsonProperty("OEmbedHideThread")] public bool OEmbedHideThread { get; set; }

    [JsonProperty("OEmbedLanguage")] public object OEmbedLanguage { get; set; }

    [JsonProperty("OEmbedMaxWidth")] public ulong OEmbedMaxWidth { get; set; }

    [JsonProperty("OEmbedOmitScript")] public bool OEmbedOmitScript { get; set; }

    [JsonProperty("OEmbedRelated")] public object OEmbedRelated { get; set; }

    [JsonProperty("OEmbedUrl")] public object OEmbedUrl { get; set; }

    [JsonProperty("Place")] public Place Place { get; set; }

    [JsonProperty("PossiblySensitive")] public bool PossiblySensitive { get; set; }

    [JsonProperty("QuotedStatus")] public QuotedStatus QuotedStatus { get; set; }

    [JsonProperty("QuotedStatusID")] public long QuotedStatusID { get; set; }

    [JsonProperty("RetweetCount")] public ulong? RetweetCount { get; set; }

    [JsonProperty("Retweeted")] public bool Retweeted { get; set; }

    [JsonProperty("RetweetedStatus")] public RetweetedStatus RetweetedStatus { get; set; }

    [JsonProperty("ScreenName")] public string ScreenName { get; set; }

    [JsonProperty("SinceID")] public ulong SinceID { get; set; }

    [JsonProperty("Source")] public string Source { get; set; }

    [JsonProperty("StatusID")] public long StatusID { get; set; }

    [JsonProperty("Text")] public string Text { get; set; }

    [JsonProperty("TrimUser")] public bool TrimUser { get; set; }

    [JsonProperty("Truncated")] public bool Truncated { get; set; }

    [JsonProperty("TweetIDs")] public object TweetIDs { get; set; }

    [JsonProperty("Type")] public ulong Type { get; set; }

    [JsonProperty("User")] public User User { get; set; }

    [JsonProperty("UserID")] public ulong UserID { get; set; }

    [JsonProperty("Users")] public object[] Users { get; set; }

    [JsonProperty("WithheldCopyright")] public bool WithheldCopyright { get; set; }

    [JsonProperty("WithheldInCountries")] public object[] WithheldInCountries { get; set; }

    [JsonProperty("WithheldScope")] public object WithheldScope { get; set; }
  }
}