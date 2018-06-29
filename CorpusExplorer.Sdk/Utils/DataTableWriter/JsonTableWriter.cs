using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Utils.DataTableWriter
{
  public class JsonTableWriter : AbstractTableWriter
  {
    public override string TableWriterTag => "F:JSON";

    public override void WriteTable(DataTable table)
    {
      var columns = new List<KeyValuePair<string, Type>>();
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
      stb.Append("[");
      foreach (DataRow row in table.Rows)
      {
        tmp = new StringBuilder(template);
        foreach (var column in columns)
        {
          var val = row[column.Key];
          if (val == null)
            tmp.Replace(marks[column.Key], column.Value == typeof(string) ? string.Empty : "null");
          else
            tmp.Replace(marks[column.Key],
              column.Value == typeof(string) ? val.ToString() : val.ToString().Replace(",", "."));
        }

        stb.Append(tmp);
        tmp.Clear();
      }

      stb.Remove(stb.Length - 1, 1);
      stb.Append("]");

      WriteOutput(stb.ToString());
    }
  }
}