using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.DraCor
{
  public class DraCorFullScraper : AbstractScraper
  {
    public override string DisplayName => "DraCorFull";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      try
      {
        var html = new HtmlAgilityPackHelper(file);
        var doc = new Dictionary<string, object>
        {
          {"Titel", GetTitle(html)?.Trim()},
          {"Autor", GetAuthor(html)?.Trim()},
          {"Datum (Druck)", GetDatePrint(html)?.Trim()},
          {"Datum (Premiere)", GetDatePremiere(html)?.Trim()},
          {"Text", html.GetBodyText()?.Trim().Replace("\t", " ").Replace("  ", " ").Replace("  ", " ")}
        };

        return new[] { doc };
      }
      catch
      {
        // ignore
      }

      return null;
    }

    private string GetDatePremiere(HtmlAgilityPackHelper html)
    {
      var tmp = html.GetNodes("//event[@type=\"premiere\"]")?.FirstOrDefault();
      return tmp?.GetAttributeValue("when", "");
    }

    private string GetDatePrint(HtmlAgilityPackHelper html)
    {
      var tmp = html.GetNodes("//event[@type=\"print\"]")?.FirstOrDefault();
      return tmp?.GetAttributeValue("when", "");
    }

    private string GetAuthor(HtmlAgilityPackHelper html)
    {
      var tmp = html.GetNodes("//author/persname");
      return tmp == null ? "" : string.Join("; ", tmp.Select(x => string.Join(" ", x.InnerText)));
    }

    private string GetTitle(HtmlAgilityPackHelper html)
    {
      var tmp = html.GetNodes("//title");
      return tmp == null ? "" : string.Join(" - ", tmp.Select(x=>string.Join(" ", x.InnerText)));
    }
  }
}
