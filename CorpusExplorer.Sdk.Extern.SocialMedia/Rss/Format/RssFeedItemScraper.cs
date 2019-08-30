using System;
using System.Collections.Generic;
using CodeHollow.FeedReader;
using CodeHollow.FeedReader.Feeds;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using Polenter.Serialization;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Rss.Format
{
  public class RssFeedItemScraper : AbstractScraper
  {
    public override string DisplayName => "Feed";
    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var serializer = new SharpSerializer();
      return Bypass(serializer.Deserialize(file) as FeedItem);
    }

    public IEnumerable<Dictionary<string, object>> Bypass(FeedItem item, string guidStr = null)
    {
      try
      {
        var res = new Dictionary<string, object>();
        if (!string.IsNullOrEmpty(guidStr))
          res.Add("GUID", Guid.Parse(guidStr));

        if (item.PublishingDate.HasValue)
          res.Add("Datum", item.PublishingDate.Value);
        res.Add("Titel", item.Title);
        res.Add("URL", item.Link);
        res.Add("ID", item.Id);
        res.Add("Text", string.IsNullOrEmpty(item.Content) ? item.Description : item.Content);
        res.Add("Kategorien", item.Categories == null ? "" : string.Join(" ; ", item.Categories));
        res.Add("Autor", item.Author);

        if (item.SpecificItem != null)
          res = ApplyDublinCore(item.SpecificItem, res);

        return new[] { res };
      }
      catch
      {
        return null;
      }
    }

    private Dictionary<string, object> ApplyDublinCore(BaseFeedItem item, Dictionary<string, object> res)
    {
      DublinCore dc;
      switch (item)
      {
        case Rss10FeedItem f1:
          dc = f1.DC;
          break;
        case Rss20FeedItem f2:
          dc = f2.DC;
          break;
        default:
          return res;
      }

      if (dc == null)
        return res;

      if (!string.IsNullOrEmpty(dc.Title))
        res["Titel"] = dc.Title;
      if (!string.IsNullOrEmpty(dc.Subject) && string.IsNullOrEmpty(res["Titel"]?.ToString()))
        res["Titel"] = dc.Subject;

      if (!string.IsNullOrEmpty(dc.Creator))
        res["Autor"] = dc.Creator;
      if (!string.IsNullOrEmpty(dc.Contributor) && string.IsNullOrEmpty(res["Autor"]?.ToString()))
        res["Autor"] = dc.Contributor;

      if (!res.ContainsKey("Datum") && dc.Date.HasValue)
        res.Add("Datum", dc.Date.Value);

      return res;
    }
  }
}
