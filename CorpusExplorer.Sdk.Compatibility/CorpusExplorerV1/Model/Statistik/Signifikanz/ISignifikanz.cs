namespace CorpusExplorer.Sdk.Data.Model.Statistik.Signifikanz
{
  public interface ISignifikanz
  {
    /// <summary>
    ///   Vorkommen des Kollokators zum Suchwort (max. 1 Fund pro Satz)
    /// </summary>
    double A { set; }

    /// <summary>
    ///   Gesamtzahl der Sätze
    /// </summary>
    double N { set; }

    /// <summary>
    ///   Anzeigelabel
    /// </summary>
    string Label { get; }

    /// <summary>
    ///   Berechnet die Signifikanz.
    /// </summary>
    /// <param name="b">
    ///   Vorkommen des Kollokators zum Suchwort (max. 1 Fund pro Satz)
    /// </param>
    /// <param name="k">
    ///   Anzahl der gemeinsamen Vorkommen von Suchwort und Kollokator
    /// </param>
    /// <returns>
    ///   Signifikanz
    /// </returns>
    double Calculate(double k, double b);
  }
}