#region

using System;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Similarity
{
  /// <summary>
  ///   The convert distance to similarity.
  /// </summary>
  [Serializable]
  public static class ConvertDistanceToSimilarity
  {
    /// <summary>
    ///   The convert.
    /// </summary>
    /// <param name="dist">
    ///   The dist.
    /// </param>
    /// <returns>
    ///   The <see cref="double" />.
    /// </returns>
    public static double Convert(double dist) => 1.0d / (dist + 1.0d);
  }
}