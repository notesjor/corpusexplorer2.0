using CorpusExplorer.Sdk.Extern.Wiki.WikipediaMetaTalk.Model;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;

namespace CorpusExplorer.Sdk.Extern.Wiki.WikipediaMetaTalk.Serializer
{
  public class WikipediaMetaTalkSerializer : AbstractGenericSerializer<page>
  {
    protected override void DeserializePostValidation(page obj, string path)
    {
    }

    protected override void DeserializePreValidation(string path)
    {
    }

    protected override void SerializePostValidation(page obj, string path)
    {
    }

    protected override void SerializePreValidation(page obj, string path)
    {
    }
  }
}