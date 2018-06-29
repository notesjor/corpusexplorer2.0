using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Gate.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.Gate.Serializer
{
  public class GateSerializer : AbstractGenericSerializer<GateDocument>
  {
    protected override void DeserializePostValidation(GateDocument obj, string path)
    {
    }

    protected override void DeserializePreValidation(string path)
    {
      CheckFileExtension(path, ".xml");
    }

    protected override void SerializePostValidation(GateDocument obj, string path)
    {
    }

    protected override void SerializePreValidation(GateDocument obj, string path)
    {
      CheckFileExtension(path, ".xml");
    }
  }
}