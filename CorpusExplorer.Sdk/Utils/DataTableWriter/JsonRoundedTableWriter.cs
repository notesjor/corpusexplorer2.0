using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Utils.DataTableWriter
{
  public class JsonRoundedTableWriter : AbstractTableWriter
  {
    public override string TableWriterTag => "F:JSONR";
    public override string MimeType => "application/json";
    public override string Description => "JavaScript Object Notation (rounded values)";

    protected override void WriteHead(DataTable table)
    {
    }

    protected override void WriteBody(DataTable table)
    {
      WriteOutput(JsonConvert.SerializeObject(table.RoundDataTable()));
    }
    
    protected override void WriteFooter()
    {
    }

    public override AbstractTableWriter Clone(Stream stream) 
      => new JsonTableWriter { OutputStream = stream, WriteTid = WriteTid, Path = Path };
  }
}