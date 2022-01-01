#region

using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks
{
  /// <summary>
  ///   Kann z. B. genutzt werden um alle Wort-Werte zu erhalten denen der POS-Wert NE zugeordnet ist.
  /// </summary>
  public class CorrespondingLayerValueFilterBlock : AbstractSimple2LayerBlock
  {
    private readonly object _clvLock = new object();

    /// <summary>
    ///   Gibt alle Layer1Values zurück, die eine Übereistimmung (anderer Layer) mit Layer2ValueFilter haben.
    /// </summary>
    public HashSet<string> Layer1FilterValueResults { get; set; } = new HashSet<string>();

    public HashSet<string> Layer2ValueFilters { get; set; } = new HashSet<string>();

    protected override void CalculateCall(
      AbstractCorpusAdapter corpus,
      Guid dsel,
      AbstractLayerAdapter layer1,
      int[][] doc1,
      AbstractLayerAdapter layer2,
      int[][] doc2)
    {
      if (doc1.Length != doc2.Length)
        return;

      var tmp = new HashSet<string>();

      for (var i = 0; i < doc1.Length; i++)
      {
        if (doc1[i].Length != doc2[i].Length)
          return;

        for (var j = 0; j < doc1[i].Length; j++)
          if (Layer2ValueFilters.Contains(layer2[doc2[i][j]]))
            tmp.Add(layer1[doc1[i][j]]);
      }

      lock (_clvLock)
        foreach (var x in tmp)
          Layer1FilterValueResults.Add(x);
    }

    protected override void CalculateCleanup()
    {
    }

    protected override void CalculateFinalize()
    {
    }

    protected override void CalculateInitProperties()
    {
      Layer1FilterValueResults = new HashSet<string>();
    }
  }
}