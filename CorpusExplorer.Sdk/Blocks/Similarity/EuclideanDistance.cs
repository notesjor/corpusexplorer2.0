#region

using System;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Similarity.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Similarity
{
  /// <summary>
  ///   The euclidean distance.
  /// </summary>
  [Serializable]
  public class EuclideanDistance : AbstractDistance
  {
    /// <summary>
    ///   The calculate distance.
    /// </summary>
    /// <param name="vectorA">
    ///   The vector a.
    /// </param>
    /// <param name="vectorB">
    ///   The vector b.
    /// </param>
    /// <returns>
    ///   The <see cref="double" />.
    /// </returns>
    protected override double CalculateDistance(double[] vectorA, double[] vectorB)
    {
      return Math.Sqrt(vectorA.Select((t, i) => Math.Pow(t - vectorB[i], 2)).Sum());
    }
  }
}