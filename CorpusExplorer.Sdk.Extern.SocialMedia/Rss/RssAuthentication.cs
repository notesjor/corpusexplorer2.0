using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Rss;
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
      var task = ReadFeedAsync(Settings["Url"]);
      task.Wait();

      return Settings != null ? task.Result : null;
    }

    private async Task<List<SyndicationItem>> ReadFeedAsync(string url)
    {
      var items = new List<SyndicationItem>();

      using (var xmlReader = XmlReader.Create(url, new XmlReaderSettings { Async = true }))
      {
        var feedReader = new RssFeedReader(xmlReader);

        while (await feedReader.Read())
        {
          if (feedReader.ElementType == SyndicationElementType.Item)
          {
            var item = await feedReader.ReadItem();
            items.Add((SyndicationItem)item);
          }
        }
      }

      return items;
    }
  }
}