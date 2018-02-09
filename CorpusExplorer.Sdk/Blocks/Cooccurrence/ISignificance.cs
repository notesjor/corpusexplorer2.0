#region



#endregion

namespace CorpusExplorer.Sdk.Blocks.Cooccurrence
{
  /// <summary>
  ///   Interface für Kollokationsberechnung
  /// </summary>
  public interface ISignificance
  {
    /// <summary>
    ///   Anzeigelabel
    /// </summary>
    string Label { get; }

    /// <summary>
    ///   Minimalwert ab dem eine Signifikanz nach diesem Algorithmus vorliegt.
    /// </summary>
    double MinimumSignificance { get; }

    /// <summary>
    ///   Berechnet die Signifikanz. WICHTIG: Zuvor muss PreCalculationSetup(a, n) aufgerufen werden.
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
    double Calculate(double b, double k);

    /// <summary>
    ///   Bereitet die Berchnung der Signifikanz vor.
    /// </summary>
    /// <param name="a">Vorkommen des Begriffs</param>
    /// <param name="n">Gesamtzahl der Sätze</param>
    ISignificance PreCalculationSetup(double a, double n);
  }
}