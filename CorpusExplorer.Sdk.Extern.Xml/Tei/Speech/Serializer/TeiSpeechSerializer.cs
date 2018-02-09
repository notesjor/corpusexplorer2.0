#region

using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Tei.Speech.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Speech.Serializer
{
  public sealed class TeiSpeechSerializer : AbstractGenericSerializer<TEI>
  {
    protected override void DeserializePostValidation(TEI obj, string path) { }

    protected override void DeserializePreValidation(string path) { CheckFileExtension(path, "xml"); }

    protected override void SerializePostValidation(TEI obj, string path) { }

    protected override void SerializePreValidation(TEI obj, string path) { CheckFileExtension(path, "xml"); }
  }
}