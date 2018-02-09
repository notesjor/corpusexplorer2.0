#region

using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.VocabularyComplaxity.CalculationHelper;

#endregion

namespace CorpusExplorer.Sdk.Blocks.VocabularyComplaxity
{
  /// <summary>
  ///   The vocabulary complexity by yule 1938.
  /// </summary>
  [Serializable]
  public class VocabularyComplexityByYule1938 : AbstractVocabularyComplexity
  {
    public override string Displayname => "Yule (1938)";

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
      return VocabularyComplexityViCalculationHelper.GetVi(token, 2) / token.Count;
    }
  }
}