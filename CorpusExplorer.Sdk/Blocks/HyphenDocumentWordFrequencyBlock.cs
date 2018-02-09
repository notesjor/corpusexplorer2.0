using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  /// <summary>
  ///   The hyphen block.
  /// </summary>
  [Serializable]
  public class HyphenDocumentWordFrequencyBlock : AbstractSimple1LayerBlock
  {
    /// <summary>
    ///   The _lock hyphen frequency.
    /// </summary>
    [NonSerialized]
    private readonly object _lockHyphenFrequency = new object();

    private Dictionary<string, IEnumerable<string>> _dic;

    /// <summary>
    ///   Silbe/Frequenz-Wörterbuch
    /// </summary>
    public Dictionary<Guid, Dictionary<string, Dictionary<string, int>>> HyphenFrequency { get; set; }

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
      var res = new Dictionary<string, Dictionary<string, int>>();
      foreach (var w in doc.SelectMany(s => s))
      {
        var key = layer[w];
        if (!_dic.ContainsKey(key))
          continue;
        var vals = _dic[key];
        foreach (var val in vals)
          if (res.ContainsKey(val))
            if (res[val].ContainsKey(key))
              res[val][key] += 1;
            else
              res[val].Add(key, 1);
          else
            res.Add(val, new Dictionary<string, int> {{key, 1}});
      }
      lock (_lockHyphenFrequency)
      {
        HyphenFrequency.Add(dsel, res);
      }
    }

    /// <summary>
    ///   The calculate cleanup.
    /// </summary>
    protected override void CalculateCleanup()
    {
      _dic.Clear();
    }

    /// <summary>
    ///   The calculate finalize.
    /// </summary>
    protected override void CalculateFinalize() { }

    /// <summary>
    ///   The calculate init properties.
    /// </summary>
    protected override void CalculateInitProperties()
    {
      HyphenFrequency = new Dictionary<Guid, Dictionary<string, Dictionary<string, int>>>();
      var block = Selection.CreateBlock<WordHyphenResolverBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.Calculate();

      _dic = block.WordHyphens;
    }
  }
}