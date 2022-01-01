#region

using System;
using CorpusExplorer.Sdk.Helper;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Counter
{
  public static class PredefinedGetOrderByValueDelegateDelegates
  {
    public static object GetDateTime(object value) => value?.SafeCastDateTime() ?? DateTime.MinValue;

    public static object GetDouble(object value) => value?.SafeCastDouble() ?? 0;

    public static object GetFloat(object value) => value?.SafeCastFloat() ?? 0;

    public static object GetInteger(object value) => value?.SafeCastInt() ?? 0;

    public static object GetLong(object value) => value?.SafeCastLong() ?? 0;

    public static object GetString(object value) => value?.SafeCastString() ?? string.Empty;

    public static object GetULong(object value) => value?.SafeCastULong() ?? 0;
  }
}