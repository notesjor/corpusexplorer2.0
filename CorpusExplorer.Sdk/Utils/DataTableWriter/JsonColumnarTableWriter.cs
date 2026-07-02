using System;
using System.CodeDom;
using System.Data;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using Newtonsoft.Json;

namespace CorpusExplorer.Sdk.Utils.DataTableWriter
{
  public class JsonColumnarTableWriter : AbstractTableWriter
  {
    public override string TableWriterTag => "F:JSONC";
    public override string MimeType => "application/json";
    public override string Description => "JavaScript Object Notation (JSON) - Columnar";

    protected override void WriteHead(DataTable table)
    {
    }

    protected override void WriteBody(DataTable table)
    {
      WriteDirectThroughStream("{");
      for (var i = 0; i < table.Columns.Count; i++)
      {
        var column = table.Columns[i];
        var type = ConvertToJsonType(column.DataType);
        var values = table.Rows.Cast<DataRow>().Select(x => x[column]);
        WriteDirectThroughStream($"\"{column.ColumnName}\": {{ \"type\": \"{type}\", \"values\": {JsonConvert.SerializeObject(values.ToArray())} }}");
      }

      WriteDirectThroughStream("}");
    }

    private string ConvertToJsonType(Type type)
    {
      switch (Type.GetTypeCode(type))
      {
        case TypeCode.SByte:
        case TypeCode.Byte:
        case TypeCode.Int16:
        case TypeCode.UInt16:
        case TypeCode.Int32:
        case TypeCode.UInt32:
        case TypeCode.Int64:
        case TypeCode.UInt64:
        case TypeCode.Single:
        case TypeCode.Double:
        case TypeCode.Decimal:
          return "number";

        case TypeCode.Boolean:
          return "boolean";

        case TypeCode.Char:
        case TypeCode.String:
        case TypeCode.DateTime:
          return "string";

        case TypeCode.Object:
          return "object";

        case TypeCode.Empty:
        case TypeCode.DBNull:
          throw new TypeInitializationException(type.Name, new Exception());
        default:
          return "string";
      }
    }

    protected override void WriteFooter()
    {
    }

    public override AbstractTableWriter Clone(Stream stream)
      => new JsonColumnarTableWriter { OutputStream = stream, WriteTid = WriteTid, Path = Path };
  }
}