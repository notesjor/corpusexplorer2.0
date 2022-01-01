#region

#region

using System;
using CorpusExplorer.Sdk.Properties;

#endregion

#endregion

namespace CorpusExplorer.Sdk.Blocks.Cooccurrence
{
  /// <summary>
  ///   Berechnet ChiSquare
  /// </summary>
  [Serializable]
  public sealed class ChiSquaredSignificance : ISignificance
  {
    /// <summary>
    ///   The _a
    /// </summary>
    private double _a;

    /// <summary>
    ///   The _n
    /// </summary>
    private double _n;

    /// <summary>
    ///   The _s
    /// </summary>
    private double _s;

    /// <summary>
    ///   Berechnet Signifikanz.
    /// </summary>
    /// <param name="b">
    ///   Vorkommen des vermeintlichen Kollokators (max. 1 Fund pro Satz)
    /// </param>
    /// <param name="k">
    ///   Anzahl der gemeinsamen Vorkommen von Suchwort und Kollokator (max. 1 Fund pro Satz)
    /// </param>
    /// <returns>
    ///   Signifikanz
    /// </returns>
    /// <exception cref="System.NotImplementedException">
    /// </exception>
    public double Calculate(double b, double k)
    {
      var aR = _a - k;
      var kR = k;
      var bR = b  - k;
      var nR = _s - bR;

      var kE = _a * b        / _n;
      var bE = _s * b        / _n;
      var aE = _a * (_n - b) / _n;
      var nE = _s * (_n - b) / _n;

      return Math.Pow(kR - kE, 2) / kE + Math.Pow(aR - aE, 2) / aE + Math.Pow(bR - bE, 2) / bE
           + Math.Pow(nR - nE, 2) / nE;
    }

    /// <summary>
    ///   Anzeigelabel
    /// </summary>
    /// <value>The label.</value>
    public string Label => Resources.ChiQuadratTestCQT;

    /// <summary>
    ///   Minimalwert ab dem eine Signifikanz nach diesem Algorithmus vorliegt.
    /// </summary>
    /// <value>The minimum significance.</value>
    public double MinimumSignificance => 2.71d;

    /// <summary>
    ///   Bereitet die Berchnung der Signifikanz vor.
    /// </summary>
    /// <param name="a">Vorkommen des Begriffs</param>
    /// <param name="n">Gesamtzahl der Sätze</param>
    public ISignificance PreCalculationSetup(double a, double n) =>
      new ChiSquaredSignificance
      {
        _a = a,
        _n = n,
        _s = n - a
      };

    /// <summary>
    ///   Returns a <see cref="System.String" /> that represents this instance.
    /// </summary>
    /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
    public override string ToString() => Label;
  }
}