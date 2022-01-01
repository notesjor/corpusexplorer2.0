#region

using System;
using CorpusExplorer.Sdk.Blocks.Measure.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Measure
{
  /// <summary>
  ///   The phi measure.
  /// </summary>
  [Serializable]
  public sealed class PhiMeasure : AbstractMeasure
  {
    public override double Calculate(double k, double k0, double ki, double kj, double kij) =>
      (kij * k0 - ki * kj) / Math.Sqrt((kij + ki) * (kij + kj) * (k0 + ki) * (k0 + kj));
  }
}