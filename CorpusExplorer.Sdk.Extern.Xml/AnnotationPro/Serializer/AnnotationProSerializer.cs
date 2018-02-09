using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.AnnotationPro.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.AnnotationPro.Serializer
{
  // ReSharper disable once MemberCanBeInternal
  public sealed class AnnotationProSerializer : AbstractGenericZipSerializer<AnnotationSystemDataSet>
  {
    protected override string XmlManifestFilename { get { return "annotation.xml"; } }

    protected override void DeserializePostValidation(AnnotationSystemDataSet obj, string path) { }

    protected override void DeserializePreValidation(string path) { CheckFileExtension(path, "ant"); }

    protected override void SerializePostValidation(AnnotationSystemDataSet obj, string path) { }

    protected override void SerializePreValidation(AnnotationSystemDataSet obj, string path)
    {
      CheckFileExtension(path, "ant");
    }
  }
}