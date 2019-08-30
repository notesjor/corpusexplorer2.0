#region

using System.Data;
using System.IO;
using ExcelDataReader;

#endregion

namespace CorpusExplorer.Sdk.Extern.Binary.Excel.Universal.Helper
{
  internal static class ExcelUniversalDataSetHelper
  {
    public static DataSet GetDataSet(string path, bool isFirstRowAsColumnNames = true)
    {
      using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
      using (var bs = new BufferedStream(fs))
      {
        var reader = ExcelReaderFactory.CreateReader(bs);
        return reader.AsDataSet(
          new ExcelDataSetConfiguration
          {
            UseColumnDataType = true,
            ConfigureDataTable = tableReader => new ExcelDataTableConfiguration
            {
              UseHeaderRow = false
            }
          });
      }
    }
  }
}