using System.Collections.Generic;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using LinqToTwitter;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Twitter
{
  public class TwitterContextAuthentication : AbstractSimpleAuthentication
  {
    protected override object OpenConnection()
    {
      var credential = new InMemoryCredentialStore
      {
        ConsumerKey = Settings["ConsumerKey"],
        ConsumerSecret = Settings["ConsumerSecret"],
        OAuthToken = Settings["OAuthToken"],
        OAuthTokenSecret = Settings["OAuthTokenSecret"],
        ScreenName = Settings["ScreenName"],
        UserID = ulong.Parse(Settings["UserID"])
      };

      return new TwitterContext(new SingleUserAuthorizer { CredentialStore = credential });
    }

    public override string ProviderName => "Twitter";

    public override Dictionary<string, string> Settings { get; set; }
      = new Dictionary<string, string>
      {
        {"ConsumerKey", ""},
        {"ConsumerSecret", ""},
        {"OAuthToken", ""},
        {"OAuthTokenSecret", ""},
        {"ScreenName", ""},
        {"UserID", ""},
      };
  }
}
