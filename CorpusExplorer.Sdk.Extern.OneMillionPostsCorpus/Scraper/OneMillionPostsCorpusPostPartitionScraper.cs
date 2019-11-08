using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.OneMillionPostsCorpus.Scraper
{
  public class OneMillionPostsCorpusPostPartitionScraper : AbstractScraper
  {
    public override string DisplayName { get; }

    public long Start { get; set; }
    public long Count { get; set; }

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var res = new List<Dictionary<string, object>>();
      var context = new MainDataContext($"data source={file};");
      var max = Start + Count;

      foreach (var post in context.Posts.Where(x => x.IDPost > Start && x.IDPost <= max))
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