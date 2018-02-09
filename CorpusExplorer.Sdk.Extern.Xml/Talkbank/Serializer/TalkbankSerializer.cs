#region

using CorpusExplorer.Sdk.Extern.Xml.Abstract;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Talkbank.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Talkbank.Serializer
{
  // ReSharper disable once MemberCanBeInternal
  public sealed class TalkbankSerializer : AbstractGenericSerializer<CHAT>
  {
    protected override void DeserializePostValidation(CHAT obj, string path) { }

    protected override void DeserializePreValidation(string path) { CheckFileExtension(path, "xml"); }

    protected override void SerializePostValidation(CHAT obj, string path) { }

    protected override void SerializePreValidation(CHAT obj, string path) { CheckFileExtension(path, "xml"); }
  }
}