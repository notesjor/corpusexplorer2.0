using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Dta.Basisformat.Model;
using CorpusExplorer.Sdk.Extern.Xml.Dta.Basisformat.Serializer;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Basisformat
{
  public class DtaBasisformatScraper : AbstractGenericXmlSerializerFormatScraper<TEI>
  {
    public override string DisplayName => "DTA-Basisformat";
    protected override AbstractGenericSerializer<TEI> Serializer => new DtaBasisformatSerializer();

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(string file, TEI model)
    {
      return new[]
      {
        new Dictionary<string, object>
        {
          {
            "IDNO",
            SafeJoin(
              () =>
                model?.teiHeader?.fileDesc?.publicationStmt?.idno?.idno1?.FirstOrDefault(idno => idno.type == "URLWeb")?.Text)
          },
          {
            "URN",
            SafeJoin(
              () =>
                model?.teiHeader?.fileDesc?.publicationStmt?.idno?.idno1?.FirstOrDefault(idno => idno.type == "URN")?.Text)
          },
          {
            "Titel",
            SafeJoin(
              () =>
                model?.teiHeader?.fileDesc?.sourceDesc?.bibl?.Text)
          },
          {
            "Autoren",
            SafeJoin(
              () =>
                model?.teiHeader?.fileDesc?.sourceDesc?.biblFull?.titleStmt?.author?.Select(x => x.persName.@ref),
              "|")
          }
        }
      };
    }

    private string SafeJoin(Func<IEnumerable<string>> call, string separator = " ")
    {
      try
      {
        return string.Join(separator, call());
      }
      catch
      {
        return "";
      }
    }
  }
}