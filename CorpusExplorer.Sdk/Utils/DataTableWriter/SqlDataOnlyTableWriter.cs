using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Utils.DataTableWriter
{
  public class SqlDataOnlyTableWriter : AbstractTableWriter
  {
    public override string TableWriterTag => "F:SQLDATA";
    public override string MimeType => "application/sql";

    public override void WriteTable(string tid, DataTable table)
    {
      lock (WriteLock)
      {
        tid = MakeTidSqlSafe(tid);

        WriteHead(table);

        var columns = new List<Tuple<string, string, Type>>();
        foreach (DataColumn column in table.Columns)
          columns.Add(new Tuple<string, string, Type>(column.ColumnName, column.ColumnName.Replace(" ", "_"),
                                                      column.DataType));

        var stb = new StringBuilder($"INSERT INTO CorpusExplorer_{tid}\r\n(");
        foreach (var column in columns)
          stb.Append($"{column.Item2}, ");
        stb.Remove(stb.Length - 2, 2);
        stb.Append(")\r\nVALUES\r\n");
        foreach (DataRow row in table.Rows)
        {
          stb.Append("(");
          foreach (var column in columns)
            if (column.Item3 == typeof(DateTime))
              stb.Append($"'{(DateTime)row[column.Item1]:yyyy-MM-dd HH:mm:ss}', ");
            else if (column.Item3 == typeof(string))
              stb.Append($"\"{((string)row[column.Item1]).Replace("\"", "''")}\", ");
            else
              stb.Append($"{row[column.Item1].ToString().Replace(",", ".")}, ");
          stb.Remove(stb.Length - 2, 2);
          stb.Append("), ");
        }

        stb.Remove(stb.Length - 2, 2);
        stb.Append(";");

        WriteOutput(stb.ToString());
      }
    }

    protected override void WriteHead(DataTable table) { }

    protected override void WriteBody(string tid, DataTable table) { }

    protected override void WriteFooter() { }

    public override AbstractTableWriter Clone(Stream stream)
      => new SqlDataOnlyTableWriter { OutputStream = stream };

    private string MakeTidSqlSafe(string tid)
      => tid.Replace("*", "_").Replace(" ", "_");
  }
}