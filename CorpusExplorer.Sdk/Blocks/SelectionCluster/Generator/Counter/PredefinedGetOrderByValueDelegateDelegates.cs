using System;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Counter
{
  public static class PredefinedGetOrderByValueDelegateDelegates
  {
    public static object GetDateTime(object value)
    {
      return value?.SafeCastDateTime() ?? DateTime.MinValue;
    }

    public static object GetDouble(object value)
    {
      return value?.SafeCastDouble() ?? 0;
    }

    public static object GetFloat(object value)
    {
      return value?.SafeCastFloat() ?? 0;
    }

    public static object GetInteger(object value)
    {
      return value?.SafeCastInt() ?? 0;
    }

    public static object GetLong(object value)
    {
      return value?.SafeCastLong() ?? 0;
    }

    public static object GetString(object value)
    {
      return value?.SafeCastString() ?? string.Empty;
    }

    public static object GetULong(object value)
    {
      return value?.SafeCastULong() ?? 0;
    }
  }
}