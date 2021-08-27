using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
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
    public override string Description => "SQL (data only)";
    public string TableName { get; set; } = "CorpusExplorer";

    public override void WriteTable(DataTable table)
    {
      WriteHead(table);

      var columns = new List<Tuple<string, string, Type>>();
      foreach (DataColumn column in table.Columns)
        columns.Add(new Tuple<string, string, Type>(column.ColumnName, column.ColumnName.Replace(" ", "_"), column.DataType));

      WriteTableInsert(columns);

      if (OutputStream.CanSeek)
        WriteTableParallel(table, columns);
      else
        WriteTableSynchron(table, columns);
    }

    private void WriteTableParallel(DataTable table, List<Tuple<string, string, Type>> columns)
    {
      var wlock = new object();
      Parallel.ForEach(table.AsEnumerable(), Configuration.ParallelOptions, row =>
      {
        var stb = new StringBuilder();
        stb.Append("(");
        foreach (var column in columns)
          if (column.Item3 == typeof(DateTime))
            stb.Append($"'{(DateTime)row[column.Item1]:yyyy-MM-dd HH:mm:ss}', ");
          else if (column.Item3 == typeof(string))
            stb.Append($"'{((string)row[column.Item1]).Replace("'", "\"")}', ");
          else
            stb.Append($"{row[column.Item1].ToString().Replace(",", ".")}, ");
        stb.Remove(stb.Length - 2, 2);
        stb.Append("), ");

        var line = stb.ToString();

        lock (wlock)
          WriteOutput(line);
      });

      OutputStream.Seek(-2, SeekOrigin.End);
      WriteOutput(";");
    }

    private void WriteTableSynchron(DataTable table, List<Tuple<string, string, Type>> columns)
    {
      var wlock = new object();
      var rows = table.AsEnumerable().ToArray();
      var last = rows.Length - 1;

      for (var i = 0; i < rows.Length; i++)
      {
        var stb = new StringBuilder();
        stb.Append("(");
        foreach (var column in columns)
          if (column.Item3 == typeof(DateTime))
            stb.Append($"'{(DateTime)rows[i][column.Item1]:yyyy-MM-dd HH:mm:ss}', ");
          else if (column.Item3 == typeof(string))
            stb.Append($"'{((string)rows[i][column.Item1]).Replace("'", "\"")}', ");
          else
            stb.Append($"{rows[i][column.Item1].ToString().Replace(",", ".")}, ");
        stb.Remove(stb.Length - 2, 2);
        stb.Append("), ");

        var line = stb.ToString();
        if (i == last)
          line = line.Substring(0, line.Length - 2);

        lock (wlock)
          WriteOutput(line);
      }

      WriteOutput(";");
    }

    private void WriteTableInsert(List<Tuple<string, string, Type>> columns)
    {
      var stb = new StringBuilder($"INSERT INTO {TableName} (");
      foreach (var column in columns)
        stb.Append($"'{column.Item2}', ");
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
      => new SqlDataOnlyTableWriter { OutputStream = stream, WriteTid = WriteTid, TableName = TableName, Path = Path };
  }
}