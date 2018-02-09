using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator
{
  public class SelectionClusterGeneratorByDoubleRange : AbstractSelectionClusterGeneratorByRange<double>
  {
    protected override AbstractCluster[] AutoGenerate(double min, double max, int ranges)
    {
      if (ranges < 2)
        return new AbstractCluster[] {new DoubleRangeCluster(min, max)};

      var range = max - min;
      var section = range / ranges;

      var res = new List<AbstractCluster>();

      for (var i = min; i < max; i += section)
        res.Add(new DoubleRangeCluster(i, i + section > max ? max : i + section));

      return res.ToArray();
    }

    public override AbstractSelectionClusterGeneratorByRange<double> Configure(int ranges)
    {
      return Configure(ranges, double.MaxValue, double.MinValue);
    }

    protected override bool Max(double value, double currentMax, double limit)
    {
      return value <= limit && value > currentMax;
    }

    protected override bool Min(double value, double currentMin, double limit)
    {
      return value >= limit && value < currentMin;
    }
  }
}