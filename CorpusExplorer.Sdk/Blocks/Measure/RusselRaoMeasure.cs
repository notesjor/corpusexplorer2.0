#region

using System;
using CorpusExplorer.Sdk.Blocks.Measure.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Measure
{
  /// <summary>
  ///   The russel rao measure.
  /// </summary>
  [Serializable]
  public sealed class RusselRaoMeasure : AbstractMeasure
  {
    public override double Calculate(double k, double k0, double ki, double kj, double kij) =>
      kij / GetP(k0, ki, kj, kij);
  }
}