#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace CorpusExplorer.Sdk.Model.CorpusExplorer
{
  /// <summary>
  ///   The ce dictionary.
  /// </summary>
  [Serializable]
  public sealed class CeTriple<TA, TB, TC>
  {
    private readonly List<int[]> _data = new List<int[]>();

    [NonSerialized]
    private readonly Dictionary<TA, int> _dicA = new Dictionary<TA, int>();

    [NonSerialized]
    private readonly Dictionary<TB, int> _dicB = new Dictionary<TB, int>();

    [NonSerialized]
    private readonly Dictionary<TC, int> _dicC = new Dictionary<TC, int>();

    private readonly Dictionary<int, TA> _resA = new Dictionary<int, TA>();
    private readonly Dictionary<int, TB> _resB = new Dictionary<int, TB>();
    private readonly Dictionary<int, TC> _resC = new Dictionary<int, TC>();

    public IEnumerable<TA> As => _dicA.Keys;
    public IEnumerable<TB> Bs => _dicB.Keys;
    public IEnumerable<TC> Cs => _dicC.Keys;

    public IEnumerable<Tuple<TA, TB, TC>> Triples
      => _data.Select(x => new Tuple<TA, TB, TC>(_resA[x[0]], _resB[x[1]], _resC[x[2]]));

    public void Add(TA a, TB b, TC c)
    {
      if (!_dicA.ContainsKey(a))
      {
        var i = _dicA.Count;
        _dicA.Add(a, i);
        _resA.Add(i, a);
      }
      if (!_dicB.ContainsKey(b))
      {
        var i = _dicB.Count;
        _dicB.Add(b, i);
        _resB.Add(i, b);
      }
      if (!_dicC.ContainsKey(c))
      {
        var i = _dicC.Count;
        _dicC.Add(c, i);
        _resC.Add(i, c);
      }

      _data.Add(new[] {_dicA[a], _dicB[b], _dicC[c]});
    }

    private IEnumerable<T> Request<T>(int idxQuery, int value, RequestDelegate<T> func)
    {
      var res = new HashSet<T>();
      foreach (var x in _data)
        if (x[idxQuery] == value)
          res.Add(func(x));
      return res;
    }

    public IEnumerable<TA> RequestAllAs(TB b) { return Request(1, _dicB[b], x => _resA[x[0]]); }

    public IEnumerable<TA> RequestAllAs(TC c) { return Request(2, _dicC[c], x => _resA[x[0]]); }

    public IEnumerable<TB> RequestAllBs(TA a) { return Request(0, _dicA[a], x => _resB[x[1]]); }

    public IEnumerable<TB> RequestAllBs(TC c) { return Request(2, _dicC[c], x => _resB[x[1]]); }

    public IEnumerable<TC> RequestAllCs(TA a) { return Request(0, _dicA[a], x => _resC[x[2]]); }

    public IEnumerable<TC> RequestAllCs(TB b) { return Request(1, _dicB[b], x => _resC[x[2]]); }

    private delegate T RequestDelegate<out T>(int[] data);
  }
}