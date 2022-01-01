#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace CorpusExplorer.Sdk.Blocks.VocabularyComplaxity
{
  public class VocabularyComplexityHerdan1960 : AbstractVocabularyComplexity
  {
    public override string Displayname => "Herdans C (1960)";

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
      return Math.Log(token.Count) / Math.Log(token.Sum(x => x.Value));
    }
  }
}