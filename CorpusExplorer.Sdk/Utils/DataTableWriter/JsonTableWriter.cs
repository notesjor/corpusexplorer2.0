using System.Data;
using System.IO;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Utils.DataTableWriter
{
  public class JsonTableWriter : AbstractTableWriter
  {
    public override string TableWriterTag => "F:JSON";
    public override string MimeType => "application/json";
    public override string Description => "JavaScript Object Notation (JSON)";

    protected override void WriteHead(DataTable table)
    {
    }

    protected override void WriteBody(DataTable table)
    {
      WriteOutput(JsonConvert.SerializeObject(table));
    }

    protected override void WriteFooter()
    {
    }

    public override AbstractTableWriter Clone(Stream stream) 
      => new JsonTableWriter { OutputStream = stream, WriteTid = WriteTid, Path = Path };
  }
}