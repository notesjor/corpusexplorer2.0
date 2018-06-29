#region

using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.SlashA.Model;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.SlashA.Serializer
{
  // ReSharper disable once MemberCanBeInternal
  public sealed class SlashASerializer : AbstractGenericSerializer<DSpin>
  {
    protected override void DeserializePostValidation(DSpin obj, string path)
    {
    }

    protected override void DeserializePreValidation(string path)
    {
      CheckFileExtension(path, "xml");
    }

    protected override void SerializePostValidation(DSpin obj, string path)
    {
    }

    protected override void SerializePreValidation(DSpin obj, string path)
    {
      CheckFileExtension(path, "xml");
    }
  }
}