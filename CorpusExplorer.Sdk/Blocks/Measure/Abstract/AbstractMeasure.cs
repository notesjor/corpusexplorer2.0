using CorpusExplorer.Sdk.Properties;

#region

using System;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Measure.Abstract
{
  /// <summary>
  ///   The abstract measure.
  /// </summary>
  [Serializable]
  public abstract class AbstractMeasure : IMeasure
  {
    /// <summary>
    ///   Berechnet das entsprechende Maß. Siehe [Heyer2012]
    /// </summary>
    /// <param name="k">Gesamtzahl aller Sätze</param>
    /// <param name="k0">Sätze, die weder Ki noch Kj enthalten (Ki = erster Term / Kj = zweiter Term)</param>
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
    public abstract double Calculate(double k, double k0, double ki, double kj, double kij);

    /// <summary>
    ///   Gibt einen <see cref="T:System.String" /> zurück, der das aktuelle <see cref="T:System.Object" /> darstellt.
    /// </summary>
    /// <returns>
    ///   Ein <see cref="T:System.String" />, der das aktuelle <see cref="T:System.Object" /> darstellt.
    /// </returns>
    public override string ToString()
    {
      return GetType().Name.Replace(Resources.Measure, "");
    }

    /// <summary>
    ///   The get p.
    /// </summary>
    /// <param name="ki">
    ///   The ki.
    /// </param>
    /// <param name="kj">
    ///   The kj.
    /// </param>
    /// <param name="kij">
    ///   The kij.
    /// </param>
    /// <returns>
    ///   The <see cref="double" />.
    /// </returns>
    protected double GetP(double k0, double ki, double kj, double kij)
    {
      return k0 + ki + kj + kij;
    }
  }
}