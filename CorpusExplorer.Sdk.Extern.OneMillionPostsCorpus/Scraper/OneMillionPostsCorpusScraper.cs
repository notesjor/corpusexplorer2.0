using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.OneMillionPostsCorpus.Scraper
{
  public class OneMillionPostsCorpusScraper : AbstractScraper
  {
    public override string DisplayName { get; }

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var res = new List<Dictionary<string, object>>();
      var context = new MainDataContext($"data source={file};");

      foreach (var post in context.Posts)
        try
        {
          if (post.Body == null)
            continue;

          var item = new Dictionary<string, object>
          {
            {"Typ", "Post"},
            {"ID", post.IDPost},
            {"PostID", post.IDParentPost},
            {"ArtikelID", post.IDArticle},
            {"UserID", post.IDUser},
            {"Datum", post.CreatedAt},
            {"Status", post.Status},
            {"Titel", post.Headline},
            {"Text", CleanHtml(post.Body)},
            {"Positiv", post.PositiveVotes},
            {"Negativ", post.NegativeVotes}
          };

          if (post.AnnotationsConsolidated != null && post.AnnotationsConsolidated.Any())
          {
            var first = post.AnnotationsConsolidated.OrderByDescending(x => x?.Value).First();

            item.Add("Kategorie", first.Category);
            item.Add("Kategorie (Wert)", first.Value);
          }

          if (post.Annotations != null && post.Annotations.Any())
            item.Add("Kategorie (vorgeschlagen)", string.Join(", ", post.Annotations.Select(x => x.Category)));

          res.Add(item);
        }
        catch (Exception ex)
        {
          // ignore
        }

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