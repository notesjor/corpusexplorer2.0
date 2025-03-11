using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using Microsoft.SyndicationFeed;
using Polenter.Serialization;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Rss.Format
{
  public class RssFeedItemScraper : AbstractScraper
  {
    public override string DisplayName => "Feed";
    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var serializer = new SharpSerializer();
      return Bypass(serializer.Deserialize(file) as SyndicationItem);
    }

    public IEnumerable<Dictionary<string, object>> Bypass(SyndicationItem item, string guidStr = null)
    {
      try
      {
        var res = new Dictionary<string, object>();
        if (!string.IsNullOrEmpty(guidStr))
          res.Add("GUID", Guid.Parse(guidStr));

        if (item.Published != null)
          res.Add("Datum", item.Published);
        res.Add("Titel", item.Title);
        res.Add("URL", item.Links.FirstOrDefault()?.Uri?.ToString());
        res.Add("ID", item.Id);
        res.Add("Text", item.Description);
        res.Add("Kategorien", item.Categories == null ? "" : string.Join(" ; ", item.Categories));
        res.Add("Autor", item.Contributors == null ? "" : string.Join(" ; ", item.Contributors));

        return new[] { res };
      }
      catch
      {
        return null;
      }
    }
  }
}