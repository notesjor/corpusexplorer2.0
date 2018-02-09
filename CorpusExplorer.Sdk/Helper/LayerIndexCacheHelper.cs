using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Helper
{
  public class LayerIndexCacheHelper
  {
    private readonly Dictionary<Guid, HashSet<int>> _cache = new Dictionary<Guid, HashSet<int>>();

    public HashSet<int> GetCache(AbstractLayerAdapter layer, IEnumerable<string> values)
    {
      if (_cache.ContainsKey(layer.Guid))
        return _cache[layer.Guid];

      var hashSet = new HashSet<int>();
      foreach (var idx in values.Select(value => layer[value]).Where(idx => idx != -1))
        hashSet.Add(idx);

      _cache.Add(layer.Guid, hashSet);
      return hashSet;
    }
  }
}