using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Drucksachen.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Drucksachen.Serializer
{
  public class BundestagDrucksachenSerializer : AbstractGenericSerializer<DOKUMENT>
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