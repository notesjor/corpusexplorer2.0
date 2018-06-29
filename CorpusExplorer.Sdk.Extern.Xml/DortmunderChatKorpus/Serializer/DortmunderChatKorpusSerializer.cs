#region

using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.DortmunderChatKorpus.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.DortmunderChatKorpus.Serializer
{
  public sealed class DortmunderChatKorpusSerializer : AbstractGenericSerializer<logfile>
  {
    protected override void DeserializePostValidation(logfile obj, string path)
    {
    }

    protected override void DeserializePreValidation(string path)
    {
      CheckFileExtension(path, "xml");
    }

    protected override void SerializePostValidation(logfile obj, string path)
    {
    }

    protected override void SerializePreValidation(logfile obj, string path)
    {
      CheckFileExtension(path, "xml");
    }
  }
}