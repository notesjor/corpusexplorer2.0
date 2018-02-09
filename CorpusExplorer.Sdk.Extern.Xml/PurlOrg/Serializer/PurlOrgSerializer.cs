using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.PurlOrg.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.PurlOrg.Serializer
{
  public class PurlOrgSerializer : AbstractGenericSerializer<collection>
  {
    protected override void DeserializePostValidation(collection obj, string path) { }

    protected override void DeserializePreValidation(string path) { CheckFileExtension(path, "xml"); }

    protected override void SerializePostValidation(collection obj, string path) { }

    protected override void SerializePreValidation(collection obj, string path) { CheckFileExtension(path, "xml"); }
  }
}