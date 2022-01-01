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
  public class ClusterMetadataByCooccurrenceSelectiveBlock : AbstractClusterMetadataBlock<Dictionary<string, double>>
  {
    public double CooccurrenceMinFrequency { get; set; }
    public double CooccurrenceMinSignificance { get; set; }
    public string[] LayerQueries { get; set; }

    private Dictionary<string, double> ApplyFilter(CooccurrenceSelectiveBlock block)
    {
      if (CooccurrenceMinFrequency <= 0 && CooccurrenceMinSignificance <= 0)
        return block.CooccurrenceSignificance;

      var res = new Dictionary<string, double>();
      foreach (var x in block.CooccurrenceSignificance)
      {
        if (CooccurrenceMinSignificance >= 0 && x.Value < CooccurrenceMinSignificance)
          continue;

        if (CooccurrenceMinFrequency >= 0 && (!block.CooccurrenceFrequency.ContainsKey(x.Key) ||
                                              block.CooccurrenceFrequency[x.Key] < CooccurrenceMinFrequency))
          continue;

        res.Add(x.Key, x.Value);
      }

      return res;
    }

    protected override double CalculateDistance(
      AbstractDistance similarityIndex, Dictionary<string, double> a, Dictionary<string, double> b)
    {
      return similarityIndex.CalculateSimilarity(
                                                 a.ToDictionary(x => x.Key, x => x.Value),
                                                 b.ToDictionary(x => x.Key, x => x.Value));
    }

    protected override Dictionary<string, double> CalculateValues(Selection selection)
    {
      var block = selection.CreateBlock<CooccurrenceSelectiveBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.LayerQueries = LayerQueries;
      block.Calculate();

      return ApplyFilter(block);
    }

    protected override Dictionary<string, double> Join(Dictionary<string, double> a, Dictionary<string, double> b)
    {
      var res = new Dictionary<string, double>();
      foreach (var x in a)
        if (b.ContainsKey(x.Key))
          res.Add(x.Key, (x.Value + b[x.Key]) / 2d);
        else
          res.Add(x.Key, x.Value);

      foreach (var x in b)
        if (!a.ContainsKey(x.Key))
          res.Add(x.Key, x.Value);

      return res;
    }
  }
}