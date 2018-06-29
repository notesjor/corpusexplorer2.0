#region

using System.Collections.Generic;
using CorpusExplorer.Sdk.Extern.Binary.Abstract;
using CorpusExplorer.Sdk.Extern.Binary.ListOfScrapDocuments.Reader;

#endregion

namespace CorpusExplorer.Sdk.Extern.Binary.ListOfScrapDocuments
{
  public sealed class ListOfScrapDocumentScraper : AbstractGenericBinaryFormatScraper<Dictionary<string, object>>
  {
    public override string DisplayName => "ScrapDocument-DUMP";

    protected override AbstractGenericDataReader<Dictionary<string, object>> DataReader =>
      new ListOfScrapDocumentsReader();

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(
      IEnumerable<Dictionary<string, object>> model)
    {
      return model;
    }
  }
}