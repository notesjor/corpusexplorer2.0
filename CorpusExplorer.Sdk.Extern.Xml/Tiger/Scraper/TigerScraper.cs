#region

using System.Collections.Generic;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Extern.Xml.Tiger.Scraper.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tiger.Scraper
{
  public sealed class TigerScraper : AbstractXmlScraper
  {
    public override string DisplayName => "TiGER-XML (*.xml)";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var model = XmlSerializerHelper.Deserialize<corpus>(file);
      var dic = new Dictionary<string, object>();

      if (model.head?.meta != null)
      {
        dic.Add("Titel", model.head.meta.name);
        dic.Add("Autor", model.head.meta.author);
        dic.Add("Datum", model.head.meta.date);
        dic.Add("Beschreibung", model.head.meta.description);
        dic.Add("Format", model.head.meta.format);
      }

      var stb = new StringBuilder();
      // Aktuell werden keine Subcorpora berücksichtigt
      foreach (
        var w in
        model.body.OfType<sentenceType>()
          .SelectMany(
            s =>
              s.graph.terminals.Select(
                  t =>
                    (from a in t.AnyAttr where a.Name == "word" select a.Value)
                    .FirstOrDefault())
                .Where(w => !string.IsNullOrEmpty(w))))
        stb.AppendFormat("{0} ", w.Trim());
      dic.Add("Text", stb.ToString().Trim());

      return new[] {dic};
    }
  }
}