using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using DontPanic.TumblrSharp;
using DontPanic.TumblrSharp.Client;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Tumblr
{
  public class TumblrAuthentication : AbstractAuthentication
  {
    public override object OpenConnection()
    {
      try
      {
        if (Settings.Any(x => string.IsNullOrWhiteSpace(x.Value)))
          return null;

        return new TumblrClientFactory()
         .Create<TumblrClient>(
                               Settings["ConsumerKey"]?.Trim(),
                               Settings["ConsumerSecret"]?.Trim(),
                               new DontPanic.TumblrSharp.OAuth.Token(Settings["OAuthToken"]?.Trim(),
                                                                     Settings["OAuthSecret"]?.Trim()));
      }
      catch
      {
        return null;
      }
    }

    public override string ProviderName => "Tumblr";

    public override Dictionary<string, string> Settings { get; set; }
      = new Dictionary<string, string>
      {
        {"ConsumerKey", ""},
        {"ConsumerSecret", ""},
        {"OAuthToken", ""},
        {"OAuthSecret", ""},
      };
  }
}
