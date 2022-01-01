#region

using System;
using CorpusExplorer.Sdk.Blocks.Measure.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Measure
{
  /// <summary>
  ///   The simpson measure.
  /// </summary>
  [Serializable]
  public sealed class SimpsonMeasure : AbstractMeasure
  {
    public override double Calculate(double k, double k0, double ki, double kj, double kij) =>
      kij / (kij + Math.Min(ki, kj));
  }
}