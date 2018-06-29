#region

using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Tei.Bare.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Bare.Serializer
{
  public sealed class TeiBareSerializer : AbstractGenericSerializer<TEI>
  {
    protected override void DeserializePostValidation(TEI obj, string path)
    {
    }

    protected override void DeserializePreValidation(string path)
    {
      CheckFileExtension(path, "xml");
    }

    protected override void SerializePostValidation(TEI obj, string path)
    {
    }

    protected override void SerializePreValidation(TEI obj, string path)
    {
      CheckFileExtension(path, "xml");
    }
  }
}