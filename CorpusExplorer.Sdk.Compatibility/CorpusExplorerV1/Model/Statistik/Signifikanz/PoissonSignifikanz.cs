using System;
using CorpusExplorer.Sdk.Data.Helper;

namespace CorpusExplorer.Sdk.Data.Model.Statistik.Signifikanz
{
  public class PoissonSignifikanz : ISignifikanz
  {
    private double _a;
    private double _log;
    private double _n;

    /// <summary>
    ///   Berechnet die Signifikanz.
    /// </summary>
    /// <param name="k">Vorkommen des Suchworts (max. 1 Fund pro Satz)</param>
    /// <param name="b">Anzahl der gemeinsamen Vorkommen von Suchwort und Kollokator</param>
    /// <returns>Signifikanz</returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public double Calculate(double k, double b)
    {
      var l = (k*_a)/_n;
      return ((b + 1)/l) > 2.5
        ? (b < 10
          ? (l - b*Math.Log(l) + Math.Log(HelperStatistik.Fakultät(b)))/_log
          : (b*(Math.Log(b) - Math.Log(l) - 1))/_log)
        : 0;
    }

    /// <summary>
    ///   Vorkommen des Kollokators zum Suchwort (max. 1 Fund pro Satz)
    /// </summary>
    /// <value>The aggregate.</value>
    public double A
    {
      set { _a = value; }
    }

    /// <summary>
    ///   Gesamtzahl der Sätze
    /// </summary>
    /// <value>The asynchronous.</value>
    public double N
    {
      set
      {
        _n = value;
        _log = Math.Log(value);
      }
    }

    public string Label
    {
      get { return "Poisson-Verteilung (PV)"; }
    }

    public override string ToString()
    {
      return Label;
    }
  }
}