using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Shakespeare.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.Shakespeare.Serializer
{
  public class ShakespeareSerializer : AbstractGenericSerializer<text>
  {
    protected override void DeserializePostValidation(text obj, string path)
    {
      
    }

    protected override void DeserializePreValidation(string path)
    {
      CheckFileExtension(path, "xml");
    }

    protected override void SerializePostValidation(text obj, string path)
    {
      
    }

    protected override void SerializePreValidation(text obj, string path)
    {
      CheckFileExtension(path, "xml");
    }
  }
}
