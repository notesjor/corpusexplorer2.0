using System;
using System.Collections.Generic;
using System.Data;
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

    public override void WriteTable(DataTable table)
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
      stb.Append("<items>");
      foreach (DataRow row in table.Rows)
      {
        tmp = new StringBuilder(template);
        foreach (var column in columns)
        {
          var val = row[column.Key];
          if (val == null)
            tmp.Replace(marks[column.Key], string.Empty);
          else
            tmp.Replace(marks[column.Key],
              column.Value == typeof(string)
                ? _r.Replace(val.ToString(), string.Empty).Replace("<", string.Empty).Replace(">", string.Empty)
                : val.ToString().Replace(",", "."));
        }

        stb.Append(tmp);
        tmp.Clear();
      }

      stb.Append("</items>");

      WriteOutput(stb.ToString());
    }
  }
}