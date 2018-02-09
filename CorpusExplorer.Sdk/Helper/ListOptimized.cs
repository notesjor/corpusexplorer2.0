#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace CorpusExplorer.Sdk.Helper
{
  /// <summary>
  ///   The list optimized.
  /// </summary>
  /// <typeparam name="T">
  /// </typeparam>
  [Serializable]
  public sealed class ListOptimized<T> : IList<T>
  {
    /// <summary>
    ///   The _dic.
    /// </summary>
    private readonly Dictionary<T, int> _dic = new Dictionary<T, int>();

    /// <summary>
    ///   The _list.
    /// </summary>
    private readonly List<T> _list = new List<T>();

    /// <summary>
    ///   Initializes a new instance of the <see cref="ListOptimized{T}" /> class.
    /// </summary>
    public ListOptimized() { }

    /// <summary>
    ///   Initializes a new instance of the <see cref="ListOptimized{T}" /> class.
    /// </summary>
    /// <param name="items">
    ///   The items.
    /// </param>
    public ListOptimized(IEnumerable<T> items)
    {
      foreach (var item in items)
        Add(item);
    }

    /// <summary>
    ///   Initializes a new instance of the <see cref="ListOptimized{T}" /> class.
    /// </summary>
    /// <param name="itemsA">
    ///   The items a.
    /// </param>
    /// <param name="itemsB">
    ///   The items b.
    /// </param>
    public ListOptimized(IEnumerable<T> itemsA, IEnumerable<T> itemsB)
    {
      foreach (var item in itemsA)
        Add(item);

      foreach (var item in itemsB)
        Add(item);
    }

    /// <summary>
    ///   The add.
    /// </summary>
    /// <param name="item">
    ///   The item.
    /// </param>
    public void Add(T item)
    {
      if (_dic.ContainsKey(item))
        return;

      _dic.Add(item, _list.Count);
      _list.Add(item);
    }

    /// <summary>
    ///   The clear.
    /// </summary>
    public void Clear()
    {
      _dic.Clear();
      _list.Clear();
    }

    /// <summary>
    ///   The contains.
    /// </summary>
    /// <param name="item">
    ///   The item.
    /// </param>
    /// <returns>
    ///   The <see cref="bool" />.
    /// </returns>
    public bool Contains(T item)
    {
      return _dic.ContainsKey(item);
    }

    /// <summary>
    ///   The copy to.
    /// </summary>
    /// <param name="array">
    ///   The array.
    /// </param>
    /// <param name="arrayIndex">
    ///   The array index.
    /// </param>
    public void CopyTo(T[] array, int arrayIndex)
    {
      _list.CopyTo(array, arrayIndex);
    }

    /// <summary>
    ///   Gets the count.
    /// </summary>
    public int Count => _list.Count;

    /// <summary>
    ///   Gets a value indicating whether is read only.
    /// </summary>
    public bool IsReadOnly => false;

    /// <summary>
    ///   The remove.
    /// </summary>
    /// <param name="item">
    ///   The item.
    /// </param>
    /// <returns>
    ///   The <see cref="bool" />.
    /// </returns>
    public bool Remove(T item)
    {
      var idx = _dic[item];
      if (idx == -1)
        return false;

      _dic.Remove(item);
      _list.Remove(item);

      for (var i = idx; i < _list.Count; i++)
        _dic[_list[i]] = _dic[_list[i]] - 1;

      return true;
    }

    /// <summary>
    ///   The get enumerator.
    /// </summary>
    /// <returns>
    ///   The <see cref="IEnumerator" />.
    /// </returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
      return _list.GetEnumerator();
    }

    /// <summary>
    ///   The get enumerator.
    /// </summary>
    /// <returns>
    ///   The <see cref="IEnumerator" />.
    /// </returns>
    public IEnumerator<T> GetEnumerator()
    {
      return _list.GetEnumerator();
    }

    /// <summary>
    ///   The index of.
    /// </summary>
    /// <param name="item">
    ///   The item.
    /// </param>
    /// <returns>
    ///   The <see cref="int" />.
    /// </returns>
    public int IndexOf(T item)
    {
      int res;
      return _dic.TryGetValue(item, out res) ? res : -1;
    }

    /// <summary>
    ///   The insert.
    /// </summary>
    /// <param name="index">
    ///   The index.
    /// </param>
    /// <param name="item">
    ///   The item.
    /// </param>
    public void Insert(int index, T item)
    {
      _list.Insert(index, item);

      for (var i = index + 1; i < _list.Count; i++)
        _dic[_list[i]] = _dic[_list[i]] + 1;
    }

    /// <summary>
    ///   The this.
    /// </summary>
    /// <param name="index">
    ///   The index.
    /// </param>
    /// <returns>
    ///   The <see cref="T" />.
    /// </returns>
    public T this[int index] { get => _list[index]; set => _list[index] = value; }

    /// <summary>
    ///   The remove at.
    /// </summary>
    /// <param name="index">
    ///   The index.
    /// </param>
    public void RemoveAt(int index)
    {
      Remove(_list[index]);
    }

    /// <summary>
    ///   The add range.
    /// </summary>
    /// <param name="items">
    ///   The items.
    /// </param>
    public void AddRange(IEnumerable<T> items)
    {
      foreach (var item in items)
        Add(item);
    }

    /// <summary>
    ///   The find.
    /// </summary>
    /// <param name="func">
    ///   The func.
    /// </param>
    /// <returns>
    ///   The <see cref="T" />.
    /// </returns>
    public T Find(Predicate<T> func)
    {
      foreach (var item in _list.Where(item => func(item)))
        return item;

      return default(T);
    }

    /// <summary>
    ///   The find index.
    /// </summary>
    /// <param name="func">
    ///   The func.
    /// </param>
    /// <returns>
    ///   The <see cref="int" />.
    /// </returns>
    public int FindIndex(Predicate<T> func)
    {
      for (var i = 0; i < _list.Count; i++)
        if (func(_list[i]))
          return i;

      return -1;
    }

    /// <summary>
    ///   The get raw dictionary.
    /// </summary>
    /// <returns>
    ///   Raw-Dictionary
    /// </returns>
    public Dictionary<T, int> GetRawDictionary()
    {
      return _dic;
    }

    /// <summary>
    ///   The get translation matrix.
    /// </summary>
    /// <param name="list">
    ///   The list.
    /// </param>
    /// <returns>
    ///   The matrix
    /// </returns>
    public Dictionary<int, int> GetTranslationMatrix(ListOptimized<T> list)
    {
      return list._dic.ToDictionary(x => x.Value, x => _dic.ContainsKey(x.Key) ? _dic[x.Key] : -1);
    }

    /// <summary>
    ///   The get translation matrix.
    /// </summary>
    /// <param name="list">
    ///   The list.
    /// </param>
    /// <returns>
    ///   The matrix
    /// </returns>
    public Dictionary<int, int> GetTranslationMatrix(IEnumerable<T> list)
    {
      return GetTranslationMatrix(new ListOptimized<T>(list));
    }

    /// <summary>
    ///   The to array.
    /// </summary>
    /// <returns>
    ///   The T[]
    /// </returns>
    public T[] ToArray()
    {
      return _list.ToArray();
    }

    /// <summary>
    ///   The to list.
    /// </summary>
    /// <returns>
    ///   list
    /// </returns>
    public List<T> ToList()
    {
      return _list.ToList();
    }
  }
}