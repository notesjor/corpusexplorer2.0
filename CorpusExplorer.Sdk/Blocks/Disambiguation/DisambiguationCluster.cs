using System;
using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Blocks.Disambiguation
{
  public sealed class DisambiguationCluster : IDisambiguationCluster
  {
    public DisambiguationCluster(
      double mainSignificance,
      string word,
      double realationSignificance,
      string cooccurrence,
      double cooccurrenceSignificance)
    {
      ClusterA = new DisambiguationClusterValue(word, mainSignificance);
      ClusterB = new DisambiguationClusterValue(cooccurrence, cooccurrenceSignificance);
      Value = realationSignificance;
    }

    private DisambiguationCluster(IDisambiguationCluster clusterA, IDisambiguationCluster clusterB)
    {
      ClusterA = clusterA;
      ClusterB = clusterB;
      Value = (clusterA.Value + clusterB.Value) / 2.0d;
    }

    public IDisambiguationCluster ClusterA { get; set; }
    public IDisambiguationCluster ClusterB { get; set; }

    public IEnumerable<IDisambiguationCluster> GetClusters() { return new[] {ClusterA, ClusterB}; }

    public string Label => string.Join(", ", LabelItems);

    public IEnumerable<string> LabelItems
    {
      get
      {
        var hashSet = new HashSet<string>();
        foreach (var x in ClusterA.LabelItems)
          hashSet.Add(x);
        foreach (var x in ClusterB.LabelItems)
          hashSet.Add(x);
        return hashSet;
      }
    }

    public double Value { get; }

    public double Distance(DisambiguationCluster otherCluster)
    {
      return Math.Abs(Value - otherCluster.Value) + Math.Abs(ClusterA.Value - otherCluster.ClusterA.Value) +
             Math.Abs(ClusterB.Value - otherCluster.ClusterB.Value);
    }

    public void Join(DisambiguationCluster otherCluster)
    {
      ClusterA = new DisambiguationCluster(ClusterA, ClusterB);
      ClusterB = otherCluster;
    }

    private class DisambiguationClusterValue : IDisambiguationCluster
    {
      public DisambiguationClusterValue(string label, double value)
      {
        Label = label;
        Value = value;
      }

      public IEnumerable<IDisambiguationCluster> GetClusters() { return null; }

      public string Label { get; }

      public IEnumerable<string> LabelItems => new[] {Label};

      public double Value { get; }
    }
  }
}