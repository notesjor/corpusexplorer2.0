using System;
using System.Data;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using PureHDF;

namespace CorpusExplorer.Sdk.Extern.HdfFive.DataTableWriter
{
  public class Hdf5TableWriter : AbstractTableWriter
  {
    public override string TableWriterTag => "F:HDF5";
    public override string Description => "Simple HDF5";
    public override string MimeType => "application/x-hdf5";

    private string _storeHdf5Path = "";
    private PureHDF.H5File _file;
    private PureHDF.H5Group _group;

    protected override void WriteHead(DataTable table)
    {
      var split = Path.Split('~');
      _storeHdf5Path = split[0];

      OutputStream.Close();

      _file = new H5File();
      _group = _file; // Make File the default group

      for (var i = 1; i < split.Length; i++)
      {
        var group = new H5Group();
        _group[split[i]] = group;
        _group = group;
      }
    }

    protected override void WriteBody(DataTable table)
    {
      if (string.IsNullOrEmpty(Path))
        return;

      for (var i = 0; i < table.Columns.Count; i++)
        if (table.Columns[i].DataType == typeof(string))
          _group[table.Columns[i].ColumnName] = table.AsEnumerable().Select(x => x[i]).Cast<string>().ToArray();
        else if (table.Columns[i].DataType == typeof(int))
          _group[table.Columns[i].ColumnName] = table.AsEnumerable().Select(x => x[i]).Cast<int>().ToArray();
        else if (table.Columns[i].DataType == typeof(double))
          _group[table.Columns[i].ColumnName] = table.AsEnumerable().Select(x => x[i]).Cast<double>().ToArray();
        else if (table.Columns[i].DataType == typeof(DateTime))
          _group[table.Columns[i].ColumnName] = table.AsEnumerable().Select(x => x[i]).Cast<DateTime>().ToArray();
        else if (table.Columns[i].DataType == typeof(Guid))
          _group[table.Columns[i].ColumnName] = table.AsEnumerable().Select(x => x[i]).Cast<Guid>().ToArray();
        else if (table.Columns[i].DataType == typeof(float))
          _group[table.Columns[i].ColumnName] = table.AsEnumerable().Select(x => x[i]).Cast<float>().ToArray();
        else if (table.Columns[i].DataType == typeof(long))
          _group[table.Columns[i].ColumnName] = table.AsEnumerable().Select(x => x[i]).Cast<long>().ToArray();
        else if (table.Columns[i].DataType == typeof(bool))
          _group[table.Columns[i].ColumnName] = table.AsEnumerable().Select(x => x[i]).Cast<bool>().ToArray();
        else if (table.Columns[i].DataType == typeof(decimal))
          _group[table.Columns[i].ColumnName] = table.AsEnumerable().Select(x => x[i]).Cast<decimal>().ToArray();
        else
          _group[table.Columns[i].ColumnName] = table.AsEnumerable().Select(x => x[i].ToString()).ToArray();
    }

    protected override void WriteFooter()
    {
      _file.Write(_storeHdf5Path);
    }

    public override AbstractTableWriter Clone(Stream stream)
    {
      return new Hdf5TableWriter { OutputStream = stream, WriteTid = WriteTid, Path = Path };
    }
  }
}
