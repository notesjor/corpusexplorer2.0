#region

using System;
using CorpusExplorer.Sdk.Blocks.Similarity.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Similarity
{
  /// <summary>
  ///   The cosine mesure.
  /// </summary>
  [Serializable]
  public class CosineMesure : AbstractSimilarity
  {
    /// <summary>
    ///   The calculate similarity.
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
    public override double CalculateSimilarity(double[] vectorA, double[] vectorB)
    {
      var ab = 0.0d;
      var a2 = 0.0d;
      var b2 = 0.0d;

      for (var i = 0; i < vectorA.Length; i++)
      {
        ab += vectorA[i] * vectorB[i];
        a2 += vectorA[i] * vectorA[i];
        b2 += vectorB[i] * vectorB[i];
      }

      return ab / (Math.Sqrt(a2) * Math.Sqrt(b2));
    }
  }
}