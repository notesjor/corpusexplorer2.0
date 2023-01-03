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
  public class CrossFrequencySelectedBlock : AbstractSimple1LayerBlock, IUseMemoryOverflowProtection
  {
    [NonSerialized] private readonly BlockCacheHelper _cache = new BlockCacheHelper();

    private Dictionary<string, Dictionary<string, double>> _cooccurrencesFrequency;

    /// <summary>
    ///   The _lock collocates frequency
    /// </summary>
    [NonSerialized] private object _resultLock;

    private Dictionary<Guid, Dictionary<Guid, HashSet<int>>> _search;

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

      var freq = new Dictionary<string, Dictionary<string, double>>();
      var sentences = _search[corpus.CorpusGuid][dsel];

      foreach (var sentence in sentences)
      {
        if (sentence < 0 || sentence >= doc.Length)
          continue;
        var s = doc[sentence];

        // MemoryOverflowProtection - muss explizit aktiviert werden
        // Verhindert, dass Sätze mit mehr als 250 Token ausgewertet werden.
        if (ProtectMemoryOverflow && s.Length > 250)
          continue;

        // Zähle nur einmal pro Satz (HashSet)
        var temp = new HashSet<int>();

        foreach (var w in s)
          temp.Add(w);

        // OrderBy ist nötig um eine konsistente Reihung zu erhalten.
        var values = temp.Select(x => layer[x]).OrderBy(x => x).ToArray();

        // Baue freq auf.
        for (var i = 0; i < values.Length; i++)
        for (var j = i; j < values.Length; j++)
          if (freq.ContainsKey(values[i]))
            if (freq[values[i]].ContainsKey(values[j]))
              freq[values[i]][values[j]]++;
            else
              freq[values[i]].Add(values[j], 1d);
          else
            freq.Add(values[i], new Dictionary<string, double> {{values[j], 1d}});
      }

      lock (_resultLock)
      {
        DictionaryMergeHelper.Merge2LevelDictionary(ref _cooccurrencesFrequency, freq, (x, y) => x + y);
      }
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
      if (_cache.AbortCalculation(new Dictionary<string, object> {{nameof(LayerDisplayname), LayerDisplayname}}))
        throw new BlockAlreadyCachedException();

      _search = QuickQuery.SearchOnSentenceLevel(Selection, Behaviour.GetFilterQuery(LayerDisplayname, LayerQueries) );
      _cooccurrencesFrequency = new Dictionary<string, Dictionary<string, double>>();
      _resultLock = new object();
      TotalMatches = (from x in _search from y in x.Value select y.Value.Count).Sum();
    }

    public int TotalMatches { get; private set; }
  }
}