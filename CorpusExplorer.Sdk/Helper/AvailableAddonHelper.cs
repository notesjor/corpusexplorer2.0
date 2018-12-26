using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Helper
{
  public static class AvailableAddonHelper
  {
    public static Dictionary<string, T> GetReflectedTypeNameDictionary<T>(this IEnumerable<KeyValuePair<string, T>> dic)
    {
      var dictionary = new Dictionary<string, T>();
      foreach (var pair in dic)
      {
        var key = pair.Value.GetType().Name;
        if (!dictionary.ContainsKey(key))
          dictionary.Add(key, pair.Value);
      }

      return dictionary;
    }

    public static Dictionary<string, T> GetReflectedTypeNameDictionary<T>(this IEnumerable<T> enumerable)
    {
      var dictionary = new Dictionary<string, T>();
      foreach (var unknown in enumerable)
      {
        var key = unknown.GetType().Name;
        if (!dictionary.ContainsKey(key))
          dictionary.Add(key, unknown);
      }

      return dictionary;
    }
  }
}