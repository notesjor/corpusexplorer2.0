using System.Data;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Utils.DataTableWriter
{
  public class BypassTableWriter : AbstractTableWriter
  {
    public override string TableWriterTag => "F:BYPASS";
    public override void WriteTable(DataTable table)
    {
      Table = table;
    }

    public DataTable Table { get; set; }
  }
}