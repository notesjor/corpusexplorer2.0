using CorpusExplorer.Sdk.Model.CorpusExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Helper
{
  public class CeDictionaryMemoryFriendly<T>
  {
    private CeDictionary _dict;
    private Dictionary<int, Dictionary<int, T>> _values;

    private CeDictionaryMemoryFriendly() { }

    public static CeDictionaryMemoryFriendly<T> Create(ref Dictionary<string, Dictionary<string, T>> dictionary, bool dontFlushDictionary = false)
    {      
      var res = new CeDictionaryMemoryFriendly<T>();
      res.MakeDict(ref dictionary);
      res.MakeValues(ref dictionary);
            
      if(!dontFlushDictionary)
        dictionary.Clear();

      return res;
    }

    private void MakeValues(ref Dictionary<string, Dictionary<string, T>> dictionary)
    {
      _values = new Dictionary<int, Dictionary<int, T>>();
      foreach(var x in dictionary)
      {
        var tmp = new Dictionary<int, T>();
        foreach(var y in x.Value)
          tmp.Add(_dict[y.Key], y.Value);
        _values.Add(_dict[x.Key], tmp);
      }
    }

    private void MakeDict(ref Dictionary<string, Dictionary<string, T>> dictionary)
    {
      var list = dictionary.Keys.ToList();
      list.AddRange(dictionary.SelectMany(x => x.Value.Keys));
      var hash = new HashSet<string>(list);
      list.Clear();

      _dict = new CeDictionary(hash);
    }

    public void Clear()
    {
      _values.Clear();
      _dict.Clear();
    }

    public Dictionary<string, T> this[string key]
    {
      get
      {
        var tmp = _values[_dict[key]];
        var res = new Dictionary<string, T>();
        foreach(var x in tmp)
          res.Add(_dict[x.Key], x.Value);
        return res;
      }
    }

    public bool ContainsKey(string query) => _dict.Contains(query);

    public IEnumerable<string> Keys => _dict.Values;

    public int Count => _dict.Count;
  }
}
