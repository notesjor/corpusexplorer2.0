#region

using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Extern.Json.Abstract
{
  public abstract class AbstractGenericJsonFormatScraper<T> : AbstractScraper
  {
    protected abstract AbstractGenericDataReader<T> DataReader { get; }

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      try
      {
        return ScrapDocuments(DataReader.ReadData(file));
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
        return null;
      }
    }

    protected abstract IEnumerable<Dictionary<string, object>> ScrapDocuments(IEnumerable<T> model);
  }
}