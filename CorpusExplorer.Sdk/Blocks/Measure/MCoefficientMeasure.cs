#region

using System;
using CorpusExplorer.Sdk.Blocks.Measure.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Measure
{
  /// <summary>
  ///   The m coefficient measure.
  /// </summary>
  [Serializable]
  public sealed class MCoefficientMeasure : AbstractMeasure
  {
    public override double Calculate(double k, double k0, double ki, double kj, double kij) =>
      (k0 + kij) / GetP(k0, ki, kj, kij);
  }
}