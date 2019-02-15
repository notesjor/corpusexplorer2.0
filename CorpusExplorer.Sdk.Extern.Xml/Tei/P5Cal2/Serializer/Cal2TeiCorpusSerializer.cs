using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Tei.P5Cal2.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.P5Cal2.Serializer
{
  public class Cal2TeiCorpusSerializer : AbstractGenericSerializer<teiCorpus>
  {
    protected override void DeserializePostValidation(teiCorpus obj, string path)
    {
    }

    protected override void DeserializePreValidation(string path)
    {
      CheckFileExtension(path, "xml");
    }

    protected override void SerializePostValidation(teiCorpus obj, string path)
    {
    }

    protected override void SerializePreValidation(teiCorpus obj, string path)
    {
      CheckFileExtension(path, "xml");
    }
  }
}