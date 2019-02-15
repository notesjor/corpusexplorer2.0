using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.Similarity.Abstract;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class
    ClusterMetadataByCooccurrenceBlock : AbstractClusterMetadataBlock<Dictionary<string, Dictionary<string, double>>>
  {
    public double CooccurrenceMinFrequency { get; set; }
    public double CooccurrenceMinSignificance { get; set; }

    protected override Dictionary<string, Dictionary<string, double>> Join(
      Dictionary<string, Dictionary<string, double>> a, Dictionary<string, Dictionary<string, double>> b)
    {
      var res = new Dictionary<string, Dictionary<string, double>>();

      foreach (var x in a)
        if (b.ContainsKey(x.Key))
        {
          res.Add(x.Key, new Dictionary<string, double>());

          foreach (var y in x.Value)
            if (b[x.Key].ContainsKey(y.Key))
              res[x.Key].Add(y.Key, (y.Value + b[x.Key][y.Key]) / 2d);
            else
              res[x.Key].Add(y.Key, y.Value);
        }
        else
        {
          res.Add(x.Key, x.Value);
        }

      foreach (var x in b)
        if (res.ContainsKey(x.Key))
        {
          foreach (var y in x.Value)
            if (!res[x.Key].ContainsKey(y.Key))
              res[x.Key].Add(y.Key, y.Value);
        }
        else
        {
          res.Add(x.Key, x.Value);
        }

      return res;
    }

    protected override double CalculateDistance(
      AbstractDistance similarityIndex, Dictionary<string, Dictionary<string, double>> a,
      Dictionary<string, Dictionary<string, double>> b)
    {
      return similarityIndex.CalculateSimilarity(a, b) / 2d;
    }

    protected override Dictionary<string, Dictionary<string, double>> CalculateValues(Selection selection)
    {
      var block = selection.CreateBlock<CooccurrenceBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.Calculate();

      return ApplyFilter(block).CompleteDictionaryToFullDictionary();
    }

    private Dictionary<string, Dictionary<string, double>> ApplyFilter(CooccurrenceBlock block)
    {
      var res = block.CooccurrenceSignificance;
      if (CooccurrenceMinSignificance > 0)
      {
        var tmp = new Dictionary<string, Dictionary<string, double>>();
        foreach (var x in res)
        foreach (var y in x.Value)
          if (y.Value >= CooccurrenceMinSignificance)
          {
            if (tmp.ContainsKey(x.Key))
              tmp[x.Key].Add(y.Key, y.Value);
            else
              tmp.Add(x.Key, new Dictionary<string, double> {{y.Key, y.Value}});
          }

        res = tmp;
      }

      if (CooccurrenceMinFrequency > 0)
      {
        var tmp = new Dictionary<string, Dictionary<string, double>>();
        foreach (var x in res)
        foreach (var y in x.Value)
          if (block.CooccurrenceFrequency[x.Key][y.Key] >= CooccurrenceMinFrequency)
          {
            if (tmp.ContainsKey(x.Key))
              tmp[x.Key].Add(y.Key, y.Value);
            else
              tmp.Add(x.Key, new Dictionary<string, double> {{y.Key, y.Value}});
          }

        res = tmp;
      }

      return res;
    }
  }
}