#region

using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Binary.Abstract;
using CorpusExplorer.Sdk.Extern.Binary.Excel.Universal.Reader;

#endregion

namespace CorpusExplorer.Sdk.Extern.Binary.Excel.Universal
{
  public sealed class UniversalExcelScraper : AbstractGenericBinaryFormatScraper<Dictionary<string, string>>
  {
    public override string DisplayName => "Universeller Excel™-Scraper";

    protected override AbstractGenericDataReader<Dictionary<string, string>> DataReader =>
      new ExcelUniversalDataReader();

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(
      IEnumerable<Dictionary<string, string>> model)
    {
      return
        model.Select(
          m =>
            new Dictionary<string, object>(
              m.ToDictionary<KeyValuePair<string, string>, string, object>(
                x => x.Key,
                x => x.Value)));
    }
  }
}