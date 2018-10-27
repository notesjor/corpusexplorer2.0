#region

using System;
using CorpusExplorer.Sdk.Blocks.Measure.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Measure
{
  /// <summary>
  ///   The tanimoto measure.
  /// </summary>
  [Serializable]
  public sealed class TanimotoMeasure : AbstractMeasure
  {
    public override double Calculate(double k, double k0, double ki, double kj, double kij)
    {
      return kij / (ki + kj - kij);
    }
  }
}