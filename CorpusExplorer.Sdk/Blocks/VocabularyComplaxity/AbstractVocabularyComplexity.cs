#region

using System;
using System.Collections.Generic;

#endregion

namespace CorpusExplorer.Sdk.Blocks.VocabularyComplaxity
{
  /// <summary>
  ///   The abstract vocabulary complexity.
  /// </summary>
  [Serializable]
  public abstract class AbstractVocabularyComplexity
  {
    public abstract string Displayname { get; }

    /// <summary>
    ///   The calculate value.
    /// </summary>
    /// <param name="token">
    ///   Dictionary Token und ihre Frequenz
    /// </param>
    /// <returns>
    ///   The <see cref="double" />.
    /// </returns>
    public abstract double CalculateValue(Dictionary<string, double> token);
  }
}