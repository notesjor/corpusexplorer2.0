using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator
{
  public class SelectionClusterGeneratorByDateTimeRange :
    AbstractSelectionClusterGeneratorByRange<DateTime>
  {
    protected override AbstractCluster[] AutoGenerate(DateTime min, DateTime max, int ranges)
    {
      if (ranges < 2)
        return new AbstractCluster[] {new DateTimeRangeCluster(min, max)};

      var range = max.Ticks - min.Ticks;
      var section = range / ranges;

      var res = new List<AbstractCluster>();

      for (var i = min; i < max; i = i.AddTicks(section))
        res.Add(new DateTimeRangeCluster(i, i.AddTicks(section) > max ? max : i.AddTicks(section)));

      return res.ToArray();
    }

    public override AbstractSelectionClusterGeneratorByRange<DateTime> Configure(int ranges)
    {
      return Configure(ranges, DateTime.MaxValue, DateTime.MinValue);
    }

    protected override bool Max(DateTime value, DateTime currentMax, DateTime limit)
    {
      return value <= limit && value > currentMax;
    }

    protected override bool Min(DateTime value, DateTime currentMin, DateTime limit)
    {
      return value >= limit && value < currentMin;
    }
  }
}