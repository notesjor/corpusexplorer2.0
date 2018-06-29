#region

using System.Collections.Generic;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper
{
  public abstract class AbstractGenericXmlSerializerFormatScraper<T> : AbstractScraper
    where T : class
  {
    protected abstract AbstractGenericSerializer<T> Serializer { get; }

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      return ScrapDocuments(file, Serializer.Deserialize(file));
    }

    protected abstract IEnumerable<Dictionary<string, object>> ScrapDocuments(string file, T model);
  }
}