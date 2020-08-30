using System;
using System.Collections.Generic;
using System.Linq;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using fastJSONLD;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.Trafilatura
{
  public class HtmlJsonLdScraper : AbstractScraper
  {
    public override string DisplayName => "HTML JSON+LD";
    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var input = FileIO.ReadText(file, Configuration.Encoding);
      var doc = GetMetadata(ref input);

      try
      {
        var html = new HtmlDocument();
        html.LoadHtml(input);
        doc.Add("Text", html.DocumentNode.SelectNodes("/html/body").First().InnerText);
      }
      // Fallback 2
      catch
      {
        doc.Add("Text", input);
      }

      return new[] { doc };
    }

    private Dictionary<string, object> GetMetadata(ref string input)
    {
      try
      {
        var res = new Dictionary<string, object>();
        var html = new HtmlDocument();
        html.LoadHtml(input);

        GetMetadataJsonLd(ref html, ref res);
        if (res.Count == 0) // Fallback
          GetMetadataHtmlTags(ref html, ref res);

        return res;
      }
      catch
      {
        return new Dictionary<string, object>();
      }
    }

    private Dictionary<string, string> _metaQueries = new Dictionary<string, string>
    {
      {"author", "Autor"},
      {"autor", "Autor"},
      {"title", "Titel"},
      {"titel", "Titel"}
    };

    private void GetMetadataHtmlTags(ref HtmlDocument html, ref Dictionary<string, object> res)
    {
      try
      {
        var nodes = html.DocumentNode.SelectNodes("/html/head/meta");
        if (nodes == null || nodes.Count == 0)
          return;

        foreach (var node in nodes)
        {
          var name = node.GetAttributeValue("name", null)?.ToLower();
          var content = node.GetAttributeValue("content", null);
          if (name == null || content == null)
            continue;
          foreach (var q in _metaQueries)
            if (!res.ContainsKey(q.Value) && name.Contains(q.Key))
              res.Add(q.Value, content);
        }
      }
      catch
      {
        // ignore
      }
    }

    private Dictionary<string, string> _jldQueries = new Dictionary<string, string>
    {
      {"dateModified", "Datum"},
      {"datePublished", "Datum"},
      {"dateCreated", "Datum"},
      {"headline", "Titel"},
      {"title", "Titel"},
      {"articleSection", "Rubrik" }
    };

    private void GetMetadataJsonLd(ref HtmlDocument html, ref Dictionary<string, object> res)
    {
      try
      {
        var nodes = html.DocumentNode.SelectNodes("//script[@type=\"application/ld+json\"]");
        if (nodes == null || nodes.Count == 0)
          return;

        foreach (var node in nodes)
        {
          try
          {
            var parts = JsonLdParser.Parse(node.InnerText);
            foreach (var part in parts)
            {
              if (!part.Properties.ContainsKey("@type") || part.Properties["@type"] != "NewsArticle")
                continue;

              try
              {
                // Autor
                if (part.Children.ContainsKey("author"))
                {
                  res.Add("Autor",
                          string.Join(" ; ",
                                      part.Children["author"]
                                          .Select(x => x.Properties.ContainsKey("name") ? x.Properties["name"] : null)
                                          .Where(x => !string.IsNullOrWhiteSpace(x))));
                }

                foreach (var p in _jldQueries)
                  if (!res.ContainsKey(p.Value) && part.Properties.ContainsKey(p.Key))
                    res.Add(p.Value, part.Properties[p.Key]);
              }
              catch
              {
                // ignore
              }
            }
          }
          catch
          {
            // ignore
          }
        }
      }
      catch
      {
        // ignore
      }
    }
  }
}
