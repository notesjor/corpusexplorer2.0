#region

using System;
using System.Data;
using System.IO;
using CorpusExplorer.Sdk.Diagnostic;
using ExcelDataReader;

#endregion

namespace CorpusExplorer.Sdk.Extern.Binary.Excel.Universal.Helper
{
  internal static class ExcelUniversalDataSetHelper
  {
    public static DataSet GetDataSet(string path, bool isFirstRowAsColumnNames = true)
    {
      try
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
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
        return null;
      }
    }
  }
}