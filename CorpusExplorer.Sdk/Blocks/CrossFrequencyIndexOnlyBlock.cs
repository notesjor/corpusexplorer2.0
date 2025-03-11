using System.Linq;
using CorpusExplorer.Sdk.Blocks.Interfaces;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.Cache.Helper;
using CorpusExplorer.Sdk.Model.Cache.Helper.Exception;

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
  public class CrossFrequencyIndexOnlyBlock : AbstractSimple1LayerBlock, IUseMemoryOverflowProtection
  {
    private Dictionary<int, Dictionary<int, double>> _cooccurrencesFrequency;

    /// <summary>
    ///   The _lock collocates frequency
    /// </summary>
    [NonSerialized] private object _resultLock;

    /// <summary>
    ///   Wort/Kollokator/Frequenz-Wörterbuch
    /// </summary>
    /// <value>The collocates frequency.</value>
    public Dictionary<int, Dictionary<int, double>> CooccurrencesFrequency => _cooccurrencesFrequency;

    public bool ProtectMemoryOverflow { get; set; } = Configuration.ProtectMemoryOverflow;

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
      var freq = new Dictionary<int, Dictionary<int, double>>();

      foreach (var s in doc)
      {
        // MemoryOverflowProtection - muss explizit aktiviert werden
        // Verhindert, dass Sätze mit mehr als 250 Token ausgewertet werden.
        if (ProtectMemoryOverflow && s.Length > 250)
          continue;

        // Zähle nur einmal pro Satz (HashSet)
        var temp = new HashSet<int>();

        foreach (var w in s)
          temp.Add(w);

        // OrderBy ist nötig um eine konsistente Reihung zu erhalten.
        var values = temp.OrderBy(x => x).ToArray();

        // Baue freq auf.
        for (var i = 0; i < values.Length; i++)
          for (var j = i; j < values.Length; j++)
            if (freq.ContainsKey(values[i]))
              if (freq[values[i]].ContainsKey(values[j]))
                freq[values[i]][values[j]]++;
              else
                freq[values[i]].Add(values[j], 1d);
            else
              freq.Add(values[i], new Dictionary<int, double> { { values[j], 1d } });
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

    /// <summary>
    ///   Wird vor der Berechnung aufgerufen (vor CalculateCall)
    /// </summary>
    protected override void CalculateInitProperties()
    {
      _cooccurrencesFrequency = new Dictionary<int, Dictionary<int, double>>();
      _resultLock = new object();
    }
  }
}