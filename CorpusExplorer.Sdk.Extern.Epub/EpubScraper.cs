using System.Collections.Generic;
using System.Text;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;
using HtmlAgilityPack;
using VersOne.Epub;

namespace CorpusExplorer.Sdk.Extern.Epub
{
  public class EpubScraper : AbstractScraper
  {
    public override string DisplayName => "EPUB-Scraper";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      try
      {
        var epub = EpubReader.ReadBook(file);
        return new[]
        {
          new Dictionary<string, object>
          {
            {"Text", GetText(epub)},
            {"Autoren", 
              epub.AuthorList == null ?
                epub.Author :
                string.Join("; ", epub.AuthorList)},
            {"Titel", epub.Title},
            {"Dateiname", file}
          }
        };
      }
      catch
      {
        return null;
      }
    }

    private string GetText(EpubBook epub)
    {
      var stb = new StringBuilder();

      foreach (var textContentFile in epub.ReadingOrder)
      {
        var doc = new HtmlDocument();
        doc.LoadHtml(textContentFile.Content);
        stb.AppendLine(doc.DocumentNode.SelectSingleNode("//body").InnerText);
      }

      return stb.ToString();
    }
  }
}