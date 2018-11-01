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
  public class XmlTableWriter : AbstractTableWriter
  {
    private readonly Regex _r = new Regex(@"<[^>]*>");

    public override string TableWriterTag => "F:XML";
    public override string MimeType => "application/xml";

    protected override void WriteHead(DataTable table)
    {
      WriteOutput("<items>");
    }

    protected override void WriteBody(DataTable table)
    {
      var columns = new List<KeyValuePair<string, Type>>();
      foreach (DataColumn c in table.Columns)
        columns.Add(new KeyValuePair<string, Type>(c.ColumnName, c.DataType));

      var tmp = new StringBuilder();
      tmp.Append("<item>");
      foreach (var c in columns)
      {
        var tag = c.Key.Replace(" ", "_");
        tmp.Append($"<{tag}>{{{c.Key}}}</{tag}>");
      }

      tmp.Append("</item>");
      var template = tmp.ToString();
      tmp.Clear();

      var marks = columns.ToDictionary(x => x.Key, x => $"{{{x.Key}}}");

      var stb = new StringBuilder();
      foreach (DataRow row in table.Rows)
      {
        tmp = new StringBuilder(template);
        foreach (var column in columns)
        {
          if (row[column.Key] == null)
            tmp.Replace(marks[column.Key], string.Empty);
          else
            tmp.Replace(marks[column.Key],
              column.Value == typeof(string)
                ? _r.Replace(row[column.Key].ToString(), string.Empty).Replace("<", string.Empty).Replace(">", string.Empty)
                : row[column.Key].ToString().Replace(",", "."));
        }

        stb.Append(tmp);
        tmp.Clear();
      }

      WriteOutput(stb.ToString());
    }

    public override AbstractTableWriter Clone(Stream stream)
      => new XmlTableWriter { OutputStream = stream };

    protected override void WriteFooter()
    {
      WriteOutput("</items>");
    }
  }
}