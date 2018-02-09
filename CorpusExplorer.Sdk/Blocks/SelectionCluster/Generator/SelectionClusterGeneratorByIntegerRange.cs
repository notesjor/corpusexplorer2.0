using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator
{
  public class SelectionClusterGeneratorByIntegerRange : AbstractSelectionClusterGeneratorByRange<int>
  {
    protected override AbstractCluster[] AutoGenerate(int min, int max, int ranges)
    {
      if (ranges < 2)
        return new AbstractCluster[] {new IntegerRangeCluster(min, max)};

      var range = max - min;
      var section = range / ranges;

      var res = new List<AbstractCluster>();

      for (var i = min; i < max; i += section)
        res.Add(new IntegerRangeCluster(i, i + section > max ? max : i + section));

      return res.ToArray();
    }

    public override AbstractSelectionClusterGeneratorByRange<int> Configure(int ranges)
    {
      return Configure(ranges, int.MaxValue, int.MinValue);
    }

    protected override bool Max(int value, int currentMax, int limit) { return value <= limit && value > currentMax; }

    protected override bool Min(int value, int currentMin, int limit) { return value >= limit && value < currentMin; }
  }
}