using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Utils.DataTableWriter
{
  public class HtmlTableSnippetWriter : AbstractTableWriter
  {
    private readonly Regex _r = new Regex(@"<[^>]*>");
    public override string MimeType => "text/html";
    public override string Description => "HTML-Table Skeleton";
    public override string TableWriterTag => "F:TRTD";

    protected override void WriteHead(DataTable table)
    {
      WriteOutput("<table><tr>");

      var columns = new List<KeyValuePair<string, Type>>();
      foreach (DataColumn c in table.Columns)
        columns.Add(new KeyValuePair<string, Type>(c.ColumnName, c.DataType));

      foreach (var c in columns)
      {
        var tag = c.Key.Replace(" ", "_");
        WriteOutput($"<th id=\"cid_{tag}\">{tag}</th>");
      }

      WriteOutput("</tr>");
    }

    public override AbstractTableWriter Clone(Stream stream) 
      => new HtmlTableWriter { OutputStream = stream, WriteTid = WriteTid, Path = Path };

    protected override void WriteBody(DataTable table)
    {
      var columns = new List<KeyValuePair<string, Type>>();
      foreach (DataColumn c in table.Columns)
        columns.Add(new KeyValuePair<string, Type>(c.ColumnName, c.DataType));

      string template = GenerateTemplate(columns);

      var marks = columns.ToDictionary(x => x.Key, x => $"{{{x.Key}}}");
      var wlock = new object();

      Parallel.ForEach(table.AsEnumerable(), Configuration.ParallelOptions, row =>
      {
        var tmp = new StringBuilder(template);

        foreach (var column in columns)
          if (row[column.Key] == null)
            tmp.Replace(marks[column.Key], string.Empty);
          else
            tmp.Replace(marks[column.Key],
                        column.Value == typeof(string)
                          ? _r.Replace(row[column.Key].ToString(), string.Empty).Replace("<", string.Empty)
                              .Replace(">", string.Empty)
                          : row[column.Key].ToString().Replace(",", "."));
        var line = tmp.ToString();

        lock (wlock)
          WriteOutput(line);
      });
    }

    private static string GenerateTemplate(List<KeyValuePair<string, Type>> columns)
    {
      var gen = new StringBuilder();
      gen.Append("<tr>");
      foreach (var c in columns)
        gen.Append($"<td class=\"cid_{c.Key.Replace(" ", "_")}\">{{{c.Key}}}</td>");

      gen.Append("</tr>");
      return gen.ToString();
    }

    protected override void WriteFooter()
    {
      WriteOutput("</table>");
    }
  }
}