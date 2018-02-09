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
    /// <summary>
    ///   Berechnet das entsprechende Maﬂ. Siehe [Heyer2012]
    /// </summary>
    /// <param name="ki">
    ///   Anzahl der S‰tze die Ki enthalten (Ki = erster Term)
    /// </param>
    /// <param name="kj">
    ///   Anzahl der S‰tze die Kj enthalten (Kj = zweiter Term)
    /// </param>
    /// <param name="kij">
    ///   Anzahl der S‰tze die sowohl Ki als auch Kj enthalten
    /// </param>
    /// <returns>
    ///   Maﬂ
    /// </returns>
    public override double Calculate(double ki, double kj, double kij)
    {
      return 2 * kij / (ki + kj);
    }
  }
}