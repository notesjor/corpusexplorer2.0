#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace CorpusExplorer.Sdk.Blocks.Similarity.Abstract
{
  /// <summary>
  ///   The abstract similarity.
  /// </summary>
  [Serializable]
  public abstract class AbstractSimilarity
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
    public abstract double CalculateSimilarity(double[] vectorA, double[] vectorB);

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
    public double CalculateSimilarity(Dictionary<string, double> vectorA, Dictionary<string, double> vectorB)
    {
      var tmp = new HashSet<string>();
      foreach (var x in vectorA)
        tmp.Add(x.Key);
      foreach (var x in vectorB)
        tmp.Add(x.Key);
      var keys = tmp.ToArray();
      tmp.Clear();

      return CalculateSimilarity(
        keys.Select(x => vectorA.ContainsKey(x) ? vectorA[x] : 0).ToArray(),
        keys.Select(x => vectorB.ContainsKey(x) ? vectorB[x] : 0).ToArray());
    }

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
    public double CalculateSimilarity(Dictionary<string, Dictionary<string, double>> vectorA, Dictionary<string, Dictionary<string, double>> vectorB)
    {
      var a = new Dictionary<string, double>();
      foreach (var x in vectorA)
        foreach (var y in x.Value)
          a.Add($"{x.Key}>->{y.Value}", y.Value);

      var b = new Dictionary<string, double>();
      foreach (var x in vectorB)
        foreach (var y in x.Value)
          b.Add($"{x.Key}>->{y.Value}", y.Value);

      return CalculateSimilarity(a, b);
    }
  }
}