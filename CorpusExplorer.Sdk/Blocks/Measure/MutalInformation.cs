#region

using System;
using CorpusExplorer.Sdk.Blocks.Measure.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Measure
{
  /// <summary>
  ///   The mutal information.
  /// </summary>
  [Serializable]
  public sealed class MutalInformation : AbstractMeasure
  {
    public override double Calculate(double k, double k0, double ki, double kj, double kij) =>
      Math.Log(k * kij / (ki * kj));
  }
}