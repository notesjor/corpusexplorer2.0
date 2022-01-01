#region

using System;
using System.Collections.Generic;
using Devart.Data.SQLite;

#endregion

namespace CorpusExplorer.Sdk.Db.SQLite.Helper
{
  public static class SchemaHelper
  {
    private static Type GetType(string str)
    {
      switch (str)
      {
        case "TEXT":
          return typeof(string);
        case "INTEGER":
          return typeof(int);
        case "REAL":
          return typeof(double);
        default:
          return typeof(object);
      }
    }

    public static KeyValuePair<string, Type>[] ReadSchema(string path, string table = "CorpusExplorer")
    {
      var res = new List<KeyValuePair<string, Type>>();
      using (var connection = new SQLiteConnection($"Data Source={path};Version=3;FailIfMissing=True;"))
      {
        connection.Open();

        var command = new SQLiteCommand($"PRAGMA table_info('{table}')", connection);
        var reader = command.ExecuteReader();

        while (reader.Read())
          res.Add(new KeyValuePair<string, Type>(reader.GetString(1), GetType(reader.GetString(2))));

        connection.Close();
      }

      return res.ToArray();
    }
  }
}