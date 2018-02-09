#region

using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Tiger.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tiger.Serializer
{
  public sealed class TigerSerializer : AbstractGenericSerializer<corpus>
  {
    protected override void DeserializePostValidation(corpus obj, string path) { }

    protected override void DeserializePreValidation(string path) { CheckFileExtension(path, "xml"); }

    protected override void SerializePostValidation(corpus obj, string path) { }

    protected override void SerializePreValidation(corpus obj, string path) { CheckFileExtension(path, "xml"); }
  }
}