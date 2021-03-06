namespace CorpusExplorer.Sdk.Blocks.Measure.Abstract
{
  /// <summary>
  ///   The Measure interface.
  /// </summary>
  public interface IMeasure
  {
    /// <summary>
    ///   Berechnet das entsprechende Ma�. Siehe [Heyer2012]
    /// </summary>
    /// <param name="k">Gesamtzahl aller S�tze</param>
    /// <param name="k0"></param>
    /// <param name="ki">
    ///   Anzahl der S�tze die Ki enthalten (Ki = erster Term)
    /// </param>
    /// <param name="kj">
    ///   Anzahl der S�tze die Kj enthalten (Kj = zweiter Term)
    /// </param>
    /// <param name="kij">
    ///   Anzahl der S�tze die sowohl Ki als auch Kj enthalten
    /// </param>
    /// <returns>
    ///   Ma�
    /// </returns>
    double Calculate(double k, double k0, double ki, double kj, double kij);
  }
}