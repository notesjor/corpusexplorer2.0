#region

using System;
using System.Collections.Generic;

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
      var listA = new List<double>();
      var listB = new List<double>();
      var done = new HashSet<string>();

      foreach (var pair in vectorA)
        if (vectorB.ContainsKey(pair.Key))
        {
          listA.Add(pair.Value);
          listB.Add(vectorB[pair.Key]);
          done.Add(pair.Key);
        }
        else
        {
          listA.Add(pair.Value);
          listB.Add(0);
        }

      foreach (var pair in vectorB)
      {
        if (done.Contains(pair.Key))
          continue;

        listA.Add(0);
        listB.Add(pair.Value);
      }

      return CalculateSimilarity(listA.ToArray(), listB.ToArray());
    }
  }
}