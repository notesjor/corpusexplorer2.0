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

    protected override void WriteBody(DataTable table)
    {
      var columns = new List<KeyValuePair<string, Type>>();
      foreach (DataColumn c in table.Columns)
        columns.Add(new KeyValuePair<string, Type>(c.ColumnName, c.DataType));

      string template = GenerateTemplate(columns);

      var marks = columns.ToDictionary(x => x.Key, x => $"{{{x.Key}}}");
      var wlock = new object();

      Parallel.ForEach(table.AsEnumerable(), row =>
      {
        var r = new StringBuilder(template);
        foreach (var column in columns)
          if (row[column.Key] == null)
            r.Replace(marks[column.Key], column.Value == typeof(string) ? string.Empty : "null");
          else
            r.Replace(marks[column.Key],
                      column.Value == typeof(string)
                        ? row[column.Key].ToString().Replace("\"", "\\\"")
                        : row[column.Key].ToString().Replace(",", "."));

        var line = r.ToString();
        lock (wlock)
          WriteOutput(line);
      });

      DeleteLastChars(1);
    }

    private static string GenerateTemplate(List<KeyValuePair<string, Type>> columns)
    {
      var templateGen = new StringBuilder();
      templateGen.Append("{");
      foreach (var c in columns)
        templateGen.Append(c.Value == typeof(string) ? $"\"{c.Key}\": \"{{{c.Key}}}\"," : $"\"{c.Key}\": {{{c.Key}}},");
      templateGen.Remove(templateGen.Length - 1, 1);
      templateGen.Append("},");
      var template = templateGen.ToString();
      templateGen.Clear();
      return template;
    }

    protected override void WriteFooter()
    {
      OutputStream.Seek(-1, SeekOrigin.End);
      WriteOutput("]");
    }

    public override AbstractTableWriter Clone(Stream stream)
    {
      return new JsonTableWriter { OutputStream = stream, WriteTid = WriteTid };
    }
  }
}