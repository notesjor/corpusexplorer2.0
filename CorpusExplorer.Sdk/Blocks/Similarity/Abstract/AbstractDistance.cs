#region

using System;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Similarity.Abstract
{
  /// <summary>
  ///   Class AbstractDistance.
  /// </summary>
  [Serializable]
  public abstract class AbstractDistance : AbstractSimilarity
  {
    /// <summary>
    ///   Calculates the distance.
    /// </summary>
    /// <param name="vectorA">
    ///   The vector a.
    /// </param>
    /// <param name="vectorB">
    ///   The vector b.
    /// </param>
    /// <returns>
    ///   System.Double.
    /// </returns>
    protected abstract double CalculateDistance(double[] vectorA, double[] vectorB);

    /// <summary>
    ///   Calculates the similarity.
    /// </summary>
    /// <param name="vectorA">
    ///   The vector a.
    /// </param>
    /// <param name="vectorB">
    ///   The vector b.
    /// </param>
    /// <returns>
    ///   System.Double.
    /// </returns>
    public override double CalculateSimilarity(double[] vectorA, double[] vectorB)
    {
      return 1.0d / (CalculateDistance(vectorA, vectorB) + 1.0d);
    }

    // ReSharper disable MemberCanBeProtected.Global

    // ReSharper restore MemberCanBeProtected.Global
  }
}