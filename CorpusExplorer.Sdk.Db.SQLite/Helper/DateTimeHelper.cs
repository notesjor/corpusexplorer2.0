#region

using System;
using System.Globalization;

#endregion

namespace CorpusExplorer.Sdk.Db.SQLite.Helper
{
  public static class DateTimeHelper
  {
    public static DateTime Parse(string str)
      => DateTime.ParseExact(str, "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture);

    public static DateTime ParseTidDate(string tid)
      => DateTime.ParseExact(tid, "yyyy-MM-dd", CultureInfo.CurrentCulture);
  }
}