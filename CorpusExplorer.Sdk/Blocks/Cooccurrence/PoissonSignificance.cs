using CorpusExplorer.Sdk.Properties;

#region

using System;
using CorpusExplorer.Sdk.Helper;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Cooccurrence
{
  /// <summary>
  ///   Class PoissonSignificance. This class cannot be inherited.
  /// </summary>
  [Serializable]
  public sealed class PoissonSignificance : ISignificance
  {
    /// <summary>
    ///   The _a
    /// </summary>
    private double _a;

    /// <summary>
    ///   The _log
    /// </summary>
    private double _log;

    /// <summary>
    ///   The _n
    /// </summary>
    private double _n;

    /// <summary>
    ///   Berechnet die Signifikanz.
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
      var l = b * _a / _n;
      return (k + 1) / l > 2.5
        ? (k < 10
          ? (l - k * Math.Log(l) + Math.Log(StatisticHelper.Fakultät(k))) / _log
          : k * (Math.Log(k) - Math.Log(l) - 1) / _log)
        : 0;
    }

    /// <summary>
    ///   Anzeigelabel
    /// </summary>
    /// <value>The label.</value>
    public string Label => Resources.PoissonVerteilungPV;

    /// <summary>
    ///   Minimalwert ab dem eine Signifikanz nach diesem Algorithmus vorliegt.
    /// </summary>
    /// <value>The minimum significance.</value>
    public double MinimumSignificance => 0.90d;

    /// <summary>
    ///   Bereitet die Berchnung der Signifikanz vor.
    /// </summary>
    /// <param name="a">Vorkommen des Begriffs</param>
    /// <param name="n">Gesamtzahl der Sätze</param>
    public ISignificance PreCalculationSetup(double a, double n)
    {
      return new PoissonSignificance
      {
        _a = a,
        _n = n,
        _log = Math.Log(n)
      };
    }

    /// <summary>
    ///   Returns a <see cref="System.String" /> that represents this instance.
    /// </summary>
    /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
    public override string ToString()
    {
      return Label;
    }
  }
}