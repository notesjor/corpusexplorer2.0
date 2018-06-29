using System.Collections.Generic;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Cleaner;
using CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Drucksachen.Model;
using CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Drucksachen.Serializer;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Drucksachen
{
  public class BundestagDrucksachenScraper : AbstractGenericXmlSerializerFormatScraper<DOKUMENT>
  {
    public override string DisplayName => "Bundestag Drucksachen";
    protected override AbstractGenericSerializer<DOKUMENT> Serializer => new BundestagDrucksachenSerializer();

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(string file, DOKUMENT model)
    {
      return new[]
      {
        new Dictionary<string, object>
        {
          {"Wahlperiode", int.Parse(model.WAHLPERIODE)},
          {"Dokumentart", model.DOKUMENTART},
          {"NR", model.NR},
          {"DRS-Typ", model.DRS_TYP},
          {"Datum", DateTimeHelper.Parse(model.DATUM, "dd.MM.yyyy")},
          {"Titel", model.TITEL},
          {"Text", model.TEXT.Clean()},
          {"K-Urheber", MakeNameList(model.K_URHEBER)},
          {"P-Urheber", MakeNameList(model.P_URHEBER)}
        }
      };
    }

    private string MakeNameList(string[] authors)
    {
      return authors == null ? string.Empty : string.Join("; ", authors);
    }
  }
}