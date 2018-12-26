using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.Json.Abstract;
using CorpusExplorer.Sdk.Extern.Json.Wordpress.Model;
using CorpusExplorer.Sdk.Extern.Json.Wordpress.Reader;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Extern.Json.Wordpress
{
  public class WordpressScraper : AbstractGenericJsonFormatScraper<Post>
  {
    public override string DisplayName => "Wordpress JSON Scraper";
    protected override AbstractGenericDataReader<Post> DataReader => new WordpressDataReader();
    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(IEnumerable<Post> model)
    {
      if (model == null)
        return null;

      var res = new List<Dictionary<string, object>>();

      foreach (var post in model)
      {
        try
        {
          var info = GetInfos(post.Links);

          res.Add(new Dictionary<string, object>
          {
            {"ID", post.Id},
            {"AutorID", post.Author},
            {"Text", post.Content.Raw},
            {"Datum", post.Date},
            {"Links", post.Link},
            {"Anhänge", info?.Attachments},
            {"Replies", info?.Replies},
            {"Datum (letzte Änderung)", post.Modified},
            {"Slug", post.Slug},
            {"Titel", post.Title},
            {"Typ", post.Type}
          });
        }
        catch
        {
          // ignroe
        }
      }

      return res;
    }

    private Infos GetInfos(Links l)
    {
      try
      {
        if (l == null)
          return null;

        return new Infos
        {
          Attachments = SafeJoin(l.WpAttachment?.Select(x => x.Href)),
          Replies = SafeJoin(l.Replies?.Select(x => x.Href)),
        };
      }
      catch
      {
        return null;
      }
    }

    private string SafeJoin(IEnumerable<string> strs)
      => strs == null ? string.Empty : string.Join("|", strs);

    private class Infos
    {
      public string Attachments { get; set; }
      public string Replies { get; set; }
    }
  }
}
