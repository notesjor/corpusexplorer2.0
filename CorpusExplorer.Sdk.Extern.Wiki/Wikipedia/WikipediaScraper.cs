#region

using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Extern.Wiki.Wikipedia.Model;
using CorpusExplorer.Sdk.Extern.Wiki.Wikipedia.Serializer;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;

#endregion

namespace CorpusExplorer.Sdk.Extern.Wiki.Wikipedia
{
  public sealed class WikipediaScraper : AbstractGenericXmlSerializerFormatScraper<page>
  {
    private readonly WikipediaCleanup _integratedWikiSyntaxCleanup = new WikipediaCleanup();
    public override string DisplayName => "Wikipedia-DUMP";

    protected override AbstractGenericSerializer<page> Serializer => new WikipediaFullDumpSerializer();

    public IEnumerable<Dictionary<string, object>> ScrapDocumentsInline(page model)
    {
      return ScrapDocuments(null, model);
    }

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(string file, page model)
    {
      try
      {
        if (model.redirect == null &&
            model.revision != null)
        {
          var rev = model.revision;
          if (rev?.text?.Text == null)
            return null;

          var doc = new Dictionary<string, object>
          {
            // Eigenschaften der Seite
            {"Id", model.id},
            {"Titel", model.title},
            {"Text", _integratedWikiSyntaxCleanup.ExecuteInline(string.Join(" ", rev.text.Text))},
            {"Zeitstempel", rev.timestamp}
          };
          return new[] {new Dictionary<string, object>(doc)};
        }
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
      }

      return null;
    }
  }
}