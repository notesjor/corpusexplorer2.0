#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.Interfaces;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.Cache.Helper;
using CorpusExplorer.Sdk.Model.Cache.Helper.Exception;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

#endregion

namespace CorpusExplorer.Sdk.Blocks
{
  /// <summary>
  ///   The frequency of plw block.
  /// </summary>
  [Serializable]
  public class Frequency3LayerBlock
    : AbstractSimple3LayerBlock,
      IUseHydraSentenceOptimization,
      IProvideAggregatedDataItems
  {
    [NonSerialized] private readonly BlockCacheHelper _cache = new BlockCacheHelper();

    /// <summary>
    ///   The _lock 1.
    /// </summary>
    private readonly object _lock1 = new object();

    /// <summary>
    ///   The _lock 2.
    /// </summary>
    private readonly object _lock2 = new object();

    /// <summary>
    ///   The _lock 3.
    /// </summary>
    private readonly object _lock3 = new object();

    public Frequency3LayerBlock()
    {
      Layer1Displayname = "POS";
      Layer2Displayname = "Lemma";
      Layer3Displayname = "Wort";
      UseHydraOptimization = false;
    }

    /// <summary>
    ///   POS/Lemma/Wortform/Frequenz-Wörterbuch
    /// </summary>
    public Dictionary<string, Dictionary<string, Dictionary<string, double>>> Frequency { get; private set; }

    /// <summary>
    ///   Gebe eine aggregiertes Ergebnis des abgefragten Levels zurück.
    ///   Wenn null, dann gebe das aggregierte Ergebnis des Root-Levels zurück.
    /// </summary>
    /// <param name="level">Level</param>
    /// <returns>Wenn null, dann exsistieren auf diesem Level keine Items mehr die aggregiert werden könnten.</returns>
    public double? GetAggregatedValue(params string[] level)
    {
      switch (level.Length)
      {
        case 0:
          return Frequency.SelectMany(pos => pos.Value).SelectMany(lem => lem.Value).Sum(w => w.Value);
        case 1:
          return Frequency[level[0]].SelectMany(lem => lem.Value).Sum(w => w.Value);
        case 2:
          return Frequency[level[0]][level[1]].Sum(w => w.Value);
        case 3:
          return Frequency[level[0]][level[1]][level[2]];
        default:
          return null;
      }
    }

    /// <summary>
    ///   Gibt die Items des abgefragen Levels zurück.
    ///   Wenn null dann gebe die Items des Root-Levels zurück.
    /// </summary>
    /// <param name="level">Level</param>
    /// <returns>Wenn Level dann gibt es auf diesem Level keine Items mehr</returns>
    public IEnumerable<string> GetItems(params string[] level)
    {
      switch (level.Length)
      {
        case 0:
          return Frequency.Select(x => x.Key);
        case 1:
          return Frequency[level[0]].Select(x => x.Key);
        case 2:
          return Frequency[level[0]][level[1]].Select(x => x.Key);
        default:
          return null;
      }
    }

    public bool UseHydraOptimization { get; set; }

    /// <summary>
    ///   Führt die Berechnung aus
    /// </summary>
    /// <param name="corpus">
    ///   Korpus
    /// </param>
    /// <param name="dsel">
    ///   Dokument GUID
    /// </param>
    /// <param name="layer1">
    ///   Layer 1
    /// </param>
    /// <param name="doc1">
    ///   Dokument 1
    /// </param>
    /// <param name="layer2">
    ///   Layer 2
    /// </param>
    /// <param name="doc2">
    ///   Dokument 2
    /// </param>
    /// <param name="layer3">
    ///   Layer 3
    /// </param>
    /// <param name="doc3">
    ///   Dokument 3
    /// </param>
    protected override void CalculateCall(
      AbstractCorpusAdapter corpus,
      Guid dsel,
      AbstractLayerAdapter layer1,
      int[][] doc1,
      AbstractLayerAdapter layer2,
      int[][] doc2,
      AbstractLayerAdapter layer3,
      int[][] doc3)
    {
      if (UseHydraOptimization)
      {
        doc1 = Selection.HydraOptimization(corpus, dsel, doc1);
        doc2 = Selection.HydraOptimization(corpus, dsel, doc2);
        doc3 = Selection.HydraOptimization(corpus, dsel, doc3);
      }

      for (var i = 0; i < doc1.Length; i++)
      for (var j = 0; j < doc1[i].Length; j++)
      {
        var pos = layer1[doc1[i][j]];
        var lem = layer2[doc2[i][j]];
        var wor = layer3[doc3[i][j]];

        Dictionary<string, Dictionary<string, double>> level1;
        lock (_lock1)
        {
          if (!Frequency.TryGetValue(pos, out level1))
          {
            level1 = new Dictionary<string, Dictionary<string, double>>();
            Frequency.Add(pos, level1);
          }
        }

        Dictionary<string, double> level2;
        lock (_lock2)
        {
          if (!level1.TryGetValue(lem, out level2))
          {
            level2 = new Dictionary<string, double>();
            level1.Add(lem, level2);
          }
        }

        lock (_lock3)
        {
          if (level2.ContainsKey(wor))
            level2[wor]++;
          else
            level2.Add(wor, 1);
        }
      }
    }

    /// <summary>
    ///   Wird nach der Berechnung aufgerufen (nach CalculateCall)
    ///   und dient der Bereinigung von Daten
    /// </summary>
    protected override void CalculateCleanup()
    {
      if (Configuration.MinimumFrequency > 1)
        Frequency = Frequency.GetCleanDictionary(Configuration.MinimumFrequency);
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
      if (_cache.AbortCalculation(
                                  new Dictionary<string, object>
                                  {
                                    {nameof(Layer1Displayname), Layer1Displayname},
                                    {nameof(Layer2Displayname), Layer2Displayname},
                                    {nameof(Layer3Displayname), Layer3Displayname}
                                  }))
        throw new BlockAlreadyCachedException();

      Frequency = new Dictionary<string, Dictionary<string, Dictionary<string, double>>>();
    }
  }
}