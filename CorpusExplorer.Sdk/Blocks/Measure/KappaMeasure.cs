#region

using System;
using CorpusExplorer.Sdk.Blocks.Measure.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Measure
{
  /// <summary>
  ///   The kappa measure.
  /// </summary>
  [Serializable]
  public sealed class KappaMeasure : AbstractMeasure
  {
    public override double Calculate(double k, double k0, double ki, double kj, double kij) =>
      1.0d / (1.0d + GetP(k0, ki, kj, kij) * (ki + kj) / (2.0d * (k0 * kij - ki * kj)));
  }
}