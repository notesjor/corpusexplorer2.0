using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.PhrasesLaboratory.GrammarRule.Abstract;

namespace CorpusExplorer.Sdk.Blocks.PhrasesLaboratory.GrammarRule
{
  [Serializable]
  public class ExactGrammarRule : AbstractGrammarRule
  {
    private string _body;
    private bool _isRecursiv;
    private string[] _matches;

    public ExactGrammarRule(string label, string body)
    {
      Label = label;
      Body = body;
    }

    private ExactGrammarRule()
    {
    }

    public string Body
    {
      get => _body;
      set
      {
        _body = value;
        _matches = _body.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
        _isRecursiv = _matches.Any(match => match == Label);
      }
    }

    public override bool IsRecursive => _isRecursiv;

    public override IEnumerable<Constituent> Match(ref List<Constituent> constituents, int index)
    {
      if (constituents[index].Label != _matches[0])
        return null;

      var match = true;
      var items = new List<Constituent> {constituents[index]};

      for (var i = 1; i < _matches.Length; i++)
      {
        if (index + i                     >= constituents.Count ||
            constituents[index + i].Label != _matches[i])
        {
          match = false;
          break;
        }

        items.Add(constituents[index + i]);
      }

      return match ? items : null;
    }
  }
}