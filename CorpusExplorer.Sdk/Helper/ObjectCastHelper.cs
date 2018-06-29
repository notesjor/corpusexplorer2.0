using System;

namespace CorpusExplorer.Sdk.Helper
{
  public static class ObjectCastHelper
  {
    public static DateTime SafeCastDateTime(this object obj, DateTime? defaultValue = null)
    {
      var val = defaultValue ?? DateTime.MinValue;
      switch (obj)
      {
        case int _:
          val = new DateTime((int) obj);
          break;
        case double _:
          val = new DateTime((long) (double) obj);
          break;
        case float _:
          val = new DateTime((long) (float) obj);
          break;
        case long _:
          val = new DateTime((long) obj);
          break;
        case ulong _:
          val = new DateTime((long) (ulong) obj);
          break;
        case DateTime _:
          val = (DateTime) obj;
          break;
        case string _:
          val = DateTimeHelper.Parse((string) obj);
          break;
      }

      return val;
    }

    public static double SafeCastDouble(this object obj, double defaultValue = 0)
    {
      var val = defaultValue;
      switch (obj)
      {
        case int _:
          val = (int) obj;
          break;
        case double _:
          val = (double) obj;
          break;
        case float _:
          val = (float) obj;
          break;
        case long _:
          val = (long) obj;
          break;
        case ulong _:
          val = (ulong) obj;
          break;
        case DateTime _:
          val = ((DateTime) obj).Ticks;
          break;
        case string _:
          double.TryParse((string) obj, out val);
          break;
      }

      return val;
    }

    public static float SafeCastFloat(this object obj, float defaultValue = 0)
    {
      var val = defaultValue;
      switch (obj)
      {
        case int _:
          val = (int) obj;
          break;
        case double _:
          val = (float) (double) obj;
          break;
        case float _:
          val = (float) obj;
          break;
        case long _:
          val = (long) obj;
          break;
        case ulong _:
          val = (ulong) obj;
          break;
        case DateTime _:
          val = ((DateTime) obj).Ticks;
          break;
        case string _:
          float.TryParse((string) obj, out val);
          break;
      }

      return val;
    }

    public static int SafeCastInt(this object obj, int defaultValue = 0)
    {
      var val = defaultValue;
      switch (obj)
      {
        case int _:
          val = (int) obj;
          break;
        case double _:
          val = (int) (double) obj;
          break;
        case float _:
          val = (int) (float) obj;
          break;
        case long _:
          val = (int) (long) obj;
          break;
        case ulong _:
          val = (int) (ulong) obj;
          break;
        case DateTime _:
          val = (int) ((DateTime) obj).Ticks;
          break;
        case string _:
          int.TryParse((string) obj, out val);
          break;
      }

      return val;
    }

    public static long SafeCastLong(this object obj, long defaultValue = 0)
    {
      var val = defaultValue;
      switch (obj)
      {
        case int _:
          val = (int) obj;
          break;
        case double _:
          val = (long) (double) obj;
          break;
        case float _:
          val = (long) (float) obj;
          break;
        case long _:
          val = (long) obj;
          break;
        case ulong _:
          val = (long) (ulong) obj;
          break;
        case DateTime _:
          val = ((DateTime) obj).Ticks;
          break;
        case string _:
          long.TryParse((string) obj, out val);
          break;
      }

      return val;
    }

    public static string SafeCastString(this object obj, string defaultValue = null)
    {
      var val = defaultValue;
      switch (obj)
      {
        case string _:
          val = (string) obj;
          break;
        default:
          if (obj != null)
            val = obj.ToString();
          break;
      }

      return val;
    }

    public static ulong SafeCastULong(this object obj, ulong defaultValue = 0)
    {
      var val = defaultValue;
      switch (obj)
      {
        case int _:
          val = (ulong) (int) obj;
          break;
        case double _:
          val = (ulong) (double) obj;
          break;
        case float _:
          val = (ulong) (float) obj;
          break;
        case long _:
          val = (ulong) (long) obj;
          break;
        case ulong _:
          val = (ulong) obj;
          break;
        case DateTime _:
          val = (ulong) ((DateTime) obj).Ticks;
          break;
        case string _:
          ulong.TryParse((string) obj, out val);
          break;
      }

      return val;
    }
  }
}