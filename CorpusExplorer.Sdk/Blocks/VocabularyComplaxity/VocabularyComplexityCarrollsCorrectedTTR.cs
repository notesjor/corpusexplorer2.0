using System;
using System.Collections.Generic;
using System.Linq;

namespace CorpusExplorer.Sdk.Blocks.VocabularyComplaxity
{
  public class VocabularyComplexityCarrollsCorrectedTTR : AbstractVocabularyComplexity
  {
    public override string Displayname => "Carrolls Corrected TTR";

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
      return token.Count / Math.Sqrt(2d * token.Sum(x => x.Value));
    }
  }
}