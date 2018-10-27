#region

using System;
using CorpusExplorer.Sdk.Blocks.Measure.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Measure
{
  /// <summary>
  ///   The ochiai measure.
  /// </summary>
  [Serializable]
  public sealed class OchiaiMeasure : AbstractMeasure
  {
    public override double Calculate(double k, double k0, double ki, double kj, double kij)
    {
      return kij / Math.Sqrt((kij + ki) * (kij + kj));
    }
  }
}