using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.Cache.Helper;

namespace CorpusExplorer.Sdk.Blocks
{
  /// <summary>
  ///   The frequency custom single layer block.
  /// </summary>
  [Serializable]
  public class Frequency1LayerSelectBlock : AbstractSimple1LayerBlock
  {
    [NonSerialized] private readonly BlockCacheHelper _cache = new BlockCacheHelper();
    private double _sum = 0.0;

    /// <summary>
    ///   The _lock frequency.
    /// </summary>
    [NonSerialized] private object _lockFrequency;

    public Frequency1LayerSelectBlock()
    {
      LayerDisplayname = "Wort";
    }

    public IEnumerable<string> LayerQueries
    {
      get => Frequency?.Keys;
      set
      {
        var hash = new HashSet<string>(value ?? Enumerable.Empty<string>());
        Frequency = hash.ToDictionary(k => k, k => 0.0);
      }
    }

    /// <summary>
    ///   Wort/Frequenz-Wörterbuch
    /// </summary>
    public Dictionary<string, double> Frequency { get; set; } = new Dictionary<string, double>();

    public Dictionary<string, double> FrequencyRelative
    {
      get
      {
        // ReSharper disable once UseNullPropagation
        if (Frequency == null)
          return null;

        return Frequency.ToDictionary(f => f.Key, f => f.Value / _sum);
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
      var tmp = new Dictionary<string, double>();
      foreach (var key in from s in doc from w in s select layer[w])
        if (key != null && Frequency.ContainsKey(key))
          if (tmp.ContainsKey(key))
            tmp[key]++;
          else
            tmp.Add(key, 1);

      lock (_lockFrequency)
        foreach (var t in tmp)
          Frequency[t.Key] += t.Value;
    }

    /// <summary>
    ///   The calculate cleanup.
    /// </summary>
    protected override void CalculateCleanup()
    {
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
      _sum = (double)Selection.CountToken;
      _lockFrequency = new object();
    }
  }
}