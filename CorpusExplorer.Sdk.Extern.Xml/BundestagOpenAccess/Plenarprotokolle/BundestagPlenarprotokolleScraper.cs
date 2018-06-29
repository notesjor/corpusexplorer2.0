using System.Collections.Generic;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Cleaner;
using CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.Model;
using CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.Serializer;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle
{
  public class BundestagPlenarprotokolleScraper : AbstractGenericXmlSerializerFormatScraper<DOKUMENT>
  {
    public override string DisplayName => "Bundestag Plenarprotokolle";
    protected override AbstractGenericSerializer<DOKUMENT> Serializer => new BundestagPlenarprotokolleSerializer();

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(string file, DOKUMENT model)
    {
      return new[]
      {
        new Dictionary<string, object>
        {
          {"Wahlperiode", int.Parse(model.WAHLPERIODE)},
          {"Dokumentart", model.DOKUMENTART},
          {"NR", model.NR},
          {"Datum", DateTimeHelper.Parse(model.DATUM, "dd.MM.yyyy")},
          {"Titel", model.TITEL},
          {"Text", model.TEXT.Clean()}
        }
      };
    }
  }
}