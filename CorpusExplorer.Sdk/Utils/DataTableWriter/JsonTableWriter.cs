using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Utils.DataTableWriter
{
  public class JsonTableWriter : AbstractTableWriter
  {
    public override string TableWriterTag => "F:JSON";
    public override string MimeType => "application/json";

    protected override void WriteHead(DataTable table)
    {
      WriteOutput("[");
    }

    protected override void WriteBody(string tid, DataTable table)
    {
      var columns = new List<KeyValuePair<string, Type>> { new KeyValuePair<string, Type>("tid", typeof(string)) };
      foreach (DataColumn c in table.Columns)
        columns.Add(new KeyValuePair<string, Type>(c.ColumnName, c.DataType));

      var tmp = new StringBuilder();
      tmp.Append("{");
      foreach (var c in columns)
        tmp.Append(c.Value == typeof(string) ? $"\"{c.Key}\": \"{{{c.Key}}}\"," : $"\"{c.Key}\": {{{c.Key}}},");
      tmp.Remove(tmp.Length - 1, 1);
      tmp.Append("},");
      var template = tmp.ToString();
      tmp.Clear();

      var marks = columns.ToDictionary(x => x.Key, x => $"{{{x.Key}}}");

      var stb = new StringBuilder();
      var slo = new object();

      Parallel.ForEach(table.AsEnumerable(), row =>
      {
        var r = new StringBuilder(template);
        foreach (var column in columns)
        {
          var val = column.Key == "tid" ? tid : row[column.Key];
          if (val == null)
            r.Replace(marks[column.Key], column.Value == typeof(string) ? string.Empty : "null");
          else
            r.Replace(marks[column.Key],
                      column.Value == typeof(string)
                        ? val.ToString().Replace("\"", "\\\"")
                        : val.ToString().Replace(",", "."));
        }

        lock (slo)
          stb.Append(r);
      });

      stb.Remove(stb.Length - 1, 1);

      WriteOutput(stb.ToString());
      WriteOutput(",");
    }

    protected override void WriteFooter()
    {
      OutputStream.Seek(-1, SeekOrigin.End);
      WriteOutput("]");
    }

    public override AbstractTableWriter Clone(Stream stream)
      => new JsonTableWriter { OutputStream = stream };
  }
}