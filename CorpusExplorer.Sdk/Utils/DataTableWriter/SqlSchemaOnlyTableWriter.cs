using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Utils.DataTableWriter
{
  public class SqlSchemaOnlyTableWriter : AbstractTableWriter
  {
    public override string TableWriterTag => "F:SQLSCHEMA";
    public override string MimeType => "application/sql";
    public override string Description => "SQL (schema only)";

    public override void WriteTable(DataTable table)
    {
      WriteHead(table);

      var columns = (from DataColumn column in table.Columns
                     select new Tuple<string, string, Type>(column.ColumnName, column.ColumnName.Replace(" ", "_"),
                                                            column.DataType)).ToList();

      var stb = new StringBuilder("CREATE TABLE IF NOT EXISTS CorpusExplorer (");
      foreach (var column in columns)
        stb.Append($"'{column.Item2}' {GetSqlType(column.Item3)},");

      stb.Remove(stb.Length - 1, 1);

      stb.Append(");");
      stb.AppendLine();
      WriteOutput(stb.ToString());
    }

    protected override void WriteHead(DataTable table)
    {
      if (_headInitialized)
        return;

      _headInitialized = true;
      WriteOutput("-- before you add this table to the database:\r\n-- 1. change table name\r\n-- 2. check & change datatypes\r\n-- 3. set (primary) key(s)\r\n");
    }

    protected override void WriteBody(DataTable table)
    {
    }

    protected override void WriteFooter()
    {
    }

    public override AbstractTableWriter Clone(Stream stream)
    {
      return new SqlSchemaOnlyTableWriter { OutputStream = stream, WriteTid = WriteTid };
    }

    private string GetSqlType(Type type)
    {
      if (type == typeof(DateTime))
        return "TEXT";
      if (type == typeof(double) || type == typeof(float))
        return "REAL";
      if (type == typeof(int))
        return "INTEGER";
      return type == typeof(string) ? "TEXT" : "UNKNOWN";
    }
  }
}