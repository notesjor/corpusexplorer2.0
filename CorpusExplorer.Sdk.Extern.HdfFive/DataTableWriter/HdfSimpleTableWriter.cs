using System.Data;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using HDF5CSharp;

namespace CorpusExplorer.Sdk.Extern.HdfFive.DataTableWriter
{
  public class HdfSimpleTableWriter : AbstractTableWriter
  {
    public override string TableWriterTag => "F:HDF5S";
    public override string Description => "Simple HDF5";
    public override string MimeType => "application/x-hdf5";
    
    protected override void WriteHead(DataTable table) { }

    protected override void WriteBody(DataTable table)
    {
      var fs = OutputStream as FileStream;
      if (fs == null)
        return;

      var path = fs.Name;
      fs?.Close();
      if (File.Exists(path) && new FileInfo(path).Length == 0)
        File.Delete(path);
      
      long fileId;
      if(File.Exists(path))
        fileId = Hdf5.OpenFile(path);
      else
        fileId = Hdf5.CreateFile(path);

      var grp = Hdf5.CreateOrOpenGroup(fileId, "/CorpusExplorer");
     
      Hdf5.WriteDataset(grp, TableWriterTag, (
       from DataRow row
       in table.Rows
       select table.Columns.Cast<DataColumn>().ToDictionary(
         col => col.ColumnName,
         col => row[col])).Cast<object>().ToArray());
    }

    protected override void WriteFooter() { }

    public override AbstractTableWriter Clone(Stream stream)
    {
      return new HdfSimpleTableWriter { OutputStream = stream, WriteTid = WriteTid, Path = Path };
    }
  }
}
