using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.AnnoBase.Structure;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Serializer.AnnoBase.Structure
{
  public class AnnoBaseStructureSerializer : AbstractGenericSerializer<layer>
  {
    protected override void DeserializePostValidation(layer obj, string path) { }

    protected override void DeserializePreValidation(string path) { }

    protected override void SerializePostValidation(layer obj, string path) { }

    protected override void SerializePreValidation(layer obj, string path) { }
  }
}
