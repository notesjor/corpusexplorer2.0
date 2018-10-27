#region

using System;
using CorpusExplorer.Sdk.Blocks.Measure.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Measure
{
  /// <summary>
  ///   The yule measure.
  /// </summary>
  [Serializable]
  public sealed class YuleMeasure : AbstractMeasure
  {
    public override double Calculate(double k, double k0, double ki, double kj, double kij)
    {
      return (k0 * kij - ki * kj) / (k0 * kij + ki * kj);
    }
  }
}