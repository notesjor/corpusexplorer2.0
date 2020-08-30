using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;

namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2.Serializer
{
  public class BundestagPlenarprotokolleSerializer : AbstractGenericSerializer<dbtplenarprotokoll>
  {
    protected override void DeserializePostValidation(dbtplenarprotokoll obj, string path)
    {
    }

    protected override void DeserializePreValidation(string path)
    {
      CheckFileExtension(path, ".xml");
    }

    protected override void SerializePostValidation(dbtplenarprotokoll obj, string path)
    {
    }

    protected override void SerializePreValidation(dbtplenarprotokoll obj, string path)
    {
      CheckFileExtension(path, ".xml");
    }
  }
}
