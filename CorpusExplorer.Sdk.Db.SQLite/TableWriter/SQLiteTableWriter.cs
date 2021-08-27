using System.Data;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using Devart.Data.SQLite;

namespace CorpusExplorer.Sdk.Db.SQLite.TableWriter
{
  public class SQLiteTableWriter : AbstractTableWriter
  {
    public override string TableWriterTag => "F:DB3";
    public override string MimeType => "application/vnd.sqlite3";
    public override string Description => "SQLite v3 database (use: F:DB3#C:/mydata.db3)";

    protected override void WriteHead(DataTable table)
    {
      if (string.IsNullOrWhiteSpace(Path))
        throw new System.IO.InvalidDataException("SQLite benötigt einen FileStream, um zu funktionieren.");

      OutputStream.Close();
      if (System.IO.File.Exists(Path))
        System.IO.File.Delete(Path);

      string query;

      using (var connection = new SQLiteConnection($"Data Source={Path};Version=3;FailIfMissing=False;"))
      {
        connection.Open();

        using (var ms = new System.IO.MemoryStream())
        {
          var head = new SqlSchemaOnlyTableWriter { OutputStream = ms, WriteTid = WriteTid }; 
          head.WriteTable(table);
          ms.Seek(0, System.IO.SeekOrigin.Begin);
          query = Configuration.Encoding.GetString(ms.ToArray());
        }
        var command = new SQLiteCommand(query, connection);
        command.ExecuteNonQuery();

        using (var ms = new System.IO.MemoryStream())
        {
          var data = new SqlDataOnlyTableWriter { OutputStream = ms, WriteTid = WriteTid };
          data.WriteTable(table);
          ms.Seek(0, System.IO.SeekOrigin.Begin);
          query = Configuration.Encoding.GetString(ms.ToArray());
        }
        command = new SQLiteCommand(query, connection);
        command.ExecuteNonQuery();

        connection.Close();
      }
    }

    protected override void WriteBody(DataTable table)
    {
    }

    protected override void WriteFooter()
    {
    }

    public override AbstractTableWriter Clone(System.IO.Stream stream) 
      => new SQLiteTableWriter { OutputStream = stream, WriteTid = WriteTid, Path = Path };
  }
}
