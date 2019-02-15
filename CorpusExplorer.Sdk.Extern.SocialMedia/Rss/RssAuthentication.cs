using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CodeHollow.FeedReader;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Rss
{
  public class RssAuthentication : AbstractAuthentication
  {
    public override string ProviderName => "RSS/ATOM-Feed";

    public override Dictionary<string, string> Settings { get; set; }
      = new Dictionary<string, string>
      {
        {"Name", ""},
        {"Url", ""}
      };

    public override object OpenConnection()
    {
      var task = FeedReader.ReadAsync(Settings["Url"]);
      task.Wait();

      return Settings != null ? task.Result : null;
    }
  }
}
