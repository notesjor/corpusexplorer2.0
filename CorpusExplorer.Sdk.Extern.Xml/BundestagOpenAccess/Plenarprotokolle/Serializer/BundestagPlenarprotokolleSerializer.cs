using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.Serializer
{
  public class BundestagPlenarprotokolleSerializer : AbstractGenericSerializer<DOKUMENT>
  {
    protected override void DeserializePostValidation(DOKUMENT obj, string path)
    {
    }

    protected override void DeserializePreValidation(string path)
    {
      CheckFileExtension(path, ".xml");
    }

    protected override void SerializePostValidation(DOKUMENT obj, string path)
    {
    }

    protected override void SerializePreValidation(DOKUMENT obj, string path)
    {
      CheckFileExtension(path, ".xml");
    }
  }
}