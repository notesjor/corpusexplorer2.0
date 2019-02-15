#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.VocabularyComplaxity.CalculationHelper;

#endregion

namespace CorpusExplorer.Sdk.Blocks.VocabularyComplaxity
{
  /// <summary>
  ///   The vocabulary complexity by sichel 1975.
  /// </summary>
  [Serializable]
  public class VocabularyComplexityBySichel1975 : AbstractVocabularyComplexity
  {
    public override string Displayname => "Sichel (1975)";

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
      return 10000.0d
           * (VocabularyComplexityMCalculationHelper.GetM(token)
            / VocabularyComplexityViCalculationHelper.GetVi(token, 2) - 1.0d / token.Sum(x => x.Value));
    }
  }
}