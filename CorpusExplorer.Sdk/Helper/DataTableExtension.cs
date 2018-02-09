#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

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

    public static string ToCsv(this DataTable dt, string separator = "\t")
    {
      var stb = new StringBuilder();
      stb.AppendLine(string.Join(separator, dt.Columns.Cast<DataColumn>().Select(column => column.ColumnName)));

      foreach (DataRow row in dt.Rows)
        stb.AppendLine(string.Join(separator, row.ItemArray.Select(field => field.ToString())));
      return stb.ToString();
    }

    public static string ToHtml5(this DataTable dt)
    {
      return ToXmlLike(
        dt,
        "<!DOCTYPE html><html><head><link rel=\"stylesheet\" href=\"stylesheet.css\"></head><body><table><tr>",
        "<th id=\"cid{2:000}\">{0}</th>",
        "</tr>",
        "<tr id=\"{0}\">",
        "<td class=\"cid{0:000} v{1}\">{1}</td>",
        "</tr>",
        "</table></body></html>");
    }

    public static string ToJson(this DataTable source)
    {
      var result = new JArray();
      foreach (DataRow dr in source.Rows)
      {
        var row = new JObject();
        foreach (DataColumn col in source.Columns)
          row.Add(col.ColumnName.Trim(), JToken.FromObject(dr[col]));
        result.Add(row);
      }
      return result.ToString();
    }

    public static string ToXml(this DataTable dt)
    {
      return ToXmlLike(
        dt,
        "<dataTable><columns>",
        "<column id=\"{2}\" name=\"{0}\" type=\"{1}\"/>",
        "</columns><rows>",
        "<row id=\"{0}\">",
        "<cell columnId=\"{0}\">{1}</cell>",
        "</row>",
        "</rows></dataTable>");
    }

    private static string ToXmlLike(
      this DataTable dt,
      string prefix,
      string headItemFormat,
      string separatorHeadBody,
      string bodyContainerOpenFormat,
      string bodyContainerItemFormat,
      string bodyContainerCloseFormat,
      string postfix)
    {
      var stb = new StringBuilder();
      stb.Append(prefix);

      var columnIndices = new List<int>();
      for (var i = 0; i < dt.Columns.Count; i++)
      {
        var column = dt.Columns[i];
        stb.AppendFormat(headItemFormat, column.ColumnName, column.DataType.FullName, i);
        columnIndices.Add(i);
      }

      stb.Append(separatorHeadBody);

      for (var i = 0; i < dt.Rows.Count; i++)
      {
        var row = dt.Rows[i];
        stb.AppendFormat(bodyContainerOpenFormat, i);

        foreach (var index in columnIndices)
          stb.AppendFormat(bodyContainerItemFormat, index, row[index]);

        stb.Append(bodyContainerCloseFormat);
      }

      stb.Append(postfix);
      return stb.ToString();
    }
  }
}