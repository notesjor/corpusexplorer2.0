#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace CorpusExplorer.Sdk.Blocks.VocabularyComplaxity
{
  public class VocabularyComplexityGuiraud1954 : AbstractVocabularyComplexity
  {
    public override string Displayname => "Guirauds TTR (1954)";

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
      return token.Count / Math.Sqrt(token.Sum(x => x.Value));
    }
  }
}