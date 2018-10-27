#region

using System;
using CorpusExplorer.Sdk.Blocks.Measure.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Measure
{
  /// <summary>
  ///   The sneath measure.
  /// </summary>
  [Serializable]
  public sealed class SneathMeasure : AbstractMeasure
  {
    public override double Calculate(double k, double k0, double ki, double kj, double kij)
    {
      return kij / (kij + 2.0d * ki + 2.0d * kj);
    }
  }
}