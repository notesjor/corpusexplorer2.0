using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Serializer.TaggerFeature
{
  public class TaggerFeatureDependencySerializer : AbstractGenericSerializer<Model.TaggerFeature.Dependency.layer>
  {
    protected override void DeserializePostValidation(Model.TaggerFeature.Dependency.layer obj, string path) { }

    protected override void DeserializePreValidation(string path) { }

    protected override void SerializePostValidation(Model.TaggerFeature.Dependency.layer obj, string path) { }

    protected override void SerializePreValidation(Model.TaggerFeature.Dependency.layer obj, string path) { }
  }
}