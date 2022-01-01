#region

using System;
using System.Collections.Generic;

#endregion

namespace CorpusExplorer.Sdk.Blocks.PhrasesLaboratory.GrammarRule.Abstract
{
  [Serializable]
  public abstract class AbstractGrammarRule
  {
    protected AbstractGrammarRule() => Childs = new List<AbstractGrammarRule>();

    public List<AbstractGrammarRule> Childs { get; set; }
    public abstract bool IsRecursive { get; }
    public string Label { get; set; }
    public abstract IEnumerable<Constituent> Match(ref List<Constituent> constituents, int index);
  }
}