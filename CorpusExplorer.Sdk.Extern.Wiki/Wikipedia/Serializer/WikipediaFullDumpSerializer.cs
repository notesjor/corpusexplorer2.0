#region

using CorpusExplorer.Sdk.Extern.Wiki.Wikipedia.Model;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;

#endregion

namespace CorpusExplorer.Sdk.Extern.Wiki.Wikipedia.Serializer
{
  // ReSharper disable once UnusedMember.Global
  public class WikipediaFullDumpSerializer : AbstractGenericSerializer<page>
  {
    protected override void DeserializePostValidation(page obj, string path)
    {
    }

    protected override void DeserializePreValidation(string path)
    {
      CheckFileExtension(path, "xml");
    }

    protected override void SerializePostValidation(page obj, string path)
    {
    }

    protected override void SerializePreValidation(page obj, string path)
    {
      CheckFileExtension(path, "xml");
    }
  }
}