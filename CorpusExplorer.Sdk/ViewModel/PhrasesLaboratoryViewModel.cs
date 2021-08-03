using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.PhrasesLaboratory;
using CorpusExplorer.Sdk.Blocks.PhrasesLaboratory.GrammarRule;
using CorpusExplorer.Sdk.Blocks.PhrasesLaboratory.GrammarRule.Abstract;
using CorpusExplorer.Sdk.ViewModel.Abstract;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class PhrasesLaboratoryViewModel : AbstractViewModel
  {
    private PhrasesLaboratoryBlock _block;

    public IEnumerable<KeyValuePair<Guid, string>> Documents => Selection.DocumentGuidsAndDisplaynames;

    public PhraseGrammar Grammar
    {
      get => _block.Grammar;
      set => _block.Grammar = value;
    }

    public DataTable GetPhrasesFrequencyTable()
    {
      var data = _block.GetParsedConstituentFrequency();

      var res = new DataTable();
      res.Columns.Add("T", typeof(string));
      res.Columns.Add("Inhalt", typeof(string));
      res.Columns.Add("Frequenz", typeof(double));

      res.BeginLoadData();

      foreach (var x in data)
      foreach (var y in x.Value)
        res.Rows.Add(x.Key, y.Key, y.Value);

      res.EndLoadData();

      return res;
    }

    public List<string> GetPossiblesTermianls(PhraseGrammar grammar)
    {
      var res = new HashSet<string> {"ROOT"};

      var layers = Selection.GetLayers("POS");
      foreach (var value in layers.Where(layer => layer != null).SelectMany(layer => layer.Values))
        res.Add(value);

      foreach (var rule in grammar.Rules.SelectMany(levels => levels.Value))
        res.Add(rule.Label);

      return res.ToList();
    }

    public long GetSentenceMax(Guid documentGuid)
    {
      return Selection.GetDocumentLengthInSentences(documentGuid);
    }

    public IEnumerable<Constituent> GetSpecificSentence(Guid documentGuid, int sentenceIndex)
    {
      if (sentenceIndex < 0 ||
          !Selection.ContainsDocument(documentGuid))
        return null;

      return _block.GetParsedConstituent(documentGuid, sentenceIndex);
    }

    protected override void ExecuteAnalyse()
    {
      _block = Selection.CreateBlock<PhrasesLaboratoryBlock>();
      _block.Grammar = new PhraseGrammar();
      _block.Grammar.Rules.Add(int.MaxValue, new List<AbstractGrammarRule> {new JoinAllGrammarRule("ROOT")});
      _block.Calculate();
    }

    protected override bool Validate()
    {
      return true;
    }
  }
}