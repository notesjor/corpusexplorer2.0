using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.Cache.Helper;
using CorpusExplorer.Sdk.Model.Cache.Helper.Exception;

namespace CorpusExplorer.Sdk.Blocks
{
  /// <summary>
  ///   The frequency custom single layer block.
  /// </summary>
  [Serializable]
  public class Frequency1LayerOneOccurrenceBlock : AbstractSimple1LayerBlock
  {
    [NonSerialized] private readonly BlockCacheHelper _cache = new BlockCacheHelper();

    /// <summary>
    ///   The _lock frequency.
    /// </summary>
    [NonSerialized] private object _lockFrequency;

    public Frequency1LayerOneOccurrenceBlock()
    {
      LayerDisplayname = "Wort";
    }

    /// <summary>
    ///   Wort/Frequenz-Wörterbuch
    /// </summary>
    public Dictionary<string, double> Frequency { get; set; }


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
      foreach (var s in doc)
      {
        var hash = new HashSet<string>();
        foreach (var key in s.Select(w => layer[w]).Where(key => !hash.Contains(key)))
        {
          hash.Add(key);

          lock (_lockFrequency)
          {
            if (Frequency.ContainsKey(key))
              Frequency[key]++;
            else
              Frequency.Add(key, 1);
          }
        }
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