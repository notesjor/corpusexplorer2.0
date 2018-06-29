using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.Cache.Helper;
using CorpusExplorer.Sdk.Model.Cache.Helper.Exception;

#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

#endregion

namespace CorpusExplorer.Sdk.Blocks
{
  /// <summary>
  ///   The frequency custom single layer block.
  /// </summary>
  [Serializable]
  public class Frequency1LayerBlock : AbstractSimple1LayerBlock, IProvideAggregatedDataItems
  {
    [NonSerialized] private readonly BlockCacheHelper _cache = new BlockCacheHelper();

    /// <summary>
    ///   The _lock frequency.
    /// </summary>
    [NonSerialized] private object _lockFrequency;

    public Frequency1LayerBlock()
    {
      LayerDisplayname = "Wort";
    }

    /// <summary>
    ///   Wort/Frequenz-Wörterbuch
    /// </summary>
    public Dictionary<string, double> Frequency { get; set; }

    public Dictionary<string, double> FrequencyRelative
    {
      get
      {
        // ReSharper disable once UseNullPropagation
        if (Frequency == null)
          return null;

        var sum = Frequency.Sum(x => x.Value);
        return Frequency.ToDictionary(f => f.Key, f => f.Value / sum);
      }
    }

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
          return Frequency.Sum(w => w.Value);
        case 1:
          return Frequency[level[0]];
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
        default:
          return null;
      }
    }

    /// <summary>
    ///   The calculate call.
    /// </summary>
    /// <param name="corpus">
    ///   The corpus.
    /// </param>
    /// <param name="layer">
    ///   The layer.
    /// </param>
    /// <param name="dsel">
    ///   The dsel.
    /// </param>
    /// <param name="doc">
    ///   The doc.
    /// </param>
    protected override void CalculateCall(
      AbstractCorpusAdapter corpus,
      AbstractLayerAdapter layer,
      Guid dsel,
      int[][] doc)
    {
      foreach (var key in from s in doc from w in s select layer[w])
        if (key != null)
          lock (_lockFrequency)
          {
            if (Frequency.ContainsKey(key))
              Frequency[key]++;
            else
              Frequency.Add(key, 1);
          }
    }

    /// <summary>
    ///   The calculate cleanup.
    /// </summary>
    protected override void CalculateCleanup()
    {
      if (Configuration.MinimumFrequency > 1)
        Frequency = Frequency.GetCleanDictionary(Configuration.MinimumFrequency);
    }

    /// <summary>
    ///   The calculate finalize.
    /// </summary>
    protected override void CalculateFinalize()
    {
    }

    /// <summary>
    ///   The calculate init properties.
    /// </summary>
    protected override void CalculateInitProperties()
    {
      if (_cache.AbortCalculation(new Dictionary<string, object> {{nameof(LayerDisplayname), LayerDisplayname}}))
        throw new BlockAlreadyCachedException();

      Frequency = new Dictionary<string, double>();
      _lockFrequency = new object();
    }
  }
}