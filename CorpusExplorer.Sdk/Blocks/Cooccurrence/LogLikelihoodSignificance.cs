using CorpusExplorer.Sdk.Properties;

#region

using System;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Cooccurrence
{
  /// <summary>
  ///   Berechnet LLR
  /// </summary>
  [Serializable]
  public sealed class LogLikelihoodSignificance : ISignificance
  {
    /// <summary>
    ///   The _a
    /// </summary>
    private double _a;

    private double _s;

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
    public double Calculate(double b, double k)
    {
      var aR = _a - k;
      var kR = k;
      var bR = b  - k;
      var nR = _s - bR;

      return 2 * (kR * Math.Log(kR) + bR * Math.Log(bR) + aR * Math.Log(aR) + nR * Math.Log(nR) -
                  (kR + bR) * Math.Log(kR + bR)                                                 -
                  (kR + aR) * Math.Log(kR + aR)                                                 - (aR + nR) * Math.Log(aR + nR) -
                  (bR + nR) * Math.Log(bR + nR)
                + (aR + kR + bR + nR) * Math.Log(aR + kR + bR + nR));
    }

    /// <summary>
    ///   Bezeichnung
    /// </summary>
    /// <value>The label.</value>
    public string Label => Resources.LogLikelihoodTestLLT;

    /// <summary>
    ///   Minimalwert ab dem eine Signifikanz nach diesem Algorithmus vorliegt.
    /// </summary>
    /// <value>The minimum significance.</value>
    public double MinimumSignificance { get; private set; }

    /// <summary>
    ///   Bereitet die Berchnung der Signifikanz vor.
    /// </summary>
    /// <param name="a">Vorkommen des Begriffs</param>
    /// <param name="n">Gesamtzahl der Sätze</param>
    public ISignificance PreCalculationSetup(double a, double n)
    {
      return new LogLikelihoodSignificance
      {
        _a = a,
        _s = n - a
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