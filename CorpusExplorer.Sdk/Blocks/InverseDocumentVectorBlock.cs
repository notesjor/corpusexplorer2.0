using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class InverseDocumentVectorBlock : AbstractSimple1LayerBlock
  {
    private readonly object _lockInverseDocumentVector = new object();
    private Dictionary<string, double> _idf;

    public InverseDocumentVectorBlock()
    {
      LayerDisplayname = "Wort";
    }

    public Dictionary<Guid, Dictionary<string, double>> InverseDocumentVector { get; private set; }
    public double MinimumInversDocumentFrequency { get; set; } = 0.003d;

    protected override void CalculateCall(
      AbstractCorpusAdapter corpus,
      AbstractLayerAdapter layer,
      Guid dsel,
      int[][] doc)
    {
      var count = 0.0;
      var dic = new Dictionary<string, double>();

      foreach (var s in doc)
      {
        count += s.Length;
        foreach (var w in s)
        {
          var key = layer[w];
          if (dic.ContainsKey(key))
            dic[key]++;
          else
            dic.Add(key, 1);
        }
      }

      var idv =
        dic.Where(x => _idf.ContainsKey(x.Key))
          .ToDictionary(x => x.Key, x => x.Value / count * _idf[x.Key])
          .Where(x => x.Value > MinimumInversDocumentFrequency)
          .ToDictionary(x => x.Key, x => x.Value);

      lock (_lockInverseDocumentVector)
      {
        InverseDocumentVector.Add(dsel, idv);
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
      var fBlock = Selection.CreateBlock<InverseDocumentTermFrequencyBlock>();
      fBlock.LayerDisplayname = LayerDisplayname;
      fBlock.Calculate();
      _idf = fBlock.InverseDocumentTermFrequency;
      InverseDocumentVector = new Dictionary<Guid, Dictionary<string, double>>();
    }
  }
}