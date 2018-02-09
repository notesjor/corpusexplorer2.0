#region

using System.Collections.Generic;
using CorpusExplorer.Sdk.Extern.Binary.Abstract;
using CorpusExplorer.Sdk.Extern.Binary.ListOfScrapDocuments.Reader;

#endregion

namespace CorpusExplorer.Sdk.Extern.Binary.ListOfScrapDocuments
{
  public sealed class ListOfScrapDocumentScraper : AbstractGenericBinaryFormatScraper<Dictionary<string, object>>
  {
    protected override AbstractGenericDataReader<Dictionary<string, object>> DataReader
    {
      get { return new ListOfScrapDocumentsReader(); }
    }

    public override string DisplayName { get { return "ScrapDocument-DUMP"; } }

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(
      IEnumerable<Dictionary<string, object>> model)
    {
      return model;
    }
  }
}