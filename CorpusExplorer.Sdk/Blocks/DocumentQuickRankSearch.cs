using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  public class DocumentQuickRankSearch : AbstractSimple1LayerBlock
  {
    private readonly object _getLayerHashLock = new object();
    private readonly object _resultLock = new object();
    private double _count;
    private Dictionary<Guid, HashSet<int>> _layerCache;
    private IEnumerable<string> _layerQueries;

    public DocumentQuickRankSearch()
    {
      LayerDisplayname = "Wort";
      LayerQueries = new List<string>();
    }

    public IEnumerable<string> LayerQueries
    {
      get => _layerQueries;
      set
      {
        _layerQueries = value;
        _count = _layerQueries.Count();
      }
    }

    /// <summary>
    ///   Key = DocumentGuid / Value.Key = Relative LayerQueries (Types) found / Value.Value = Sum of LayerQueries (Token)
    ///   found
    /// </summary>
    public Dictionary<Guid, KeyValuePair<double, int>> ResultDocumentSentenceRank { get; set; }

    protected override void CalculateCall(
      AbstractCorpusAdapter corpus,
      AbstractLayerAdapter layer,
      Guid dsel,
      int[][] doc)
    {
      var values = GetLayerHash(layer);
      var sum = 0;
      var done = new HashSet<int>();

      foreach (var s in doc)
      foreach (var w in s)
      {
        if (!values.Contains(w))
          continue;
        sum++;
        done.Add(w);
      }

      lock (_resultLock)
      {
        ResultDocumentSentenceRank.Add(dsel, new KeyValuePair<double, int>(done.Count / _count, sum));
      }
    }

    protected override void CalculateCleanup()
    {
      _layerCache.Clear();
    }

    protected override void CalculateFinalize()
    {
    }

    protected override void CalculateInitProperties()
    {
      _layerCache = new Dictionary<Guid, HashSet<int>>();
      ResultDocumentSentenceRank = new Dictionary<Guid, KeyValuePair<double, int>>();
    }

    private HashSet<int> GetLayerHash(AbstractLayerAdapter layer)
    {
      lock (_getLayerHashLock)
      {
        if (_layerCache.ContainsKey(layer.Guid))
          return _layerCache[layer.Guid];

        var hash = new HashSet<int>(LayerQueries.Select(query => layer[query]));
        _layerCache.Add(layer.Guid, hash);
        return hash;
      }
    }
  }
}