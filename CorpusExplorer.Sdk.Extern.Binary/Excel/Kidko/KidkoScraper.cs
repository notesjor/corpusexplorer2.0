#region

using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Binary.Abstract;
using CorpusExplorer.Sdk.Extern.Binary.Excel.Kidko.Model;
using CorpusExplorer.Sdk.Extern.Binary.Excel.Kidko.Reader;

#endregion

namespace CorpusExplorer.Sdk.Extern.Binary.Excel.Kidko
{
  public sealed class KidkoScraper : AbstractGenericBinaryFormatScraper<KidkoItem>
  {
    public override string DisplayName => "KiDKo/E";
    protected override AbstractGenericDataReader<KidkoItem> DataReader => new ExcelKidkoDataReader();

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(IEnumerable<KidkoItem> model)
    {
      return
        model.Select(
          item =>
            new Dictionary<string, object>
            {
              {"Kategorie", item.Category},
              {"Datum (original)", item.DateString},
              {"Datum (casted)", item.Date},
              {"Diskussions Nr.", item.DiscussionTimestamp},
              {"Name", item.Name},
              {"Quelle", item.Source},
              {"Text", item.Text},
              {"Typ", item.Type}
            });
    }
  }
}