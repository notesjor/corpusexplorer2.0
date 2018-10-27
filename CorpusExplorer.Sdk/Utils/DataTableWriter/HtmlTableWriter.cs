using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Utils.DataTableWriter
{
  public class HtmlTableWriter : AbstractTableWriter
  {
    private readonly Regex _r = new Regex(@"<[^>]*>");
    public override string MimeType => "text/html";
    private int _rowCount;

    public override string TableWriterTag => "F:HTML";

    protected override void WriteHead(DataTable table)
    {
      WriteOutput("<!DOCTYPE html><html><head><link rel=\"stylesheet\" href=\"stylesheet.css\"></head><body><table><tr>");

      var columns = new List<KeyValuePair<string, Type>> { new KeyValuePair<string, Type>("tid", typeof(string)) };
      foreach (DataColumn c in table.Columns)
        columns.Add(new KeyValuePair<string, Type>(c.ColumnName, c.DataType));

      foreach (var c in columns)
      {
        var tag = c.Key.Replace(" ", "_");
        WriteOutput($"<th id=\"cid_{tag}\">{tag}</th>");
      }

      WriteOutput("</tr>");

      _rowCount = 0;
    }

    public override AbstractTableWriter Clone(Stream stream)
      => new HtmlTableWriter { OutputStream = stream };

    protected override void WriteBody(string tid, DataTable table)
    {
      var columns = new List<KeyValuePair<string, Type>> { new KeyValuePair<string, Type>("tid", typeof(string)) };
      foreach (DataColumn c in table.Columns)
        columns.Add(new KeyValuePair<string, Type>(c.ColumnName, c.DataType));

      var tmp = new StringBuilder();
      tmp.Append("<tr id=\"rid_{rid}\" class=\"r_{num}\">");
      foreach (var c in columns)
      {
        var tag = c.Key.Replace(" ", "_");
        tmp.Append($"<td class=\"cid_{tag} rid_{{rid}}\">{{{c.Key}}}</td>");
      }

      tmp.Append("</tr>");
      var template = tmp.ToString();
      tmp.Clear();

      var marks = columns.ToDictionary(x => x.Key, x => $"{{{x.Key}}}");

      var res = new StringBuilder();
      foreach(DataRow row in table.Rows)
      {
        tmp = new StringBuilder(template);
        tmp.Replace("{num}", _rowCount % 2 == 0 ? "even" : "odd");
        tmp.Replace("{rid}", _rowCount++.ToString());        

        foreach (var column in columns)
        {
          var val = column.Key == "tid" ? tid : row[column.Key];
          if (val == null)
            tmp.Replace(marks[column.Key], string.Empty);
          else
            tmp.Replace(marks[column.Key],
              column.Value == typeof(string)
                ? _r.Replace(val.ToString(), string.Empty).Replace("<", string.Empty).Replace(">", string.Empty)
                : val.ToString().Replace(",", "."));
        }

        res.Append(tmp);
        tmp.Clear();
      }

      WriteOutput(res.ToString());
    }

    protected override void WriteFooter()
    {
      WriteOutput("</table></body></html>");
    }
  }
}