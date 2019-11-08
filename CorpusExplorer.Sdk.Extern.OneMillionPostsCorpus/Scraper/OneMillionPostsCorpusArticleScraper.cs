using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.OneMillionPostsCorpus.Scraper
{
  public class OneMillionPostsCorpusArticleScraper : AbstractScraper
  {
    public override string DisplayName { get; }

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var res = new List<Dictionary<string, object>>();
      var context = new MainDataContext($"data source={file};");

      foreach (var article in context.Articles)
        try
        {
          res.Add(new Dictionary<string, object>
          {
            {"Typ", "Artikel"},
            {"ID", article.IDArticle},
            {"Path", article.Path},
            {"Datum", article.PublishingDate},
            {"Titel", article.Title},
            {"Text", CleanHtml(article.Body)}
          });
        }
        catch (Exception ex)
        {
          // ignore
        }

      return res;
    }

    private string CleanHtml(string body)
    {
      var pageDoc = new HtmlDocument();
      pageDoc.LoadHtml(body);
      return pageDoc.DocumentNode.InnerText;
    }
  }
}