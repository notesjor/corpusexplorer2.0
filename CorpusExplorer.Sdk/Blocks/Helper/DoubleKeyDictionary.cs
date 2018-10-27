using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Blocks.Helper
{
  public class DoubleKeyDictionary<T>
  {
    private Dictionary<string, Dictionary<string, T>> _dic = new Dictionary<string, Dictionary<string, T>>();

    public void Add(string key1, string key2, T value)
    {
      if (_dic.ContainsKey(key2) && _dic[key2].ContainsKey(key1))
        throw new ArgumentException();
      if (_dic.ContainsKey(key1) && _dic[key1].ContainsKey(key2))
        throw new ArgumentException();

      if (_dic.ContainsKey(key1))
        _dic[key1].Add(key2, value);
      else
        _dic.Add(key1, new Dictionary<string, T> { { key2, value } });
    }

    public T this[string key1, string key2]
    {
      get
      {
        if (_dic.ContainsKey(key1) && _dic[key1].ContainsKey(key2))
          return _dic[key1][key2];
        if (_dic.ContainsKey(key2) && _dic[key2].ContainsKey(key1))
          return _dic[key2][key1];
        return default(T);
      }
    }

    public bool ContainsKeyCombination(string key1, string key2) 
      => _dic.ContainsKey(key1) && _dic[key1].ContainsKey(key2) || _dic.ContainsKey(key2) && _dic[key2].ContainsKey(key1);

    public void Remove(string key1, string key2)
    {
      if (_dic.ContainsKey(key1) && _dic[key1].ContainsKey(key2))
        _dic[key1].Remove(key2);
      if (_dic.ContainsKey(key2) && _dic[key2].ContainsKey(key1))
        _dic[key2].Remove(key1);
    }

    public void Remove(string key)
    {
      if (_dic.ContainsKey(key))
        _dic.Remove(key);

      foreach (var x in _dic)
        if (x.Value.ContainsKey(key))
          x.Value.Remove(key);
    }

    public Dictionary<string, Dictionary<string, T>> RawData => _dic;

    public string[] Keys
    {
      get
      {
        var res = new HashSet<string>();
        foreach (var x in _dic)
        {
          res.Add(x.Key);
          foreach (var y in x.Value)
            res.Add(y.Key);
        }
        return res.ToArray();
      }
    }
  }
}
