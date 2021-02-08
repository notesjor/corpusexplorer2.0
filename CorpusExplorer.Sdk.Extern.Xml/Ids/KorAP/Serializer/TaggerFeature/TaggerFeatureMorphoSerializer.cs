using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Serializer.TaggerFeature
{
  public class TaggerFeatureMorphoSerializer : AbstractGenericSerializer<Model.TaggerFeature.Morpho.layer>
  {
    protected override void DeserializePostValidation(Model.TaggerFeature.Morpho.layer obj, string path) { }

    protected override void DeserializePreValidation(string path) { }

    protected override void SerializePostValidation(Model.TaggerFeature.Morpho.layer obj, string path) { }

    protected override void SerializePreValidation(Model.TaggerFeature.Morpho.layer obj, string path) { }
  }
}