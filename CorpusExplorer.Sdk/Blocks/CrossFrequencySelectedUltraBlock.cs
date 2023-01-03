using System.Linq;
using CorpusExplorer.Sdk.Blocks.CrossFrequencySelected;
using CorpusExplorer.Sdk.Blocks.CrossFrequencySelected.Abstract;
using CorpusExplorer.Sdk.Blocks.Interfaces;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.Cache.Helper;
using CorpusExplorer.Sdk.Model.Cache.Helper.Exception;
using CorpusExplorer.Sdk.Utils.Filter;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

#region

using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Helper;
using System;
using System.Collections.Generic;

#endregion

namespace CorpusExplorer.Sdk.Blocks
{
  /// <summary>
  ///   Class CrossFrequencyBlock.
  /// </summary>
  [Serializable]
  public class CrossFrequencySelectedUltraBlock : AbstractSimple1LayerBlock, IUseMemoryOverflowProtection
  {
    [NonSerialized] private readonly BlockCacheHelper _cache = new BlockCacheHelper();

    private Dictionary<string, Dictionary<string, double>> _cooccurrencesFrequency;

    /// <summary>
    ///   The _lock collocates frequency
    /// </summary>
    [NonSerialized] private object _resultLock;

    private Dictionary<Guid, Dictionary<Guid, HashSet<int>>> _search;
    private HashSet<string> _queries;

    /// <summary>
    ///   Wort/Kollokator/Frequenz-Wörterbuch
    /// </summary>
    /// <value>The collocates frequency.</value>
    public Dictionary<string, Dictionary<string, double>> CooccurrencesFrequency => _cooccurrencesFrequency;

    public bool ProtectMemoryOverflow { get; set; } = Configuration.ProtectMemoryOverflow;

    public IEnumerable<string> LayerQueries { get; set; }

    /// <summary>
    ///   Führt die Berechnung aus
    /// </summary>
    /// <param name="corpus">
    ///   Korpus
    /// </param>
    /// <param name="layer">
    ///   Layer
    /// </param>
    /// <param name="dsel">
    ///   Dokument GUID
    /// </param>
    /// <param name="doc">
    ///   Dokument
    /// </param>
    protected override void CalculateCall(
      AbstractCorpusAdapter corpus,
      AbstractLayerAdapter layer,
      Guid dsel,
      int[][] doc)
    {
      if (!_search.ContainsKey(corpus.CorpusGuid) || !_search[corpus.CorpusGuid].ContainsKey(dsel))
        return;

      var freq = _queries.ToDictionary(x => x, x => new Dictionary<string, double>());
      var sentences = _search[corpus.CorpusGuid][dsel];

      foreach (var s in from sentence in sentences where sentence >= 0 && sentence < doc.Length select doc[sentence] into s where !ProtectMemoryOverflow || s.Length <= 250 select s)
      {
        GetUniqueTokens(layer, s, out var keys, out var cooc);
        foreach (var k in keys)
          foreach (var c in cooc)
            if (freq[k].ContainsKey(c))
              freq[k][c]++;
            else
              freq[k].Add(c, 1);
      }

      lock (_resultLock)
      {
        DictionaryMergeHelper.Merge2LevelDictionary(ref _cooccurrencesFrequency, freq, (x, y) => x + y);
      }
    }

    private void GetUniqueTokens(AbstractLayerAdapter layer, int[] s, out List<string> keys, out List<string> cooc)
    {
      var temp = new HashSet<int>();
      foreach (var w in s)
        temp.Add(w);

      keys = new List<string>();
      cooc = new List<string>();

      foreach (var x in temp.Select(x => layer[x]).OrderBy(x => x))
        if (_queries.Contains(x))
          keys.Add(x);
        else
          cooc.Add(x);
    }

    /// <summary>
    ///   Wird nach der Berechnung aufgerufen (nach CalculateCall)
    ///   und dient der Bereinigung von Daten
    /// </summary>
    protected override void CalculateCleanup()
    {
      if (Configuration.MinimumFrequency > 1)
        _cooccurrencesFrequency = CooccurrencesFrequency.GetCleanDictionary(Configuration.MinimumFrequency);
    }

    /// <summary>
    ///   Wird nach der Bereinigung aufgerufen (nach CalculateCall + CalculateCleanup)
    ///   und dient dem zusammenfassen der bereinigen Ergebnisse
    /// </summary>
    protected override void CalculateFinalize()
    {
    }

    public AbstractCrossFrequencySelectedBehaviour Behaviour { get; set; }
      = new CrossFrequencySelectedBehaviourAnyMatch();

    /// <summary>
    ///   Wird vor der Berechnung aufgerufen (vor CalculateCall)
    /// </summary>
    protected override void CalculateInitProperties()
    {
      if (_cache.AbortCalculation(new Dictionary<string, object> { { nameof(LayerDisplayname), LayerDisplayname } }))
        throw new BlockAlreadyCachedException();

      _queries = new HashSet<string>(LayerQueries);
      _search = QuickQuery.SearchOnSentenceLevel(Selection, Behaviour.GetFilterQuery(LayerDisplayname, LayerQueries));
      _cooccurrencesFrequency = new Dictionary<string, Dictionary<string, double>>();
      _resultLock = new object();
      TotalMatches = (from x in _search from y in x.Value select y.Value.Count).Sum();
    }

    public int TotalMatches { get; private set; }
  }
}