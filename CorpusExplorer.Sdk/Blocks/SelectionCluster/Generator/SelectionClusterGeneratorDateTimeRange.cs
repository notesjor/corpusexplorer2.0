#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator
{
  public class SelectionClusterGeneratorDateTimeRange : AbstractSelectionClusterGeneratorRange<DateTime>
  {
    public override DateTime Max { get; set; }
    public override DateTime Min { get; set; }

    protected override AbstractRangeCluster<DateTime> BuildRangeCluster(DateTime start, DateTime end) =>
      new DateTimeRangeCluster(start, end);

    protected override void DetectMinMax(Selection selection)
    {
      var values = new HashSet<DateTime>();
      foreach (var d in selection.DocumentMetadata)
        try
        {
          if (d.Value == null || !d.Value.ContainsKey(MetadataKey))
            continue;

          values.Add(d.Value[MetadataKey].SafeCastDateTime());
        }
        catch
        {
          //ignore
        }

      Min = values.Min();
      Max = values.Max();
    }

    protected override bool OperatorAsmallerB(DateTime a, DateTime b) => a < b;

    protected override DateTime OperatorDivideByRange(DateTime a, int ranges) => new DateTime(a.Ticks / ranges);

    protected override DateTime OperatorMinus(DateTime a, DateTime b) => new DateTime(a.Ticks - b.Ticks);

    protected override DateTime OperatorPlus(DateTime a, DateTime b) => new DateTime(a.Ticks + b.Ticks);
  }
}