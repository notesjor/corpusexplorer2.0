using CorpusExplorer.Terminal.Universal.Message.Response.NewsAndAddons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Tfres;

namespace CorpusExplorer.Terminal.Universal
{
  public static partial class Program
  {
    private static void GetNews(HttpContext obj)
    {
      var param = obj.GetData();
      var rssFeedUrl = param.ContainsKey("url") ? param["url"] : "https://notes.jan-oliver-ruediger.de/category/appnote/feed/";

      var res = new List<NewsFeedItem>();
      using (XmlReader reader = XmlReader.Create(rssFeedUrl))
      {
        SyndicationFeed feed = SyndicationFeed.Load(reader);

        if (feed == null)
        {
          obj.Response.Send(System.Net.HttpStatusCode.NotFound);
          return;
        }

        foreach (SyndicationItem item in feed.Items)
        {
          if (item == null)
            continue;

          try
          {
            res.Add(new NewsFeedItem
            {
              Title = item.Title.Text,
              Url = item.Links[0].Uri.ToString(),
              Date = item.PublishDate.Date
            });
          }
          catch
          {
            // ignore
          }
        }

        obj.Response.Send(res);
      }
    }

    private static void GetAvailableCorpora(HttpContext obj)
    {
      throw new NotImplementedException();
    }

    private static void GetAvailableAddons(HttpContext obj)
    {
      throw new NotImplementedException();
    }

    private static void GetCorpusOrAddon(HttpContext obj)
    {
      throw new NotImplementedException();
    }
  }
}
