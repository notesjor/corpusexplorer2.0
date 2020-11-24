#region

using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Simple.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Simple.Serializer
{
  public sealed class ExmaraldaExsSerializer : AbstractGenericSerializer<segmentedtranscription>
  {
    protected override void DeserializePostValidation(segmentedtranscription obj, string path)
    {
    }

    protected override void DeserializePreValidation(string path)
    {
      CheckFileExtension(path, "exs");
    }

    protected override void SerializePostValidation(segmentedtranscription obj, string path)
    {
    }

    protected override void SerializePreValidation(segmentedtranscription obj, string path)
    {
      CheckFileExtension(path, "exs");
    }
  }
}