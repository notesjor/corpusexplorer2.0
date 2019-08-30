using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Utils.DataTableWriter
{
  public class SqlDataOnlyTableWriter : AbstractTableWriter
  {
    public override string TableWriterTag => "F:SQLDATA";
    public override string MimeType => "application/sql";

    public override void WriteTable(DataTable table)
    {
      WriteHead(table);

      var columns = new List<Tuple<string, string, Type>>();
      foreach (DataColumn column in table.Columns)
        columns.Add(new Tuple<string, string, Type>(column.ColumnName, column.ColumnName.Replace(" ", "_"), column.DataType));

      WriteTableInsert(columns);
      var wlock = new object();

      Parallel.ForEach(table.AsEnumerable(), Configuration.ParallelOptions, row =>
      {
        var stb = new StringBuilder();
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

        var line = stb.ToString();

        lock (wlock)
          WriteOutput(line);
      });

      DeleteLastChars(2);
      WriteOutput(";");
    }

    private void WriteTableInsert(List<Tuple<string, string, Type>> columns)
    {
      var stb = new StringBuilder("INSERT INTO CorpusExplorer\r\n(");
      foreach (var column in columns)
        stb.Append($"{column.Item2}, ");
      stb.Remove(stb.Length - 2, 2);
      stb.Append(")\r\nVALUES\r\n");
      WriteOutput(stb.ToString());
    }

    protected override void WriteHead(DataTable table)
    {
    }

    protected override void WriteBody(DataTable table)
    {
    }

    protected override void WriteFooter()
    {
    }

    public override AbstractTableWriter Clone(Stream stream)
    {
      return new SqlDataOnlyTableWriter { OutputStream = stream, WriteTid = WriteTid };
    }
  }
}