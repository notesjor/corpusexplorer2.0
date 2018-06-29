#region

using System;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Measure.Abstract
{
  /// <summary>
  ///   The abstract extended measure.
  /// </summary>
  [Serializable]
  public abstract class AbstractExtendedMeasure : AbstractMeasure
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractExtendedMeasure" /> class.
    /// </summary>
    /// <param name="k0">
    ///   The k 0.
    /// </param>
    protected AbstractExtendedMeasure(double k0)
    {
      K0 = k0;
    }

    /// <summary>
    ///   Prevents a default instance of the <see cref="AbstractExtendedMeasure" /> class from being created.
    /// </summary>
    private AbstractExtendedMeasure()
    {
    }

    /// <summary>
    ///   The _k 0.
    /// </summary>
    protected double K0 { get; }

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
    protected double GetP(double ki, double kj, double kij)
    {
      return K0 + ki + kj + kij;
    }
  }
}