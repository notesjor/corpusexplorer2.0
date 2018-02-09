using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.EchtzeitEngine.CalculationPyramid.Model.Delegates;

namespace CorpusExplorer.Sdk.EchtzeitEngine.CalculationPyramid.Model
{
  public class PyramidLevel<T>
  {
    private PyramidAggregationDelegate<T> _aggregation;
    private PyramidLevel<T> _parent;
    private PyramidLevel<T> _subLevel;
    public T[] _cache = new T[1];
    private int _index = 0;

    private PyramidLevel() { }
    public PyramidLevel(PyramidAggregationDelegate<T> aggregationFunc) { _aggregation = aggregationFunc; }

    public PyramidLevel<T> Parent => _parent;
    public PyramidLevel<T> Sub => _subLevel;

    public void Add(T obj)
    {
      // Sink
      if (_subLevel != null)
      {
        _subLevel.Add(obj);
        return;
      }

      // Bubble
      _cache[_index] = obj;
      if (_index + 1 != _cache.Length)
      {
        _index++;
        return;
      }

      Parent.AddToParent(Value);
      _cache = new T[_cache.Length];
      _cache.Initialize();
      _index = 0;
    }

    private void AddToParent(T obj)
    {
      _cache[_index] = obj;
      if (_index + 1 != _cache.Length)
      {
        _index++;
        return;
      }

      Parent?.AddToParent(Value);
      _index = 0;
    }

    public T Value
    {
      get
      {
        if (_cache.Length == 1)
          return _cache[0];

        var res = _cache[0];
        for (int i = 1; i < _cache.Length; i++)
        {
          try
          {
            res = _aggregation(res, _cache[i]);
          }
          catch
          {
            break;
          }
        }
        return res;
      }
    }

    internal void SetLevelSpread(int spread)
    {
      spread = spread < 1 ? 1 : spread;
      _cache = new T[spread];
      _cache.Initialize();
      _subLevel = new PyramidLevel<T> { _parent = this, _aggregation = _aggregation };
    }
  }
}
