using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.SubSub.Head;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Serializer.SubSub.Head
{
  public class SubSubHeadSerializer : AbstractGenericSerializer<idsHeader>
  {
    protected override void DeserializePostValidation(idsHeader obj, string path) { }

    protected override void DeserializePreValidation(string path) { }

    protected override void SerializePostValidation(idsHeader obj, string path) { }

    protected override void SerializePreValidation(idsHeader obj, string path) { }
  }
}
