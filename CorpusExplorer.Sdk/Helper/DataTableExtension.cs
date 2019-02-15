#region

using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter;

#endregion

namespace CorpusExplorer.Sdk.Helper
{
  public static class DataTableExtension
  {
    public static DataTable NormalizeDataTable(
      this DataTable dataTable,
      string columnNameToNormalize,
      double denominator = 1000.0d,
      int round = 2)
    {
      if (!dataTable.Columns.Contains(columnNameToNormalize))
        return dataTable;

      var sum = dataTable.Rows.Cast<DataRow>().Sum(row => (double) row[columnNameToNormalize]);

      foreach (DataRow row in dataTable.Rows)
        row[columnNameToNormalize] = Math.Round((double) row[columnNameToNormalize] / sum * denominator, round);

      return dataTable;
    }

    public static DataTable RegexFilter(
      this DataTable dataTable,
      string column,
      string regularExpression)
    {
      var res = new DataTable();
      foreach (DataColumn c in dataTable.Columns)
        res.Columns.Add(c.ColumnName, c.DataType);

      res.BeginLoadData();
      var regex = new Regex(regularExpression);

      foreach (DataRow row in dataTable.Rows)
      {
        var value = row[column]?.ToString();
        if (!string.IsNullOrEmpty(value) && regex.IsMatch(value))
          res.Rows.Add(row.ItemArray);
      }

      res.EndLoadData();

      return res;
    }

    /// <summary>
    ///   Gibt nur eine bestimmte Anzahl der größten Reihen einer Tabelle zurück. Z.b. nur die Top 100.
    /// </summary>
    /// <param name="dataTable">Tabelle die gefiltert werden soll</param>
    /// <param name="sortColumnname">Spaltenname der zur Filterung dient</param>
    /// <param name="rowLimmit">Anzahl an größten Spalten.</param>
    /// <returns>DataTable.</returns>
    public static DataTable OnlyTheBiggestRows(this DataTable dataTable, string sortColumnname, int rowLimmit)
    {
      return dataTable.Rows.Count < rowLimmit
               ? dataTable
               : dataTable.Rows.Cast<DataRow>()
                          .OrderByDescending(r => r[sortColumnname])
                          .Take(rowLimmit)
                          .CopyToDataTable();
    }

    public static string ToTsv(this DataTable dt)
    {
      using (var ms = new MemoryStream())
      {
        var tableWriter = new TsvTableWriter {OutputStream = ms};
        tableWriter.WriteTable(dt);
        tableWriter.Destroy(false);
        return Configuration.Encoding.GetString(ms.GetBuffer());
      }
    }

    public static string ToCsv(this DataTable dt)
    {
      using (var ms = new MemoryStream())
      {
        var tableWriter = new CsvTableWriter {OutputStream = ms};
        tableWriter.WriteTable(dt);
        tableWriter.Destroy(false);
        return Configuration.Encoding.GetString(ms.GetBuffer());
      }
    }

    public static string ToHtml(this DataTable dt)
    {
      using (var ms = new MemoryStream())
      {
        var tableWriter = new HtmlTableWriter {OutputStream = ms};
        tableWriter.WriteTable(dt);
        tableWriter.Destroy(false);
        return Configuration.Encoding.GetString(ms.GetBuffer());
      }
    }

    public static string ToJson(this DataTable dt)
    {
      using (var ms = new MemoryStream())
      {
        var tableWriter = new JsonTableWriter {OutputStream = ms};
        tableWriter.WriteTable(dt);
        tableWriter.Destroy(false);
        return Configuration.Encoding.GetString(ms.GetBuffer());
      }
    }

    public static string ToXml(this DataTable dt)
    {
      using (var ms = new MemoryStream())
      {
        var tableWriter = new XmlTableWriter {OutputStream = ms};
        tableWriter.WriteTable(dt);
        tableWriter.Destroy(false);
        return Configuration.Encoding.GetString(ms.GetBuffer());
      }
    }
  }
}