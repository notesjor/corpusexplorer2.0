using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  public class CorrespondingLayerValueBlock : AbstractSimple2LayerBlock
  {
    private readonly object _clvLock = new object();

    public Dictionary<string, HashSet<string>> CorrespondingLayerValues { get; set; }

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

      var tmp = new Dictionary<string, HashSet<string>>();

      for (var i = 0; i < doc1.Length; i++)
      {
        if (doc1[i].Length != doc2[i].Length)
          return;

        for (var j = 0; j < doc1[i].Length; j++)
        {
          var key = layer1[doc1[i][j]];
          if (tmp.ContainsKey(key))
            tmp[key].Add(layer2[doc2[i][j]]);
          else
            tmp.Add(key, new HashSet<string> {layer2[doc2[i][j]]});
        }
      }

      lock (_clvLock)
      {
        foreach (var x in tmp)
          if (CorrespondingLayerValues.ContainsKey(x.Key))
            foreach (var y in x.Value)
              CorrespondingLayerValues[x.Key].Add(y);
          else
            CorrespondingLayerValues.Add(x.Key, x.Value);
      }
    }

    protected override void CalculateCleanup()
    {
    }

    protected override void CalculateFinalize()
    {
    }

    protected override void CalculateInitProperties()
    {
      CorrespondingLayerValues = new Dictionary<string, HashSet<string>>();
    }
  }
}