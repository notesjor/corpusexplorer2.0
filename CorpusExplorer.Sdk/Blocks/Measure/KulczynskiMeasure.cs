#region

using System;
using CorpusExplorer.Sdk.Blocks.Measure.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Measure
{
  /// <summary>
  ///   The kulczynski measure.
  /// </summary>
  [Serializable]
  public sealed class KulczynskiMeasure : AbstractMeasure
  {
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
      return kij / (ki + kj);
    }
  }
}