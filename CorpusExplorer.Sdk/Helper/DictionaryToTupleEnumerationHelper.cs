using System;
using System.Collections.Generic;
using System.Linq;

namespace CorpusExplorer.Sdk.Helper
{
  public static class DictionaryToTupleEnumerationHelper
  {
    public static IEnumerable<Tuple<TKey, TVal>> ToTuple<TKey, TVal>(this Dictionary<TKey, TVal> dic)
    {
      return dic.Select(x => new Tuple<TKey, TVal>(x.Key, x.Value));
    }

    public static IEnumerable<Tuple<TKey1, TKey2, TVal>> ToTuple<TKey1, TKey2, TVal>(
      this Dictionary<TKey1, Dictionary<TKey2, TVal>> dic)
    {
      return from x in dic from y in x.Value select new Tuple<TKey1, TKey2, TVal>(x.Key, y.Key, y.Value);
    }

    public static IEnumerable<Tuple<TKey1, TKey2, TKey3, TVal>> ToTuple<TKey1, TKey2, TKey3, TVal>(
      this Dictionary<TKey1, Dictionary<TKey2, Dictionary<TKey3, TVal>>> dic)
    {
      return from x in dic
             from y in x.Value
             from z in y.Value
             select new Tuple<TKey1, TKey2, TKey3, TVal>(x.Key, y.Key, z.Key, z.Value);
    }

    public static IEnumerable<Tuple<TKey1, TKey2, TKey3, TKey4, TVal>> ToTuple<TKey1, TKey2, TKey3, TKey4, TVal>(
      this Dictionary<TKey1, Dictionary<TKey2, Dictionary<TKey3, Dictionary<TKey4, TVal>>>> dic)
    {
      return from x in dic
             from y in x.Value
             from z in y.Value
             from a in z.Value
             select new Tuple<TKey1, TKey2, TKey3, TKey4, TVal>(x.Key, y.Key, z.Key, a.Key, a.Value);
    }
  }
}