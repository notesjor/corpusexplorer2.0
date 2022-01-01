#region

using System;
using CorpusExplorer.Sdk.Blocks.Measure.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Measure
{
  /// <summary>
  ///   The dice coefficient.
  /// </summary>
  [Serializable]
  public sealed class DiceCoefficient : AbstractMeasure
  {
    public override double Calculate(double k, double k0, double ki, double kj, double kij) => 2 * kij / (ki + kj);
  }
}