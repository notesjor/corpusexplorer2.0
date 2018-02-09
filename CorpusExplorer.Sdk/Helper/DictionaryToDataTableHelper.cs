using System.Collections.Generic;
using System.Data;

namespace CorpusExplorer.Sdk.Helper
{
  public static class DictionaryToDataTableHelper
  {
    public static DataTable ToDataTable<TK1, TV>(
      this Dictionary<TK1, TV> dictionary,
      string columnNameKey1,
      string columnNameValue)
    {
      return ToDataTableInternal(dictionary, columnNameKey1, columnNameValue);
    }

    public static DataTable ToDataTable<TK1, TV>(
      this IEnumerable<KeyValuePair<TK1, TV>> dictionary,
      string columnNameKey1,
      string columnNameValue)
    {
      return ToDataTableInternal(dictionary, columnNameKey1, columnNameValue);
    }

    public static DataTable ToDataTable<TK1, TK2, TV>(
      this Dictionary<TK1, Dictionary<TK2, TV>> dictionary,
      string columnNameKey1,
      string columnNameKey2,
      string columnNameValue)
    {
      return ToDataTableInternal(dictionary, columnNameKey1, columnNameKey2, columnNameValue);
    }

    public static DataTable ToDataTable<TK1, TK2, TV>(
      this IEnumerable<KeyValuePair<TK1, Dictionary<TK2, TV>>> dictionary,
      string columnNameKey1,
      string columnNameKey2,
      string columnNameValue)
    {
      return ToDataTableInternal(dictionary, columnNameKey1, columnNameKey2, columnNameValue);
    }

    public static DataTable ToDataTable<TK1, TK2, TK3, TV>(
      this Dictionary<TK1, Dictionary<TK2, Dictionary<TK3, TV>>> dictionary,
      string columnNameKey1,
      string columnNameKey2,
      string columnNameKey3,
      string columnNameValue)
    {
      return ToDataTableInternal(dictionary, columnNameKey1, columnNameKey2, columnNameKey3, columnNameValue);
    }

    public static DataTable ToDataTable<TK1, TK2, TK3, TV>(
      this IEnumerable<KeyValuePair<TK1, Dictionary<TK2, Dictionary<TK3, TV>>>> dictionary,
      string columnNameKey1,
      string columnNameKey2,
      string columnNameKey3,
      string columnNameValue)
    {
      return ToDataTableInternal(dictionary, columnNameKey1, columnNameKey2, columnNameKey3, columnNameValue);
    }

    public static DataTable ToDataTable<TK1, TK2, TK3, TK4, TV>(
      this Dictionary<TK1, Dictionary<TK2, Dictionary<TK3, Dictionary<TK4, TV>>>> dictionary,
      string columnNameKey1,
      string columnNameKey2,
      string columnNameKey3,
      string columnNameKey4,
      string columnNameValue)
    {
      return ToDataTableInternal(
        dictionary,
        columnNameKey1,
        columnNameKey2,
        columnNameKey3,
        columnNameKey4,
        columnNameValue);
    }

    public static DataTable ToDataTable<TK1, TK2, TK3, TK4, TV>(
      this IEnumerable<KeyValuePair<TK1, Dictionary<TK2, Dictionary<TK3, Dictionary<TK4, TV>>>>> dictionary,
      string columnNameKey1,
      string columnNameKey2,
      string columnNameKey3,
      string columnNameKey4,
      string columnNameValue)
    {
      return ToDataTableInternal(
        dictionary,
        columnNameKey1,
        columnNameKey2,
        columnNameKey3,
        columnNameKey4,
        columnNameValue);
    }

    public static DataTable ToDataTable<TK1, TK2, TK3, TK4, TK5, TV>(
      this Dictionary<TK1, Dictionary<TK2, Dictionary<TK3, Dictionary<TK4, Dictionary<TK5, TV>>>>> dictionary,
      string columnNameKey1,
      string columnNameKey2,
      string columnNameKey3,
      string columnNameKey4,
      string columnNameKey5,
      string columnNameValue)
    {
      return ToDataTableInternal(
        dictionary,
        columnNameKey1,
        columnNameKey2,
        columnNameKey3,
        columnNameKey4,
        columnNameKey5,
        columnNameValue);
    }

    public static DataTable ToDataTable<TK1, TK2, TK3, TK4, TK5, TV>(
      this IEnumerable<KeyValuePair<TK1, Dictionary<TK2, Dictionary<TK3, Dictionary<TK4, Dictionary<TK5, TV>>>>>>
        dictionary,
      string columnNameKey1,
      string columnNameKey2,
      string columnNameKey3,
      string columnNameKey4,
      string columnNameKey5,
      string columnNameValue)
    {
      return ToDataTableInternal(
        dictionary,
        columnNameKey1,
        columnNameKey2,
        columnNameKey3,
        columnNameKey4,
        columnNameKey5,
        columnNameValue);
    }

    private static DataTable ToDataTableInternal<TK1, TV>(
      this IEnumerable<KeyValuePair<TK1, TV>> dictionary,
      string columnNameKey1,
      string columnNameValue)
    {
      var res = new DataTable();
      res.Columns.Add(columnNameKey1, typeof(TK1));
      res.Columns.Add(columnNameValue, typeof(TV));

      res.BeginLoadData();
      foreach (var d1 in dictionary)
        res.Rows.Add(d1.Key, d1.Value);
      res.EndLoadData();

      return res;
    }

    private static DataTable ToDataTableInternal<TK1, TK2, TV>(
      this IEnumerable<KeyValuePair<TK1, Dictionary<TK2, TV>>> dictionary,
      string columnNameKey1,
      string columnNameKey2,
      string columnNameValue)
    {
      var res = new DataTable();
      res.Columns.Add(columnNameKey1, typeof(TK1));
      res.Columns.Add(columnNameKey2, typeof(TK2));
      res.Columns.Add(columnNameValue, typeof(TV));

      res.BeginLoadData();
      foreach (var d1 in dictionary)
      foreach (var d2 in d1.Value)
        res.Rows.Add(d1.Key, d2.Key, d2.Value);
      res.EndLoadData();

      return res;
    }

    private static DataTable ToDataTableInternal<TK1, TK2, TK3, TV>(
      this IEnumerable<KeyValuePair<TK1, Dictionary<TK2, Dictionary<TK3, TV>>>> dictionary,
      string columnNameKey1,
      string columnNameKey2,
      string columnNameKey3,
      string columnNameValue)
    {
      var res = new DataTable();
      res.Columns.Add(columnNameKey1, typeof(TK1));
      res.Columns.Add(columnNameKey2, typeof(TK2));
      res.Columns.Add(columnNameKey3, typeof(TK3));

      res.Columns.Add(columnNameValue, typeof(TV));

      res.BeginLoadData();
      foreach (var d1 in dictionary)
      foreach (var d2 in d1.Value)
      foreach (var d3 in d2.Value)
        res.Rows.Add(d1.Key, d2.Key, d3.Key, d3.Value);
      res.EndLoadData();

      return res;
    }

    private static DataTable ToDataTableInternal<TK1, TK2, TK3, TK4, TV>(
      this IEnumerable<KeyValuePair<TK1, Dictionary<TK2, Dictionary<TK3, Dictionary<TK4, TV>>>>> dictionary,
      string columnNameKey1,
      string columnNameKey2,
      string columnNameKey3,
      string columnNameKey4,
      string columnNameValue)
    {
      var res = new DataTable();
      res.Columns.Add(columnNameKey1, typeof(TK1));
      res.Columns.Add(columnNameKey2, typeof(TK2));
      res.Columns.Add(columnNameKey3, typeof(TK3));
      res.Columns.Add(columnNameKey4, typeof(TK4));
      res.Columns.Add(columnNameValue, typeof(TV));

      res.BeginLoadData();
      foreach (var d1 in dictionary)
      foreach (var d2 in d1.Value)
      foreach (var d3 in d2.Value)
      foreach (var d4 in d3.Value)
        res.Rows.Add(d1.Key, d2.Key, d3.Key, d4.Key, d4.Value);
      res.EndLoadData();

      return res;
    }

    private static DataTable ToDataTableInternal<TK1, TK2, TK3, TK4, TK5, TV>(
      this IEnumerable<KeyValuePair<TK1, Dictionary<TK2, Dictionary<TK3, Dictionary<TK4, Dictionary<TK5, TV>>>>>>
        dictionary,
      string columnNameKey1,
      string columnNameKey2,
      string columnNameKey3,
      string columnNameKey4,
      string columnNameKey5,
      string columnNameValue)
    {
      var res = new DataTable();
      res.Columns.Add(columnNameKey1, typeof(TK1));
      res.Columns.Add(columnNameKey2, typeof(TK2));
      res.Columns.Add(columnNameKey3, typeof(TK3));
      res.Columns.Add(columnNameKey4, typeof(TK4));
      res.Columns.Add(columnNameKey5, typeof(TK5));
      res.Columns.Add(columnNameValue, typeof(TV));

      res.BeginLoadData();
      foreach (var d1 in dictionary)
      foreach (var d2 in d1.Value)
      foreach (var d3 in d2.Value)
      foreach (var d4 in d3.Value)
      foreach (var d5 in d4.Value)
        res.Rows.Add(d1.Key, d2.Key, d3.Key, d4.Key, d5.Key, d5.Value);
      res.EndLoadData();

      return res;
    }
  }
}