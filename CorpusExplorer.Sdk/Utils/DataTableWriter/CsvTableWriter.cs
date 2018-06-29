using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Utils.DataTableWriter
{
  public class CsvTableWriter : AbstractTableWriter
  {
    public override string TableWriterTag => "F:CSV";

    public override void WriteTable(DataTable table)
    {
      WriteOutput($"{string.Join(";", from DataColumn x in table.Columns select EnsureValue(x.ColumnName))}\r\n");
      foreach (DataRow x in table.Rows)
      {
        var r = new string[table.Columns.Count];
        for (var i = 0; i < table.Columns.Count; i++)
          r[i] = x[i] == null ? "\"\"" : $"\"{EnsureValue(x[i].ToString())}\"";

        WriteOutput($"{string.Join(";", r)}\r\n");
      }
    }

    private string EnsureValue(string value)
    {
      return value.Replace("\"", "''").Replace("\t", "").Replace("\r\n", " ").Replace("\r", " ").Replace("\n", " ")
        .Replace("  ", " ").Replace("  ", " ").Replace("  ", " ");
    }
  }
}