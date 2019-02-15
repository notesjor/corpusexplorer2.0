#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.VocabularyComplaxity.CalculationHelper;

#endregion

namespace CorpusExplorer.Sdk.Blocks.VocabularyComplaxity
{
  /// <summary>
  ///   The vocabulary complexity by honore 1979.
  /// </summary>
  [Serializable]
  public class VocabularyComplexityByHonore1979 : AbstractVocabularyComplexity
  {
    public override string Displayname => "Honore (1979)";

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
      return 100.0d * Math.Log(token.Sum(x => x.Value))
           / (1 - (VocabularyComplexityViCalculationHelper.GetVi(token, 1) - token.Count));
    }
  }
}