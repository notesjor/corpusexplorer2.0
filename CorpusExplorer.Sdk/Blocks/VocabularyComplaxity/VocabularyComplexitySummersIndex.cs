#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace CorpusExplorer.Sdk.Blocks.VocabularyComplaxity
{
  public class VocabularyComplexitySummersIndex : AbstractVocabularyComplexity
  {
    public override string Displayname => "Summers Index";

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
      return Math.Log(Math.Log(token.Count)) / Math.Log(Math.Log(token.Sum(x => x.Value)));
    }
  }
}