using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Utils.DataTableWriter
{
  public class SqlTableWriter : AbstractTableWriter
  {
    public override string TableWriterTag => "F:SQL";
    public override string MimeType => "application/sql";

    public override void WriteTable(DataTable table)
    {
      lock (WriteLock)
      {
        WriteHead(table);

        var columns = new List<Tuple<string, string, Type>>();
        foreach (DataColumn column in table.Columns)
          columns.Add(new Tuple<string, string, Type>(column.ColumnName, column.ColumnName.Replace(" ", "_"),
            column.DataType));

        var stb = new StringBuilder("CREATE TABLE CorpusExplorer (");
        foreach (var column in columns)
          stb.Append($"{column.Item2} {GetSqlType(column.Item3)},");
        stb.Remove(stb.Length - 1, 1);
        stb.Append(");");
        stb.AppendLine();
        WriteOutput(stb.ToString());
        stb.Clear();

        stb = new StringBuilder("INSERT INTO CorpusExplorer\r\n(");
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

    protected override void WriteHead(DataTable table)
    {
      if (_headInitialized)
        return;

      _headInitialized = true;

      WriteOutput("-- before you add this table to the database:\r\n");
      WriteOutput("-- 1. change table name\r\n");
      WriteOutput("-- 2. check & change datatypes\r\n");
      WriteOutput("-- 3. set (primary) key(s)\r\n");
    }

    protected override void WriteBody( DataTable table) { }

    protected override void WriteFooter() { }

    public override AbstractTableWriter Clone(Stream stream)
      => new SqlTableWriter { OutputStream = stream };

    private string GetSqlType(Type type)
    {
      if (type == typeof(DateTime))
        return "DATE";
      if (type == typeof(double))
        return "FLOAT";
      if (type == typeof(int))
        return "INT";
      if (type == typeof(string))
        return "TEXT";

      return "UNKNOWN";
    }
  }
}