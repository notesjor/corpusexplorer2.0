#region

using System.Collections.Generic;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Extern.Binary.Abstract
{
  public abstract class AbstractGenericBinaryFormatScraper<T> : AbstractScraper
  {
    protected abstract AbstractGenericDataReader<T> DataReader { get; }

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      return ScrapDocuments(DataReader.ReadData(file));
    }

    protected abstract IEnumerable<Dictionary<string, object>> ScrapDocuments(IEnumerable<T> model);
  }
}