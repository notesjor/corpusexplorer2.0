using System.Data;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Utils.DataTableWriter
{
  public class CsvTableWriter : AbstractTableWriter
  {
    public override string TableWriterTag => "F:CSV";
    public override string MimeType => "text/csv";

    protected override void WriteHead(DataTable table)
    {
      WriteOutput($"{string.Join(";", from DataColumn x in table.Columns select EnsureValue(x.ColumnName))}\r\n");
    }

    protected override void WriteBody(DataTable table)
    {
      foreach (DataRow x in table.Rows)
      {
        var r = new string[table.Columns.Count];
        for (var i = 0; i < table.Columns.Count; i++)
          r[i] = x[i] == null ? "\"\"" : x[i] is string ? $"\"{EnsureValue(x[i].ToString())}\"" : x[i].ToString().Replace(",", ".");

        WriteOutput($"{string.Join(";", r)}\r\n");
      }
    }

    protected override void WriteFooter() { }

    public override AbstractTableWriter Clone(Stream stream)
      => new CsvTableWriter { OutputStream = stream };

    private string EnsureValue(string value)
    {
      return value.Replace("\"", "''").Replace("\t", "").Replace("\r\n", " ").Replace("\r", " ").Replace("\n", " ")
        .Replace("  ", " ").Replace("  ", " ").Replace("  ", " ");
    }
  }
}