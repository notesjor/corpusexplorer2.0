#region

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
  public class SelectionClusterGeneratorIntegerRange : AbstractSelectionClusterGeneratorRange<int>
  {
    public override int Max { get; set; } = int.MaxValue;
    public override int Min { get; set; } = int.MinValue;

    protected override AbstractRangeCluster<int> BuildRangeCluster(int start, int end) =>
      new IntegerRangeCluster(start, end);

    protected override void DetectMinMax(Selection selection)
    {
      var values = new HashSet<int>();
      foreach (var d in selection.DocumentMetadata)
        try
        {
          if (d.Value == null || !d.Value.ContainsKey(MetadataKey))
            continue;

          values.Add(d.Value[MetadataKey].SafeCastInt());
        }
        catch
        {
          //ignore
        }

      Min = values.Min();
      Max = values.Max();
    }

    protected override bool OperatorAsmallerB(int a, int b) => a < b;

    protected override int OperatorDivideByRange(int a, int ranges) => a / ranges;

    protected override int OperatorMinus(int a, int b) => a - b;

    protected override int OperatorPlus(int a, int b) => a + b;
  }
}