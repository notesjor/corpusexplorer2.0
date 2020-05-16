#region

using System.Collections.Generic;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Tiger.Scraper.Model;
using CorpusExplorer.Sdk.Extern.Xml.Tiger.Scraper.Serializer;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tiger.Scraper
{
  public sealed class TigerScraper : AbstractGenericXmlSerializerFormatScraper<corpus>
  {
    public override string DisplayName => "TiGER-XML (*.xml)";

    protected override AbstractGenericSerializer<corpus> Serializer => new TigerSerializer();

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(string file, corpus model)
    {
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