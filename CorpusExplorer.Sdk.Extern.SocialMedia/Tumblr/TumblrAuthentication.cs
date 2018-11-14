using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using DontPanic.TumblrSharp;
using DontPanic.TumblrSharp.Client;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Tumblr
{
  public class TumblrAuthentication : AbstractSimpleAuthentication
  {
    protected override object OpenConnection()
    {
      return new TumblrClientFactory()
       .Create<TumblrClient>(
                             Settings["ConsumerKey"],
                             Settings["ConsumerSecret"],
                             new DontPanic.TumblrSharp.OAuth.Token(Settings["OAuthToken"],
                                                                   Settings["OAuthSecret"]));
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
