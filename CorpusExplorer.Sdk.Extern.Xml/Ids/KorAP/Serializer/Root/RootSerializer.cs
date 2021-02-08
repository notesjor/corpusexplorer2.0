using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.Root;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Serializer.Root
{
  public class RootSerializer : AbstractGenericSerializer<idsHeader>
  {
    protected override void DeserializePostValidation(idsHeader obj, string path) { }

    protected override void DeserializePreValidation(string path) { }

    protected override void SerializePostValidation(idsHeader obj, string path) { }

    protected override void SerializePreValidation(idsHeader obj, string path) { }
  }
}
