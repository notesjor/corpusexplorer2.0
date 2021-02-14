using System.Collections.Generic;
using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Cleaner;
using CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.Model;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v1
{
  public class BundestagPlenarprotokolleScraper : AbstractXmlScraper
  {
    public override string DisplayName => "Bundestag Plenarprotokolle";
    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      var model = XmlSerializerHelper.Deserialize<DOKUMENT>(file);
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