#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Devart.Data.SQLite;

#endregion

namespace CorpusExplorer.Sdk.Db.SQLite.Helper
{
  public static class SQLiteReaderHelper
  {
    private static DataTable BuildDataTable(KeyValuePair<string, Type>[] schema, string[] columns,
                                            string[] dateTimeColumns, out bool[] isDateTime)
    {
      var dt = new DataTable();

      var cFilter = columns == null ? new HashSet<string>(schema.Select(x => x.Key)) : new HashSet<string>(columns);
      var dFilter = dateTimeColumns == null ? new HashSet<string>() : new HashSet<string>(dateTimeColumns);
      var idt = new List<bool>();

      foreach (var x in schema)
      {
        if (!cFilter.Contains(x.Key))
          continue;

        if (dFilter.Contains(x.Key) && x.Value == typeof(string))
        {
          dt.Columns.Add(x.Key, typeof(DateTime));
          idt.Add(true);
        }
        else
        {
          dt.Columns.Add(x.Key, x.Value);
          idt.Add(false);
        }
      }

      isDateTime = idt.ToArray();
      return dt;
    }

    public static DataTable Read(string path, string query = null, string[] columns = null,
                                 string[] dateTimeColumns = null, ulong start = 0, ulong pageSize = 0,
                                 bool readOnly = true)
    {
      var schema = SchemaHelper.ReadSchema(path);
      var dt = BuildDataTable(schema, columns, dateTimeColumns, out var isDateTime);
      var max = isDateTime.Length;

      using (var connection =
        new
          SQLiteConnection($"Data Source={path};Version=3;FailIfMissing=True;{(readOnly ? "Read Only=True;Journal Mode=Off;" : "")}"))
      {
        connection.Open();

        var cs = columns == null ? "*" : string.Join(", ", columns.Select(x => $"\"{x}\""));
        var sql = $"SELECT {cs} FROM 'CorpusExplorer'";

        sql += string.IsNullOrWhiteSpace(query) ? "" : $" WHERE {query}";
        sql += (pageSize > 0 ? $" LIMIT {pageSize}" : "") + (start > 0 ? $" OFFSET {start}" : "");

        var command = new SQLiteCommand(sql, connection);
        var reader = command.ExecuteReader();

        dt.BeginLoadData();
        while (reader.Read())
        {
          var row = new object[max];
          for (var i = 0; i < max; i++)
            if (isDateTime[i])
            {
              if (dt.Columns[i].ColumnName == "TID")
                row[i] = DateTimeHelper.ParseTidDate(reader.GetString(i));
              else
                row[i] = DateTimeHelper.Parse(reader.GetString(i));
            }
            else
            {
              if (dt.Columns[i].DataType == typeof(int))
                row[i] = reader.GetInt32(i);
              else if (dt.Columns[i].DataType == typeof(double))
                row[i] = reader.GetDouble(i);
              else
                row[i] = reader.GetString(i);
            }

          dt.Rows.Add(row);
        }

        dt.EndLoadData();

        connection.Close();
      }

      return dt;
    }

    public static DataTable ReadComplex(string path, string[] columns = null, string[] dateTimeColumns = null,
                                        string ownComplexQuery = null, bool readOnly = true)
    {
      var schema = SchemaHelper.ReadSchema(path);
      var dt = BuildDataTable(schema, columns, dateTimeColumns, out var isDateTime);
      var max = isDateTime.Length;

      using (var connection =
        new
          SQLiteConnection($"Data Source={path};Version=3;FailIfMissing=True;{(readOnly ? "Read Only=True;Journal Mode=Off;" : "")}"))
      {
        connection.Open();

        var cs = columns == null ? "*" : string.Join(", ", columns.Select(x => $"\"{x}\""));
        var sql = $"SELECT {cs} FROM 'CorpusExplorer'";

        sql += string.IsNullOrWhiteSpace(ownComplexQuery) ? "" : $" {ownComplexQuery}";

        var command = new SQLiteCommand(sql, connection);
        var reader = command.ExecuteReader();

        dt.BeginLoadData();
        while (reader.Read())
        {
          var row = new object[max];
          for (var i = 0; i < max; i++)
            if (isDateTime[i])
            {
              if (dt.Columns[i].ColumnName == "TID")
                row[i] = DateTimeHelper.ParseTidDate(reader.GetString(i));
              else
                row[i] = DateTimeHelper.Parse(reader.GetString(i));
            }
            else
            {
              if (dt.Columns[i].DataType == typeof(int))
                row[i] = reader.GetInt32(i);
              else if (dt.Columns[i].DataType == typeof(double))
                row[i] = reader.GetDouble(i);
              else
                row[i] = reader.GetString(i);
            }

          dt.Rows.Add(row);
        }

        dt.EndLoadData();

        connection.Close();
      }

      return dt;
    }
  }
}