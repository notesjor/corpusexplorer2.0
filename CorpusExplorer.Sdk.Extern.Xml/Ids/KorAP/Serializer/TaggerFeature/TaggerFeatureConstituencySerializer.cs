using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Serializer.TaggerFeature
{
  public class TaggerFeatureConstituencySerializer : AbstractGenericSerializer<Model.TaggerFeature.Constituency.layer>
  {
    protected override void DeserializePostValidation(Model.TaggerFeature.Constituency.layer obj, string path) { }

    protected override void DeserializePreValidation(string path) { }

    protected override void SerializePostValidation(Model.TaggerFeature.Constituency.layer obj, string path) { }

    protected override void SerializePreValidation(Model.TaggerFeature.Constituency.layer obj, string path) { }
  }
}
