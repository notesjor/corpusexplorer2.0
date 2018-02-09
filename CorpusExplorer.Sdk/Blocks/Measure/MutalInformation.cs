#region

using System;
using CorpusExplorer.Sdk.Blocks.Measure.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Measure
{
  /// <summary>
  ///   The mutal information.
  /// </summary>
  [Serializable]
  public sealed class MutalInformation : AbstractMeasure
  {
    /// <summary>
    ///   The _k.
    /// </summary>
    private readonly double _k;

    /// <summary>
    ///   Initializes a new instance of the <see cref="MutalInformation" /> class.
    ///   Erzeugt eine neu Instanz
    /// </summary>
    /// <param name="k">
    ///   Gesamtzahl aller S‰tze
    /// </param>
    public MutalInformation(double k)
    {
      _k = k;
    }

    /// <summary>
    ///   Berechnet das entsprechende Maﬂ. Siehe [Heyer2012]
    /// </summary>
    /// <param name="ki">
    ///   Anzahl der S‰tze die Ki enthalten (Ki = erster Term)
    /// </param>
    /// <param name="kj">
    ///   Anzahl der S‰tze die Kj enthalten (Kj = zweiter Term)
    /// </param>
    /// <param name="kij">
    ///   Anzahl der S‰tze die sowohl Ki als auch Kj enthalten
    /// </param>
    /// <returns>
    ///   Maﬂ
    /// </returns>
    public override double Calculate(double ki, double kj, double kij)
    {
      return Math.Log(_k * kij / (ki * kj));
    }
  }
}