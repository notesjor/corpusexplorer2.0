using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.PhrasesLaboratory.GrammarRule.Abstract;

namespace CorpusExplorer.Sdk.Blocks.PhrasesLaboratory.GrammarRule
{
  [Serializable]
  public class JoinAllGrammarRule : AbstractGrammarRule
  {
    private JoinAllGrammarRule() { }

    public JoinAllGrammarRule(string label) { Label = label; }

    public override bool IsRecursive => false;

    public override IEnumerable<Constituent> Match(ref List<Constituent> constituents, int index)
    {
      var res = new Constituent(Label, true);
      foreach (var constituent in constituents)
        res.Add(constituent);
      return new[] {res};
    }
  }
}