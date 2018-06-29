using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Kaf.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.Kaf.Serializer
{
  public class KafSerializer : AbstractGenericSerializer<KAF>
  {
    protected override void DeserializePostValidation(KAF obj, string path)
    {
    }

    protected override void DeserializePreValidation(string path)
    {
    }

    protected override void SerializePostValidation(KAF obj, string path)
    {
    }

    protected override void SerializePreValidation(KAF obj, string path)
    {
    }
  }
}