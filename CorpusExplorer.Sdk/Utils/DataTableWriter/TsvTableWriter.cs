using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Utils.DataTableWriter
{
  public class TsvTableWriter : AbstractTableWriter
  {
    public override string TableWriterTag => "F:TSV";
    public override string MimeType => "text/tab-separated-values";

    protected override void WriteHead(DataTable table)
    {
      WriteOutput($"{string.Join("\t", from DataColumn x in table.Columns select EnsureValue(x.ColumnName))}\r\n");
    }

    protected override void WriteBody(DataTable table)
    {
      var cols = table.Columns.Count;
      var wlock = new object();

      Parallel.ForEach(table.AsEnumerable(), Configuration.ParallelOptions, x =>
          {
            var r = new string[cols];
            for (var i = 0; i < r.Length; i++)
              r[i] = x[i] == null ? "" :
                     x[i] is string ? EnsureValue(x[i].ToString()) :
                                      x[i].ToString().Replace(",", ".");
            var line = $"{string.Join("\t", r)}\r\n";

            lock (wlock)
              WriteOutput(line);
          });
    }

    protected override void WriteFooter()
    {
    }

    public override AbstractTableWriter Clone(Stream stream)
    {
      return new TsvTableWriter { OutputStream = stream, WriteTid = WriteTid };
    }

    private string EnsureValue(string value)
    {
      return value.Replace("\"", "''").Replace("\t", "").Replace("\r\n", " ").Replace("\r", " ").Replace("\n", " ")
                  .Replace("  ", " ").Replace("  ", " ").Replace("  ", " ");
    }
  }
}