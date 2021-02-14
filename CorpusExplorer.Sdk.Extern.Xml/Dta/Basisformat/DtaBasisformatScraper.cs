using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Dta.Basisformat.Model;
using CorpusExplorer.Sdk.Extern.Xml.Helper;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Basisformat
{
  public class DtaBasisformatScraper : AbstractXmlScraper
  {
    public override string DisplayName => "DTA-Basisformat";
    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var model = XmlSerializerHelper.Deserialize<TEI>(file);
      var helper = new HtmlAgilityPackHelper(file);
      helper.RemoveNodes(new[] {"//pb", "//fw", "//table", "//figure", "//note"});

      return new[]
      {
        new Dictionary<string, object>
        {
          {
            "IDNO",
            TextHelper.SafeJoin(() => model?.teiHeader?.fileDesc?.publicationStmt?.idno?.idno1?.FirstOrDefault(idno => idno.type == "URLWeb")?.Text)
          },
          {
            "URN",
            TextHelper.SafeJoin(() => model?.teiHeader?.fileDesc?.publicationStmt?.idno?.idno1?.FirstOrDefault(idno => idno.type == "URN")?.Text)
          },
          {
            "Titel",
            TextHelper.SafeJoin(() => model?.teiHeader?.fileDesc?.sourceDesc?.bibl?.Text, " - ")
          },
          {
            "Autoren",
            TextHelper.SafeJoin(() =>model?.teiHeader?.fileDesc?.sourceDesc?.biblFull?.titleStmt?.author?.Select(x => x.persName.@ref), "; ")
          },
          {
            "Sprache",
            model?.teiHeader?.profileDesc?.langUsage?.language?.Value
          },
          {
            "DTA-Main",
            model?.teiHeader?.profileDesc?.textClass?.FirstOrDefault(
              classCode => classCode.scheme == "http://www.deutschestextarchiv.de/doku/klassifikation#dtamain")?.Value
          },
          {
            "DTA-Sub",
            model?.teiHeader?.profileDesc?.textClass?.FirstOrDefault(
              classCode => classCode.scheme == "http://www.deutschestextarchiv.de/doku/klassifikation#dtasub")?.Value
          },
          {
          "DTA-Korpus",
            TextHelper.SafeJoin(() =>model?.teiHeader?.profileDesc?.textClass?.Where(
            classCode => classCode.scheme == "http://www.deutschestextarchiv.de/doku/klassifikation#DTACorpus")
            .Select(x=> x.Value), " - ")
          },
          {
            "Text",
            helper.GetBodyText("//text")
          }
        }
      };
    }
  }
}