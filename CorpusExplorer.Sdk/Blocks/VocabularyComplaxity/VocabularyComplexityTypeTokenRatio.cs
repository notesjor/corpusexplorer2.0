using System.Collections.Generic;
using System.Linq;

namespace CorpusExplorer.Sdk.Blocks.VocabularyComplaxity
{
  public class VocabularyComplexityTypeTokenRatio : AbstractVocabularyComplexity
  {
    public override string Displayname => "Type-Token Ratio";

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
      return token.Count / token.Sum(x => x.Value);
    }
  }
}