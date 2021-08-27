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
  public class BinaryTableWriter : AbstractTableWriter
  {
    public override string TableWriterTag => "F:BIN";
    public override string MimeType => "application/octet-stream";
    public override string Description => "CorpusExplorer Binary-Table";

    private Dictionary<Type, byte> _dic = new Dictionary<Type, byte>
    {
      {typeof(string), 0},
      {typeof(int), 1},
      {typeof(double), 2},
      {typeof(long), 3},
      {typeof(float), 4},
      {typeof(ulong), 5},
      {typeof(uint), 6},
      {typeof(DateTime), 8},
    };

    private byte[] _columns;

    protected override void WriteHead(DataTable table)
    {
      var cols = new List<byte>();
      var stb = new StringBuilder();
      foreach (DataColumn c in table.Columns)
      {
        var type = _dic.ContainsKey(c.DataType) ? _dic[c.DataType] : (byte)0;
        stb.Append(type);
        WriteString(ref stb, c.ColumnName);
        cols.Add(type);
      }

      _columns = cols.ToArray();

      WriteDirectThroughStream(stb.ToString());
    }

    private void WriteString(ref StringBuilder builder, string str)
    {
      builder.Append(BitConverter.GetBytes(str.Length));
      builder.Append(str);
    }

    protected override void WriteBody(DataTable table)
    {
      var wlock = new object();

      Parallel.ForEach(table.AsEnumerable(), Configuration.ParallelOptions, x =>
      {
        var stb = new StringBuilder();
        for (var i = 0; i < x.ItemArray.Length; i++)
        {
          switch (_columns[i])
          {
            case 0:
              WriteString(ref stb, x[i].ToString());
              break;
            case 1:
              stb.Append(BitConverter.GetBytes((int)x[i]));
              break;
            case 2:
              stb.Append(BitConverter.GetBytes((double)x[i]));
              break;
            case 3:
              stb.Append(BitConverter.GetBytes((long)x[i]));
              break;
            case 4:
              stb.Append(BitConverter.GetBytes((float)x[i]));
              break;
            case 5:
              stb.Append(BitConverter.GetBytes((ulong)x[i]));
              break;
            case 6:
              stb.Append(BitConverter.GetBytes((uint)x[i]));
              break;
            case 7:
              stb.Append(BitConverter.GetBytes(((DateTime)x[i]).Ticks));
              break;
          }
        }

        lock (wlock)
          WriteDirectThroughStream(stb.ToString());
      });
    }

    protected override void WriteFooter()
    {
    }

    public override AbstractTableWriter Clone(Stream stream)
    {
      return new CsvTableWriter { OutputStream = stream, WriteTid = WriteTid, Path = Path};
    }
  }
}