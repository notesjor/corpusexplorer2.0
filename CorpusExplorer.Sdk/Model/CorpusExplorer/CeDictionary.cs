#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Model.CorpusExplorer
{
  /// <summary>
  ///   The ce dictionary.
  /// </summary>
  [Serializable]
  public sealed class CeDictionary : IEnumerable<KeyValuePair<int, string>>, IDisposable
  {
    /// <summary>
    ///   The _d 1.
    /// </summary>
    private readonly Dictionary<int, string> _d1 = new Dictionary<int, string>();

    /// <summary>
    ///   The _d 2.
    /// </summary>
    [NonSerialized] private Dictionary<string, int> _d2 = new Dictionary<string, int>();

    /// <summary>
    ///   Initializes a new instance of the <see cref="CeDictionary" /> class.
    /// </summary>
    /// <param name="dic">
    ///   The dic.
    /// </param>
    public CeDictionary(IEnumerable<string> dic)
    {
      _d2 = new Dictionary<string, int> {{string.Empty, -1}};
      foreach (var x in dic)
        _d2.Add(x, _d2.Count);

      _d1 = _d2.ToDictionary(x => x.Value, x => x.Key);
    }

    /// <summary>
    ///   Initializes a new instance of the <see cref="CeDictionary" /> class.
    /// </summary>
    /// <param name="dic">
    ///   The dic.
    /// </param>
    public CeDictionary(Dictionary<string, int> dic)
    {
      if (!dic.ContainsKey(string.Empty))
        dic.Add(string.Empty, -1);

      _d2 = dic;
      _d1 = _d2.ToDictionary(x => x.Value, x => x.Key);
    }

    /// <summary>
    ///   Initializes a new instance of the <see cref="CeDictionary" /> class.
    /// </summary>
    /// <param name="dic">
    ///   The dic.
    /// </param>
    public CeDictionary(Dictionary<int, string> dic)
    {
      if (!dic.ContainsKey(-1))
        dic.Add(-1, string.Empty);

      _d1 = dic;
      _d2 = _d1.ToDictionary(x => x.Value, x => x.Key);
    }

    /// <summary>
    ///   Prevents a default instance of the <see cref="CeDictionary" /> class from being created.
    /// </summary>
    private CeDictionary()
    {
    }

    /// <summary>
    ///   Gets the count.
    /// </summary>
    public int Count => _d1.Count;

    public IEnumerable<int> Indices
    {
      get { return _d1.Select(x => x.Key); }
    }

    /// <summary>
    ///   The this.
    /// </summary>
    /// <param name="label">
    ///   The label.
    /// </param>
    /// <returns>
    ///   The <see cref="int" />.
    /// </returns>
    public int this[string label]
    {
      get
      {
        try
        {
          return string.IsNullOrEmpty(label) ? -1 : _d2.ContainsKey(label) ? _d2[label] : -1;
        }
        catch
        {
          return -1;
        }
      }
    }

    /// <summary>
    ///   The this.
    /// </summary>
    /// <param name="index">
    ///   The index.
    /// </param>
    /// <returns>
    ///   The <see cref="string" />.
    /// </returns>
    public string this[int index]
    {
      get
      {
        try
        {
          return index == -1 ? string.Empty : _d1.ContainsKey(index) ? _d1[index] : string.Empty;
        }
        catch
        {
          return string.Empty;
        }
      }
    }

    /// <summary>
    ///   Gets the values.
    /// </summary>
    public IEnumerable<string> Values
    {
      get { return _d1.Select(x => x.Value); }
    }

    /// <summary>
    ///   The get enumerator.
    /// </summary>
    /// <returns>
    ///   The <see cref="IEnumerator" />.
    /// </returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    /// <summary>
    ///   The get enumerator.
    /// </summary>
    /// <returns>
    ///   The <see cref="IEnumerator" />.
    /// </returns>
    public IEnumerator<KeyValuePair<int, string>> GetEnumerator()
    {
      return _d1.GetEnumerator();
    }

    /// <summary>
    ///   The add.
    /// </summary>
    /// <param name="value">
    ///   The value.
    /// </param>
    public int Add(string value)
    {
      if (_d2.ContainsKey(value))
        return _d2[value];

      var idx = _d1.Count;
      while (_d1.ContainsKey(idx))
        idx++;

      _d1.Add(idx, value);
      _d2.Add(value, idx);

      return idx;
    }

    public void AddForcedKeyValuePair(KeyValuePair<string, int> value)
    {
      if (_d2.ContainsKey(value.Key))
        return;

      if (_d1.ContainsKey(value.Value))
        return;

      _d1.Add(value.Value, value.Key);
      _d2.Add(value.Key, value.Value);
    }

    public CeDictionary Clone()
    {
      return new CeDictionary(_d2.ToArray().ToDictionary(x => x.Key, x => x.Value));
    }

    /// <summary>
    ///   The contains.
    /// </summary>
    /// <param name="value">
    ///   The value.
    /// </param>
    /// <returns>
    ///   The <see cref="bool" />.
    /// </returns>
    public bool Contains(string value)
    {
      return _d2.ContainsKey(value);
    }

    /// <summary>
    ///   The intern redefine value.
    /// </summary>
    /// <param name="oldValue">
    ///   The old value.
    /// </param>
    /// <param name="newValue">
    ///   The new value.
    /// </param>
    /// <exception cref="KeyNotFoundException">
    /// </exception>
    public void InternRedefineValue(string oldValue, string newValue)
    {
      if (!_d2.ContainsKey(oldValue))
        throw new KeyNotFoundException($"Parameter oldValue ({oldValue}) is not a valid key");

      if (_d2.ContainsKey(newValue))
        throw new KeyNotFoundException($"Parameter newValue ({newValue}) is already present in the CeDictionary");

      var oidx = _d2[oldValue];
      _d1.Remove(oidx);
      _d2.Remove(oldValue);

      _d1.Add(oidx, newValue);
      _d2.Add(newValue, oidx);
    }

    public Dictionary<int, int> Merge(Dictionary<string, int> newValues)
    {
      var res = new Dictionary<int, int>();
      foreach (var newValue in newValues)
      {
        if (!_d2.ContainsKey(newValue.Key))
        {
          var idx = _d1.Count;
          _d1.Add(idx, newValue.Key);
          _d2.Add(newValue.Key, idx);
        }

        res.Add(newValue.Value, _d2[newValue.Key]);
      }

      return res;
    }

    public IEnumerable<KeyValuePair<int, string>> ReciveRawIndexToValue()
    {
      return _d1;
    }

    public IEnumerable<KeyValuePair<string, int>> ReciveRawValueToIndex()
    {
      return _d2;
    }

    public void RefreshDictionaries()
    {
      if (_d2       == null ||
          _d2.Count == 0)
        OnDeserialized(new StreamingContext());
    }

    /// <summary>
    ///   Löscht einen bestehenden Layerwert
    /// </summary>
    /// <param name="layerValue">Layerwert-Bezeichnung</param>
    public void Remove(string layerValue)
    {
      if (!_d2.ContainsKey(layerValue))
        return;

      var idx = _d2[layerValue];

      _d2.Remove(layerValue);
      _d1.Remove(idx);
    }

    /// <summary>
    ///   Benennt einen Layerwert um. Wenn der neue Layerwert bereits exisitiert wird ein merge durchgeführt.
    /// </summary>
    /// <param name="layerValueOld">Alter Layerwert-Bezeichnung</param>
    /// <param name="layerValueNew">Neue Layerwert-Bezeichnung</param>
    public void RenameValue(string layerValueOld, string layerValueNew)
    {
      if (!_d2.ContainsKey(layerValueOld))
        return;

      var idx = _d2[layerValueOld];
      _d2.Remove(layerValueOld);
      _d2.Add(layerValueNew, idx);
      _d1[idx] = layerValueNew;
    }

    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
      try
      {
        _d2 = _d1.ToDictionary(x => x.Value, x => x.Key);
      }
      catch // Fallback
      {
        _d2 = new Dictionary<string, int>();
        foreach (var entry in _d1.Where(entry => !_d2.ContainsKey(entry.Value)))
          _d2.Add(entry.Value, entry.Key);
      }
    }

    public void Dispose()
    {
      _d1.Clear();
      _d2.Clear();
    }
  }
}