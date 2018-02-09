#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace CorpusExplorer.Sdk.Blocks.VocabularyComplaxity
{
  /// <summary>
  ///   The vocabulary complexity by brunet 1978.
  /// </summary>
  [Serializable]
  public class VocabularyComplexityByBrunet1978 : AbstractVocabularyComplexity
  {
    public override string Displayname => "Brunet (1978)";

    /// <summary>
    ///   The calculate value.
    /// </summary>
    /// <param name="token">
    ///   List of Tokens
    /// </param>
    /// <returns>
    ///   The <see cref="double" />.
    /// </returns>
    public override double CalculateValue(Dictionary<string, double> token)
    {
      return Math.Pow(token.Sum(x => x.Value), Math.Pow(token.Count, -0.172d));
    }
  }
}