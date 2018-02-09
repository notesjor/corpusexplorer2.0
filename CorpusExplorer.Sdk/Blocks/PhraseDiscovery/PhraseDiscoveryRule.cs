using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks.PhraseDiscovery
{
  public class PhraseDiscoveryRule
  {
    private readonly LayerIndexCacheHelper _cache = new LayerIndexCacheHelper();
    private readonly IEnumerable<string> _queries;

    public PhraseDiscoveryRule(int indexModification, IEnumerable<string> queries)
    {
      IndexModification = indexModification;
      _queries = queries;
    }

    public int IndexModification { get; }

    public bool Validate(
      AbstractLayerAdapter layer,
      int[] sentence,
      int wIdx,
      IEnumerable<PhraseDiscoveryRule> preRules)
    {
      if (preRules != null)
        if (preRules.Any(rule => !rule.Validate(layer, sentence, wIdx, null)))
          return false;

      var test = wIdx + IndexModification;
      if (test < 0 ||
          test >= sentence.Length)
        return false;

      return _cache.GetCache(layer, _queries).Contains(sentence[test]);
    }
  }
}