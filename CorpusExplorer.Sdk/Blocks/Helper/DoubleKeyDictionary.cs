using System;
using System.Collections.Generic;
using System.Linq;

namespace CorpusExplorer.Sdk.Blocks.Helper
{
  public class DoubleKeyDictionary<T>
  {
    public T this[string key1, string key2]
    {
      get
      {
        if (RawData.ContainsKey(key1) && RawData[key1].ContainsKey(key2))
          return RawData[key1][key2];
        if (RawData.ContainsKey(key2) && RawData[key2].ContainsKey(key1))
          return RawData[key2][key1];
        return default(T);
      }
    }

    public Dictionary<string, Dictionary<string, T>> RawData { get; } = new Dictionary<string, Dictionary<string, T>>();

    public string[] Keys
    {
      get
      {
        var res = new HashSet<string>();
        foreach (var x in RawData)
        {
          res.Add(x.Key);
          foreach (var y in x.Value)
            res.Add(y.Key);
        }

        return res.ToArray();
      }
    }

    public void Add(string key1, string key2, T value)
    {
      if (RawData.ContainsKey(key2) && RawData[key2].ContainsKey(key1))
        throw new ArgumentException();
      if (RawData.ContainsKey(key1) && RawData[key1].ContainsKey(key2))
        throw new ArgumentException();

      if (RawData.ContainsKey(key1))
        RawData[key1].Add(key2, value);
      else
        RawData.Add(key1, new Dictionary<string, T> {{key2, value}});
    }

    public bool ContainsKeyCombination(string key1, string key2)
    {
      return RawData.ContainsKey(key1) && RawData[key1].ContainsKey(key2) ||
             RawData.ContainsKey(key2) && RawData[key2].ContainsKey(key1);
    }

    public void Remove(string key1, string key2)
    {
      if (RawData.ContainsKey(key1) && RawData[key1].ContainsKey(key2))
        RawData[key1].Remove(key2);
      if (RawData.ContainsKey(key2) && RawData[key2].ContainsKey(key1))
        RawData[key2].Remove(key1);
    }

    public void Remove(string key)
    {
      if (RawData.ContainsKey(key))
        RawData.Remove(key);

      foreach (var x in RawData)
        if (x.Value.ContainsKey(key))
          x.Value.Remove(key);
    }
  }
}