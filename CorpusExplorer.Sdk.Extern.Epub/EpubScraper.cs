using System.Collections.Generic;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;

namespace CorpusExplorer.Sdk.Extern.Epub
{
  public class EpubScraper : AbstractScraper
  {
    public override string DisplayName => "EPUB-Scraper";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      try
      {
        var epub = new eBdb.EpubReader.Epub(file);
        return new[]
        {
          new Dictionary<string, object>
          {
            {"Text", epub.GetContentAsPlainText()},
            {"Autoren", epub.Contributer != null ? string.Join("; ", epub.Contributer) : ""},
            {"Herausgeber", epub.Publisher != null ? string.Join("; ", epub.Publisher) : ""},
            {"Beschreibung", epub.Description != null ? string.Join(" ", epub.Description) : ""},
            {"Titel", epub.Title != null ? string.Join(" ", epub.Title) : ""},
            {"Betreff", epub.Subject != null ? string.Join(" ", epub.Subject) : ""},
            {"Ersteller", epub.Creator != null ? string.Join(" ", epub.Creator) : ""},
            {"Quelle", epub.Source != null ? string.Join(" ", epub.Source) : ""},
            {"UUID", epub.UUID}
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