#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.Similarity.Abstract;
using CorpusExplorer.Sdk.Model;

#endregion

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class ClusterMetadataByNgramBlock : AbstractClusterMetadataBlock<Dictionary<string, double>>
  {
    public int NGramMinFrequency { get; set; }

    public string NGramPattern { get; set; }

    public int NGramPatternSize { get; set; }

    public int NGramSize { get; set; }

    protected override double CalculateDistance(
      AbstractDistance similarityIndex, Dictionary<string, double> a, Dictionary<string, double> b)
    {
      return similarityIndex.CalculateSimilarity(
                                                 a.ToDictionary(x => x.Key, x => x.Value),
                                                 b.ToDictionary(x => x.Key, x => x.Value));
    }

    protected override Dictionary<string, double> CalculateValues(Selection selection)
    {
      var block = selection.CreateBlock<Ngram1LayerPatternBlock>();
      block.NGramSize = NGramSize;
      block.NGramPattern = NGramPattern;
      block.NGramPatternSize = NGramPatternSize;
      block.LayerDisplayname = LayerDisplayname;
      block.Calculate();

      return NGramMinFrequency > 0
               ? block.NGramFrequency.Where(x => x.Value >= NGramMinFrequency).ToDictionary(x => x.Key, x => x.Value)
               : block.NGramFrequency;
    }

    protected override Dictionary<string, double> Join(Dictionary<string, double> a, Dictionary<string, double> b)
    {
      var res = new Dictionary<string, double>();
      foreach (var x in a)
        if (b.ContainsKey(x.Key))
          res.Add(x.Key, (x.Value + b[x.Key]) / 2);
        else
          res.Add(x.Key, x.Value);

      foreach (var x in b)
        if (!a.ContainsKey(x.Key))
          res.Add(x.Key, x.Value);

      return res;
    }
  }
}