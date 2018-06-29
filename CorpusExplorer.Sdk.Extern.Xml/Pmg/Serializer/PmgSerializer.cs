using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Pmg.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.Pmg.Serializer
{
  public class PmgSerializer : AbstractGenericSerializer<artikelliste>
  {
    protected override void DeserializePostValidation(artikelliste obj, string path)
    {
    }

    protected override void DeserializePreValidation(string path)
    {
      CheckFileExtension(path, "xml");
    }

    protected override void SerializePostValidation(artikelliste obj, string path)
    {
    }

    protected override void SerializePreValidation(artikelliste obj, string path)
    {
      CheckFileExtension(path, "xml");
    }
  }
}