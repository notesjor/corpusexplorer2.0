using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Model
{
  public class Tweet
  {

    [JsonProperty("Type")]
    public int Type { get; set; }

    [JsonProperty("ID")]
    public ulong ID { get; set; }

    [JsonProperty("UserID")]
    public ulong UserID { get; set; }

    [JsonProperty("ScreenName")]
    public object ScreenName { get; set; }

    [JsonProperty("SinceID")]
    public ulong SinceID { get; set; }

    [JsonProperty("MaxID")]
    public ulong MaxID { get; set; }

    [JsonProperty("Count")]
    public ulong Count { get; set; }

    [JsonProperty("Cursor")]
    public ulong Cursor { get; set; }

    [JsonProperty("IncludeRetweets")]
    public bool IncludeRetweets { get; set; }

    [JsonProperty("ExcludeReplies")]
    public bool ExcludeReplies { get; set; }

    [JsonProperty("IncludeEntities")]
    public bool IncludeEntities { get; set; }

    [JsonProperty("IncludeUserEntities")]
    public bool IncludeUserEntities { get; set; }

    [JsonProperty("IncludeMyRetweet")]
    public bool IncludeMyRetweet { get; set; }

    [JsonProperty("IncludeAltText")]
    public bool IncludeAltText { get; set; }

    [JsonProperty("OEmbedUrl")]
    public object OEmbedUrl { get; set; }
    
    [JsonProperty("OEmbedHideMedia")]
    public bool OEmbedHideMedia { get; set; }

    [JsonProperty("OEmbedHideThread")]
    public bool OEmbedHideThread { get; set; }

    [JsonProperty("OEmbedOmitScript")]
    public bool OEmbedOmitScript { get; set; }
    
    [JsonProperty("OEmbedRelated")]
    public object OEmbedRelated { get; set; }

    [JsonProperty("OEmbedLanguage")]
    public object OEmbedLanguage { get; set; }

    [JsonProperty("CreatedAt")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("StatusID")]
    public ulong StatusID { get; set; }

    [JsonProperty("Text")]
    public string Text { get; set; }

    [JsonProperty("FullText")]
    public string FullText { get; set; }

    [JsonProperty("ExtendedTweet")]
    public Tweet SubTweet { get; set; }

    [JsonProperty("Source")]
    public object Source { get; set; }

    [JsonProperty("Truncated")]
    public bool Truncated { get; set; }

    [JsonProperty("DisplayTextRange")]
    public object DisplayTextRange { get; set; }

    [JsonProperty("TweetMode")]
    public string TweetMode { get; set; }

    [JsonProperty("InReplyToStatusID")]
    public string InReplyToStatusID { get; set; }

    [JsonProperty("InReplyToUserID")]
    public string InReplyToUserID { get; set; }

    [JsonProperty("FavoriteCount")]
    public object FavoriteCount { get; set; }

    [JsonProperty("Favorited")]
    public bool Favorited { get; set; }

    [JsonProperty("InReplyToScreenName")]
    public object InReplyToScreenName { get; set; }
    
    [JsonProperty("User")]
    public User User { get; set; }

    [JsonProperty("Users")]
    public object Users { get; set; }

    [JsonProperty("Contributors")]
    public object Contributors { get; set; }

    [JsonProperty("Coordinates")]
    public Coordinates Coordinates { get; set; }

    [JsonProperty("Place")]
    public Place Place { get; set; }
    

    [JsonProperty("Entities")]
    public Entities Entities { get; set; }

    [JsonProperty("ExtendedEntities")]
    public object ExtendedEntities { get; set; }

    [JsonProperty("TrimUser")]
    public bool TrimUser { get; set; }

    [JsonProperty("IncludeContributorDetails")]
    public bool IncludeContributorDetails { get; set; }

    [JsonProperty("RetweetCount")]
    public int RetweetCount { get; set; }

    [JsonProperty("Retweeted")]
    public bool Retweeted { get; set; }

    [JsonProperty("PossiblySensitive")]
    public bool PossiblySensitive { get; set; }

    [JsonProperty("RetweetedStatus")]
    public object RetweetedStatus { get; set; }
    
    [JsonProperty("CurrentUserRetweet")]
    public int CurrentUserRetweet { get; set; }

    [JsonProperty("IsQuotedStatus")]
    public bool IsQuotedStatus { get; set; }

    [JsonProperty("QuotedStatusID")]
    public ulong QuotedStatusID { get; set; }

    [JsonProperty("QuotedStatus")]
    public object QuotedStatus { get; set; }

    [JsonProperty("Scopes")]
    public object Scopes { get; set; }

    [JsonProperty("WithheldCopyright")]
    public bool WithheldCopyright { get; set; }

    [JsonProperty("WithheldInCountries")]
    public object WithheldInCountries { get; set; }

    [JsonProperty("WithheldScope")]
    public object WithheldScope { get; set; }

    [JsonProperty("MetaData")]
    public object MetaData { get; set; }

    [JsonProperty("Lang")]
    public object Lang { get; set; }

    [JsonProperty("Map")]
    public bool Map { get; set; }

    [JsonProperty("TweetIDs")]
    public object TweetIDs { get; set; }

    [JsonProperty("FilterLevel")]
    public string FilterLevel { get; set; }

    [JsonProperty("EmbeddedStatus")]
    public object EmbeddedStatus { get; set; }

    [JsonProperty("CursorMovement")]
    public object CursorMovement { get; set; }    
  }
  
}
