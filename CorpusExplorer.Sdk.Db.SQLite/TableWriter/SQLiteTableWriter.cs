#region

using System.Data;
using System.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using Devart.Data.SQLite;

#endregion

namespace CorpusExplorer.Sdk.Db.SQLite.TableWriter
{
  public class SQLiteTableWriter : AbstractTableWriter
  {
    public override string Description => "SQLite v3 database (use: F:DB3#C:/mydata.db3)";
    public override string MimeType => "application/vnd.sqlite3";
    public override string TableWriterTag => "F:DB3";

    public override AbstractTableWriter Clone(Stream stream)
      => new SQLiteTableWriter { OutputStream = stream, WriteTid = WriteTid, Path = Path };

    protected override void WriteBody(DataTable table)
    {
    }

    protected override void WriteFooter()
    {
    }

    protected override void WriteHead(DataTable table)
    {
      if (string.IsNullOrWhiteSpace(Path))
        throw new InvalidDataException("SQLite benötigt einen FileStream, um zu funktionieren.");

      OutputStream.Close();
      if (File.Exists(Path))
        File.Delete(Path);

      string query;

      using (var connection = new SQLiteConnection($"Data Source={Path};Version=3;FailIfMissing=False;"))
      {
        connection.Open();

        using (var ms = new MemoryStream())
        {
          var head = new SqlSchemaOnlyTableWriter { OutputStream = ms, WriteTid = WriteTid };
          head.WriteTable(table);
          ms.Seek(0, SeekOrigin.Begin);
          query = Configuration.Encoding.GetString(ms.ToArray());
        }

        var command = new SQLiteCommand(query, connection);
        command.ExecuteNonQuery();

        using (var ms = new MemoryStream())
        {
          var data = new SqlDataOnlyTableWriter { OutputStream = ms, WriteTid = WriteTid };
          data.WriteTable(table);
          ms.Seek(0, SeekOrigin.Begin);
          query = Configuration.Encoding.GetString(ms.ToArray());
        }

        command = new SQLiteCommand(query, connection);
        command.ExecuteNonQuery();

        connection.Close();
      }
    }
  }
}