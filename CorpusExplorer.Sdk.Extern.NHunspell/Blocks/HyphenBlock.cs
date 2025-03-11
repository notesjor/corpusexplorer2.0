#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Extern.NHunspell.Helper;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Extern.NHunspell.Blocks
{
#if UNIVERSAL
#else
  /// <summary>
  ///   The hyphen block.
  /// </summary>
  [Serializable]
  public class HyphenBlock : AbstractSimple1LayerBlock
  {
    [NonSerialized] private readonly object _lockHyphenAccess = new object();

    /// <summary>
    ///   The _lock hyphen frequency.
    /// </summary>
    [NonSerialized] private readonly object _lockHyphenFrequency = new object();

    /// <summary>
    ///   Silbe/Frequenz-Wörterbuch
    /// </summary>
    public Dictionary<string, int> HyphenFrequency { get; set; }

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
      foreach (var w in doc.SelectMany(s => s))
      {
        string[] keys;
        lock (_lockHyphenAccess)
        {
          try
          {
            keys = NHunspellConfiguration.Hyphen.Hyphenate(layer[w])
                                         .HyphenatedWord.Split(Splitter.Equal, StringSplitOptions.RemoveEmptyEntries);
          }
          catch
          {
            continue;
          }
        }

        lock (_lockHyphenFrequency)
        {
          foreach (var key in keys)
            if (HyphenFrequency.ContainsKey(key))
              HyphenFrequency[key]++;
            else
              HyphenFrequency.Add(key, 1);
        }
      }
    }

    /// <summary>
    ///   The calculate cleanup.
    /// </summary>
    protected override void CalculateCleanup()
    {
      if (Configuration.MinimumFrequency > 1)
        HyphenFrequency = HyphenFrequency.GetCleanDictionary(Configuration.MinimumFrequency);
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
      HyphenFrequency = new Dictionary<string, int>();
    }
  }
#endif
}