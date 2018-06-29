using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using Toxy;

namespace CorpusExplorer.Sdk.Extern.Toxy
{
  public class LuckyScraper : AbstractScraper
  {
    public override string DisplayName => "Lucky-Scraper";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      try
      {
        var context = new ParserContext(file) {Encoding = Configuration.Encoding};
        var parser = ParserFactory.CreateDom(context);
        var doc = parser.Parse();

        var res = new Dictionary<string, object>();
        foreach (var x in doc.Root.Attributes.Where(x => !res.ContainsKey(x.Name) && x.Name != "Text"))
          res.Add(x.Name, x.Value);
        res.Add("Text", doc.Root.Text);
        return new[] {res};
      }
      catch
      {
        try
        {
          var context = new ParserContext(file) {Encoding = Configuration.Encoding};
          var parser = ParserFactory.CreateDocument(context);
          var doc = parser.Parse();

          return new[]
          {
            new Dictionary<string, object>
            {
              {"Header", doc.Header},
              {"Footer", doc.Footer},
              {"Text", string.Join(" ", doc.Paragraphs.Select(paragraph => paragraph.Text))}
            }
          };
        }
        catch
        {
          try
          {
            var context = new ParserContext(file) {Encoding = Configuration.Encoding};
            var parser = ParserFactory.CreateText(context);
            var doc = parser.Parse();

            return new[]
            {
              new Dictionary<string, object>
              {
                {"Text", doc}
              }
            };
          }
          catch
          {
            return null;
          }
        }
      }
    }
  }
}