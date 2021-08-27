using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CorpusExplorer.Sdk.Data.Helper
{
  [Serializable]
  public sealed class ListOptimized<T> : IList<T>
  {
    private readonly Dictionary<T, int> _dic = new Dictionary<T, int>();
    private readonly List<T> _list = new List<T>();

    public ListOptimized()
    {
    }

    public ListOptimized(IEnumerable<T> items)
    {
      foreach (var item in items)
      {
        Add(item);
      }
    }

    public ListOptimized(IEnumerable<T> itemsA, IEnumerable<T> itemsB)
    {
      foreach (var item in itemsA)
      {
        Add(item);
      }
      foreach (var item in itemsB)
      {
        Add(item);
      }
    }

    public IEnumerator<T> GetEnumerator()
    {
      return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return _list.GetEnumerator();
    }

    public void Add(T item)
    {
      if (_dic.ContainsKey(item))
        return;

      _dic.Add(item, _list.Count);
      _list.Add(item);
    }

    public void Clear()
    {
      _dic.Clear();
      _list.Clear();
    }

    public bool Contains(T item)
    {
      return _dic.ContainsKey(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
      _list.CopyTo(array, arrayIndex);
    }

    public bool Remove(T item)
    {
      var idx = _dic[item];
      if (idx == -1)
        return false;

      _dic.Remove(item);
      _list.Remove(item);

      for (int i = idx; i < _list.Count; i++)
      {
        _dic[_list[i]] = _dic[_list[i]] - 1;
      }

      return true;
    }

    public int Count
    {
      get { return _list.Count; }
    }

    public bool IsReadOnly
    {
      get { return false; }
    }

    public int IndexOf(T item)
    {
      int res;
      return _dic.TryGetValue(item, out res) ? res : -1;
    }

    public void Insert(int index, T item)
    {
      _list.Insert(index, item);

      for (int i = index + 1; i < _list.Count; i++)
      {
        _dic[_list[i]] = _dic[_list[i]] + 1;
      }
    }

    public void RemoveAt(int index)
    {
      Remove(_list[index]);
    }

    public T this[int index]
    {
      get { return _list[index]; }
      set { _list[index] = value; }
    }

    public void AddRange(IEnumerable<T> items)
    {
      foreach (var item in items)
      {
        Add(item);
      }
    }

    public List<T> ToList()
    {
      return _list.ToList();
    }

    public T[] ToArray()
    {
      return _list.ToArray();
    }

    public Dictionary<int, int> GetTranslationMatrix(ListOptimized<T> list)
    {
      return list._dic.ToDictionary(x => x.Value, x => _dic.ContainsKey(x.Key) ? _dic[x.Key] : -1);
    }

    public Dictionary<int, int> GetTranslationMatrix(IEnumerable<T> list)
    {
      return GetTranslationMatrix(new ListOptimized<T>(list));
    }

    public T Find(Predicate<T> func)
    {
      foreach (var item in _list.Where(item => func(item)))
      {
        return item;
      }
      return default(T);
    }

    public int FindIndex(Predicate<T> func)
    {
      for (var i = 0; i < _list.Count; i++)
      {
        if (func(_list[i]))
        {
          return i;
        }
      }
      return -1;
    }
  }
}