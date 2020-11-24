#region

using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Simple.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Simple.Serializer
{
  public sealed class ExmaraldaExbSerializer : AbstractGenericSerializer<basictranscription>
  {
    protected override void DeserializePostValidation(basictranscription obj, string path)
    {
    }

    protected override void DeserializePreValidation(string path)
    {
      CheckFileExtension(path, "exb");
    }

    protected override void SerializePostValidation(basictranscription obj, string path)
    {
    }

    protected override void SerializePreValidation(basictranscription obj, string path)
    {
      CheckFileExtension(path, "exb");
    }
  }
}