#region

using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Extern.Wiki.Wikipedia.Model;
using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Helper;

#endregion

namespace CorpusExplorer.Sdk.Extern.Wiki.Wikipedia
{
  public sealed class WikipediaScraper : AbstractXmlScraper
  {
    private readonly WikipediaCleanup _integratedWikiSyntaxCleanup = new WikipediaCleanup();
    public override string DisplayName => "Wikipedia-DUMP";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var model = XmlSerializerHelper.Deserialize<page>(file);
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