using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tfres;

namespace CorpusExplorer.Terminal.Universal.TableWriter
{
  public class DirectJsonTableWriter : AbstractTableWriter
  {
    private readonly HttpResponse _response;
    public override string TableWriterTag => "F:JSON (DIRECT)";
    public override string MimeType => "application/json";
    public override string Description => "JavaScript Object Notation (JSON)";

    public DirectJsonTableWriter(HttpContext ctx)
    {
      _response = ctx.Response;
    }

    public override AbstractTableWriter Clone(Stream stream)
    {
      // Darf nicht klonbar sein
      throw new NotImplementedException();
    }

    protected override void WriteOutput(string line)
    {
      _response.SendChunk(line, Encoding.UTF8, "application/json");
    }

    protected override void WriteBody(DataTable table)
    {
      var columns = (from DataColumn c in table.Columns select new KeyValuePair<string, Type>(c.ColumnName, c.DataType)).ToArray();

      var template = GenerateTemplate(columns);

      var marks = columns.ToDictionary(x => x.Key, x => $"{{{x.Key}}}");

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

        WriteOutput(line);
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

    private static string Clean(object input)
    {
      switch (input)
      {
        case string s:
          return s.Replace("\"", "\\\"").Replace("\r", " ").Replace("\n", " ").Replace("\t", " ").Replace("  ", " ").Replace("  ", " ");
        default:
          return input.ToString();
      }
    }

    protected override void WriteFooter()
    {
      WriteOutput("]");
    }

    protected override void WriteHead(DataTable table)
    {
      WriteOutput("[");
    }
  }
}
