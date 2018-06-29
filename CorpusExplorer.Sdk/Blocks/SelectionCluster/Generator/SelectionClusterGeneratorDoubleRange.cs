using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator
{
  public class SelectionClusterGeneratorDoubleRange : AbstractSelectionClusterGeneratorRange<double>
  {
    public override double Max { get; set; }
    public override double Min { get; set; }

    protected override AbstractRangeCluster<double> BuildRangeCluster(double start, double end)
    {
      return new DoubleRangeCluster(start, end);
    }

    protected override void DetectMinMax(Selection selection)
    {
      var values = new HashSet<double>();
      foreach (var d in selection.DocumentMetadata)
        try
        {
          if (d.Value == null || !d.Value.ContainsKey(MetadataKey))
            continue;

          values.Add(d.Value[MetadataKey].SafeCastDouble());
        }
        catch
        {
          //ignore
        }

      Min = values.Min();
      Max = values.Max();
    }

    protected override bool OperatorAsmallerB(double a, double b)
    {
      return a < b;
    }

    protected override double OperatorDivideByRange(double a, int ranges)
    {
      return a / ranges;
    }

    protected override double OperatorMinus(double a, double b)
    {
      return a - b;
    }

    protected override double OperatorPlus(double a, double b)
    {
      return a + b;
    }
  }
}