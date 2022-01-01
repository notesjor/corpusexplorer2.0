#region

using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Model;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract
{
  public abstract class AbstractSelectionClusterGeneratorRange<T> : AbstractSelectionClusterGenerator
  {
    public bool AutoDetectMinMax { get; set; } = true;
    public abstract T Max { get; set; }
    public abstract T Min { get; set; }
    public int Ranges { get; set; } = 10;

    public override AbstractCluster[] AutoGenerate(Selection selection)
    {
      if (AutoDetectMinMax)
        DetectMinMax(selection);

      if (Ranges < 2)
        return new AbstractCluster[] { BuildRangeCluster(Min, Max) };

      var range = OperatorMinus(Max, Min);
      var section = OperatorDivideByRange(range, Ranges);

      var res = new List<AbstractCluster>();

      for (var i = Min; OperatorAsmallerB(i, Max); i = OperatorPlus(i, section))
      {
        var end = OperatorPlus(i, section);
        res.Add(BuildRangeCluster(i, OperatorAsmallerB(Max, end) ? Max : end));
      }

      return res.ToArray();
    }

    protected abstract AbstractRangeCluster<T> BuildRangeCluster(T start, T end);

    protected abstract void DetectMinMax(Selection selection);
    protected abstract bool OperatorAsmallerB(T a, T b);
    protected abstract T OperatorDivideByRange(T a, int ranges);
    protected abstract T OperatorMinus(T a, T b);
    protected abstract T OperatorPlus(T a, T b);
  }
}