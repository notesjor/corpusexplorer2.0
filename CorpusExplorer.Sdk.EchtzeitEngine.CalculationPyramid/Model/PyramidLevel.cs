using CorpusExplorer.Sdk.EchtzeitEngine.CalculationPyramid.Model.Delegates;

namespace CorpusExplorer.Sdk.EchtzeitEngine.CalculationPyramid.Model
{
  public class PyramidLevel<T>
  {
    private PyramidAggregationDelegate<T> _aggregation;
    public T[] _cache = new T[1];
    private int _index;

    public PyramidLevel(PyramidAggregationDelegate<T> aggregationFunc)
    {
      _aggregation = aggregationFunc;
    }

    private PyramidLevel()
    {
    }

    public PyramidLevel<T> Parent { get; private set; }

    public PyramidLevel<T> Sub { get; private set; }

    public T Value
    {
      get
      {
        if (_cache.Length == 1)
          return _cache[0];

        var res = _cache[0];
        for (int i = 1; i < _cache.Length; i++)
          try
          {
            res = _aggregation(res, _cache[i]);
          }
          catch
          {
            break;
          }

        return res;
      }
    }

    public void Add(T obj)
    {
      // Sink
      if (Sub != null)
      {
        Sub.Add(obj);
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

    internal void SetLevelSpread(int spread)
    {
      spread = spread < 1 ? 1 : spread;
      _cache = new T[spread];
      _cache.Initialize();
      Sub = new PyramidLevel<T> {Parent = this, _aggregation = _aggregation};
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
  }
}