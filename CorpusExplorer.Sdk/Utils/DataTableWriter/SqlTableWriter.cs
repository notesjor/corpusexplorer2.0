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
  public class SqlTableWriter : AbstractTableWriter
  {
    public override string TableWriterTag => "F:SQL";
    public override string MimeType => "application/sql";

    public override void WriteTable(DataTable table)
    {
      var head = new SqlSchemaOnlyTableWriter { OutputStream = OutputStream, WriteTid = WriteTid };
      head.WriteTable(table);
      var data = new SqlDataOnlyTableWriter { OutputStream = OutputStream, WriteTid = WriteTid };
      data.WriteTable(table);
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
      return new SqlTableWriter { OutputStream = stream, WriteTid = WriteTid };
    }
  }
}