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
  public sealed class MCoefficientMeasure : AbstractExtendedMeasure
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="MCoefficientMeasure" /> class.
    /// </summary>
    /// <param name="k0">
    ///   The k 0.
    /// </param>
    public MCoefficientMeasure(double k0)
      : base(k0) { }

    /// <summary>
    ///   Berechnet das entsprechende Maß. Siehe [Heyer2012]
    /// </summary>
    /// <param name="ki">
    ///   Anzahl der Sätze die Ki enthalten (Ki = erster Term)
    /// </param>
    /// <param name="kj">
    ///   Anzahl der Sätze die Kj enthalten (Kj = zweiter Term)
    /// </param>
    /// <param name="kij">
    ///   Anzahl der Sätze die sowohl Ki als auch Kj enthalten
    /// </param>
    /// <returns>
    ///   Maß
    /// </returns>
    public override double Calculate(double ki, double kj, double kij)
    {
      return (K0 + kij) / GetP(ki, kj, kij);
    }
  }
}