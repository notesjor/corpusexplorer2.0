using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Extern.Xml.Tei.Dwds.Model;
using CorpusExplorer.Sdk.Extern.Xml.Tei.Dwds.Serializer;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Dwds
{
  public class DwdsTeiScraper : AbstractGenericXmlSerializerFormatScraper<TEI>
  {
    public override string DisplayName => "SimpleBlog TEI-XML";

    protected override AbstractGenericSerializer<TEI> Serializer => new DwdsTeiSerializer();

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(string file, TEI model)
    {
      var helper = new HtmlAgilityPackHelper(file);

      return new[]
      {
        new Dictionary<string, object>
        {
          {"Publisher", Reduce(model?.teiHeader?.fileDesc?.sourceDesc?.biblFull?.publicationStmt?.publisher?.Text)},
          {"URL", model?.teiHeader?.fileDesc?.sourceDesc?.biblFull?.publicationStmt?.idno?.Value},
          {"Datum", model?.teiHeader?.fileDesc?.sourceDesc?.biblFull?.publicationStmt?.date?.Value},
          {"Titel", Reduce(model?.teiHeader?.fileDesc?.sourceDesc?.biblFull?.seriesStmt?.title.Text)},
          {"Kategorie", Reduce(
              (from x in model?.teiHeader?.fileDesc?.sourceDesc?.biblFull?.seriesStmt?.biblScope
                where x.unit == "categories"
                select x.Text).FirstOrDefault())},
          {"TAGs",Reduce(
              (from x in model?.teiHeader?.fileDesc?.sourceDesc?.biblFull?.seriesStmt?.biblScope
                where x.unit == "tags"
                select x.Text).FirstOrDefault())},
          {"Text", TextHelper.RemoveMultiSpacesAndLinebreaks(helper.GetBodyText("//TEI/group"))}
        }
      };
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