#region

using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Binary.Abstract;
using CorpusExplorer.Sdk.Extern.Binary.Excel.Kidko.Model;
using CorpusExplorer.Sdk.Extern.Binary.Excel.Universal.Reader;

#endregion

namespace CorpusExplorer.Sdk.Extern.Binary.Excel.Kidko.Reader
{
  public sealed class ExcelKidkoDataReader : AbstractGenericDataReader<KidkoItem>
  {
    public override IEnumerable<KidkoItem> ReadData(string path)
    {
      var header = new[]
      {
        "Kategorie",
        "Herkunft/Medienbeitrag, auf den sich die Texte beziehen",
        "Typ",
        "Reihenfolge (innerhalb eines Diskussions-Threads)",
        "Name/Sigle",
        "Datum",
        "Text"
      };

      var reader = new ExcelUniversalDataReader(header);
      var items = reader.ReadData(path);

      return (from item in items
        where !string.IsNullOrEmpty(item["Text"])
        select
          new KidkoItem
          {
            Category = item["Kategorie"],
            DateString = item["Datum"],
            DiscussionTimestamp = item["Reihenfolge (innerhalb eines Diskussions-Threads)"],
            Name = item["Name/Sigle"],
            Source = item["Herkunft/Medienbeitrag, auf den sich die Texte beziehen"],
            Text = item["Text"],
            Type = item["Typ"]
          }).ToList();
    }
  }
}