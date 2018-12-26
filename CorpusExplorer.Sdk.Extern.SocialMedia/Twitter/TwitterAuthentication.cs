using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using LinqToTwitter;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Twitter
{
  public class TwitterAuthentication : AbstractAuthentication
  {
    public override object OpenConnection()
    {
      try
      {
        if (Settings.Any(x => string.IsNullOrWhiteSpace(x.Value)))
          return null;

        var credential = new InMemoryCredentialStore
        {
          ConsumerKey = Settings["API Key"]?.Trim(),
          ConsumerSecret = Settings["API Secret"]?.Trim(),
          OAuthToken = Settings["Access token"]?.Trim(),
          OAuthTokenSecret = Settings["Access token secret"]?.Trim(),
          ScreenName = Settings["App name"]?.Trim()
        };

        return new TwitterContext(new SingleUserAuthorizer { CredentialStore = credential });
      }
      catch
      {
        return null;
      }
    }

    public override string ProviderName => "Twitter";

    public override Dictionary<string, string> Settings { get; set; }
      = new Dictionary<string, string>
      {
        {"API Key", ""},
        {"API Secret", ""},
        {"Access token", ""},
        {"Access token secret", ""},
        {"App name", ""},
      };
  }
}
