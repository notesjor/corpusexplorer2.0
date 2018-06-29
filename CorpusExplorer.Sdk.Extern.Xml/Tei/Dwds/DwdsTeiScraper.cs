using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Tei.Dwds.Model;
using CorpusExplorer.Sdk.Extern.Xml.Tei.Dwds.Serializer;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Dwds
{
  public class DwdsTeiScraper : AbstractGenericXmlSerializerFormatScraper<TEI>

  {
    private readonly Regex _r1 = new Regex("[ ]{2,}", RegexOptions.None);

    public override string DisplayName => "SimpleBlog TEI-XML";

    protected override AbstractGenericSerializer<TEI> Serializer => new DwdsTeiSerializer();

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(string file, TEI model)
    {
      return new[]
      {
        new Dictionary<string, object>
        {
          {"Publisher", Reduce(model?.teiHeader?.fileDesc?.sourceDesc?.biblFull?.publicationStmt?.publisher?.Text)},
          {"URL", model?.teiHeader?.fileDesc?.sourceDesc?.biblFull?.publicationStmt?.idno?.Value},
          {"Datum", model?.teiHeader?.fileDesc?.sourceDesc?.biblFull?.publicationStmt?.date?.Value},
          {"Titel", Reduce(model?.teiHeader?.fileDesc?.sourceDesc?.biblFull?.seriesStmt?.title.Text)},
          {
            "Kategorie", Reduce(
              (from x in model?.teiHeader?.fileDesc?.sourceDesc?.biblFull?.seriesStmt?.biblScope
                where x.unit == "categories"
                select x.Text).FirstOrDefault())
          },
          {
            "TAGs",
            Reduce(
              (from x in model?.teiHeader?.fileDesc?.sourceDesc?.biblFull?.seriesStmt?.biblScope
                where x.unit == "tags"
                select x.Text).FirstOrDefault())
          },
          {"Text", GetText(model)}
        }
      };
    }

    private object GetText(TEI model)
    {
      if (model.group == null)
        return "";

      string xml = null;
      using (var ms = new MemoryStream())
      {
        var serializer = new XmlSerializer(typeof(TEI));
        serializer.Serialize(ms, model);
        ms.Seek(0, SeekOrigin.Begin);
        xml = Configuration.Encoding.GetString(ms.ToArray());
      }

      var doc = new HtmlDocument();
      doc.LoadHtml(xml);

      var res =
        doc.DocumentNode.ChildNodes["TEI"].ChildNodes["group"].InnerText.Replace("\r\n", " ")
          .Replace("\r", " ")
          .Replace("\n", " ");

      return _r1.Replace(res, " ").Trim();
    }

    private string Reduce(string[] lines)
    {
      if (lines == null)
        return "";
      var stb = new StringBuilder();
      foreach (var line in lines)
        stb.AppendLine(line);
      return stb.ToString();
    }
  }
}