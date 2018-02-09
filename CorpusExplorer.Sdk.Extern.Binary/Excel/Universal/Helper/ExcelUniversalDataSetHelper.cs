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
      {
        var reader = ExcelReaderFactory.CreateReader(fs);
        return reader.AsDataSet(
          new ExcelDataSetConfiguration
          {
            UseColumnDataType = true,
            ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration
            {
              UseHeaderRow = true
            }
          });
      }
    }
  }
}