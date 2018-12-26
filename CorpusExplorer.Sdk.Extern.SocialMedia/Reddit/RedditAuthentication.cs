using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Reddit
{
  public class RedditAuthentication : AbstractAuthentication
  {
    protected override object OpenConnection()
      => new RedditSharp.Reddit(new RedditSharp.BotWebAgent(Settings["Username"], Settings["Password"], Settings["ClientID"], Settings["ClientSecret"], Settings["RedirectUri"]), false);

    public override string ProviderName => "Reddit";
    public override Dictionary<string, string> Settings { get; set; }
      = new Dictionary<string, string>
      {
        {"Username", ""},
        {"Password", ""},
        {"ClientID", ""},
        {"ClientSecret", ""},
        {"RedirectUri", ""}
      };
  }
}