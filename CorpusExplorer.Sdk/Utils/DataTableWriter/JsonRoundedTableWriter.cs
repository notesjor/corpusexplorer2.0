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
  public class JsonRoundedTableWriter : AbstractTableWriter
  {
    public override string TableWriterTag => "F:JSONR";
    public override string MimeType => "application/json";

    protected override void WriteHead(DataTable table)
    {
      WriteOutput("[");
    }

    protected override void WriteBody(DataTable table)
    {
      var columns = (from DataColumn c in table.Columns select new KeyValuePair<string, Type>(c.ColumnName, c.DataType)).ToArray();

      var template = GenerateTemplate(columns);

      var marks = columns.ToDictionary(x => x.Key, x => $"{{{x.Key}}}");

      if (OutputStream.CanSeek)
        WriteBodyParallel(table, template, columns, marks);
      else
        WriteBodySynchron(table, template, columns, marks);
    }

    private void WriteBodyParallel(DataTable table, string template, KeyValuePair<string, Type>[] columns, Dictionary<string, string> marks)
    {
      var wlock = new object();

      Parallel.ForEach(table.AsEnumerable(), row =>
      {
        var r = new StringBuilder(template);
        foreach (var column in columns)
          if (row[column.Key] == null)
            r.Replace(marks[column.Key], column.Value == typeof(string) ? string.Empty : "null");
          else
            r.Replace(marks[column.Key], Clean(row[column.Key]));

        var line = r.ToString();
        lock (wlock)
          WriteOutput(line);
      });

      OutputStream.Position--;
    }

    private void WriteBodySynchron(DataTable table, string template, KeyValuePair<string, Type>[] columns, Dictionary<string, string> marks)
    {
      var wlock = new object();
      var rows = table.AsEnumerable().ToArray();
      var last = rows.Length - 1;

      for (var i = 0; i < rows.Length; i++)
      {
        var r = new StringBuilder(template);
        foreach (var column in columns)
          if (rows[i][column.Key] == null)
            r.Replace(marks[column.Key], column.Value == typeof(string) ? string.Empty : "null");
          else
            r.Replace(marks[column.Key], Clean(rows[i][column.Key]));

        var line = r.ToString();
        if (i == last)
          line = line.Substring(0, line.Length - 1);

        lock (wlock)
          WriteOutput(line);
      }
    }

    private static string Clean(object input)
    {
      switch (input)
      {
        case double d:
          return Math.Round(d, 2).ToString();
        case float f:
          return Math.Round(f, 2).ToString();
        case string s:
          return s.Replace("\"", "\\\"").Replace("\r", " ").Replace("\n", " ").Replace("\t", " ").Replace("  ", " ").Replace("  ", " ");
        default:
          return input.ToString();
      }
    }

    private static string GenerateTemplate(KeyValuePair<string, Type>[] columns)
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
      WriteOutput("]");
    }

    public override AbstractTableWriter Clone(Stream stream)
    {
      return new JsonTableWriter { OutputStream = stream, WriteTid = WriteTid };
    }
  }
}