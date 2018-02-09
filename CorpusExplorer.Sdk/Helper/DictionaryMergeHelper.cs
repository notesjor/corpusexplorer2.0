using System;
using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Helper
{
  public static class DictionaryMergeHelper
  {
    public static void Merge1LevelDictionary<TK, TV>(
      ref Dictionary<TK, TV> dicResult,
      Dictionary<TK, TV> dicToAdd,
      Func<TV, TV, TV> mergeFunction)
    {
      foreach (var b in dicToAdd)
        if (dicResult.ContainsKey(b.Key))
          dicResult[b.Key] = mergeFunction(dicResult[b.Key], b.Value);
        else
          dicResult.Add(b.Key, b.Value);
    }

    public static void Merge2LevelDictionary<TK, TV>(
      ref Dictionary<TK, Dictionary<TK, TV>> dicResult,
      Dictionary<TK, Dictionary<TK, TV>> dicToAdd,
      Func<TV, TV, TV> mergeFunction)
    {
      foreach (var b1 in dicToAdd)
        if (dicResult.ContainsKey(b1.Key))
          foreach (var b2 in b1.Value)
            if (dicResult[b1.Key].ContainsKey(b2.Key))
              dicResult[b1.Key][b2.Key] = mergeFunction(dicResult[b1.Key][b2.Key], b2.Value);
            else
              dicResult[b1.Key].Add(b2.Key, b2.Value);
        else
          dicResult.Add(b1.Key, b1.Value);
    }

    public static void Merge3LevelDictionary<TK, TV>(
      ref Dictionary<TK, Dictionary<TK, Dictionary<TK, TV>>> dicResult,
      Dictionary<TK, Dictionary<TK, Dictionary<TK, TV>>> dicB,
      Func<TV, TV, TV> func)
    {
      foreach (var b1 in dicB)
        if (dicResult.ContainsKey(b1.Key))
          foreach (var b2 in b1.Value)
            if (dicResult[b1.Key].ContainsKey(b2.Key))
              foreach (var b3 in b2.Value)
                if (dicResult[b1.Key][b2.Key].ContainsKey(b3.Key))
                  dicResult[b1.Key][b2.Key][b3.Key] = func(dicResult[b1.Key][b2.Key][b3.Key], b3.Value);
                else
                  dicResult[b1.Key][b2.Key].Add(b3.Key, b3.Value);
            else
              dicResult[b1.Key].Add(b2.Key, b2.Value);
        else
          dicResult.Add(b1.Key, b1.Value);
    }
  }
}