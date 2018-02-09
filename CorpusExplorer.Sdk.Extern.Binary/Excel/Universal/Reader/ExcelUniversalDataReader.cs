#region

using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Binary.Abstract;
using CorpusExplorer.Sdk.Extern.Binary.Excel.Universal.Helper;

#endregion

namespace CorpusExplorer.Sdk.Extern.Binary.Excel.Universal.Reader
{
  public sealed class ExcelUniversalDataReader : AbstractGenericDataReader<Dictionary<string, string>>
  {
    private readonly HashSet<string> _columnFilter;
    private readonly int _tableIndex;

    public ExcelUniversalDataReader(IEnumerable<string> columnFilter = null, int tableIndex = 0)
    {
      _columnFilter = columnFilter == null ? null : new HashSet<string>(columnFilter);
      _tableIndex = tableIndex;
    }

    public override IEnumerable<Dictionary<string, string>> ReadData(string path)
    {
      var data = ExcelUniversalDataSetHelper.GetDataSet(path, false);
      var table = data.Tables[_tableIndex];

      // Erzeugt ein Dictionary (Key = Index der Spalte / Value = Name der Spalte)
      var header = table.Rows[0].ItemArray.ToArray();
      var dic = new Dictionary<int, string>();
      for (var i = 0; i < header.Length; i++)
      {
        var head = header[i].ToString();

        // Column-Filter
        if (_columnFilter != null)
          if (!_columnFilter.Contains(head))
            continue;

        // Filter um spätere Fehler zu vermeiden.
        if (string.IsNullOrEmpty(head))
          continue;
        if (dic.Any(x => x.Value == head))
          continue;

        dic.Add(i, head);
      }

      // Lese Datensätze ein
      var res = new List<Dictionary<string, string>>();
      for (var i = 1; i < table.Rows.Count; i++)
      {
        var row = table.Rows[i];
        res.Add(dic.ToDictionary(col => col.Value, col => row[col.Key].ToString()));
      }

      return res;
    }
  }
}