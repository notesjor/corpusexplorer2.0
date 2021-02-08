using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.WordBag.Operator;
using CorpusExplorer.Terminal.WinForm.Forms.WordBag.Operator.Abstract;

namespace CorpusExplorer.Terminal.WinForm.Forms.WordBag
{
  public partial class WordBagBuilder : AbstractDialog
  {
    private Dictionary<string, AbstractWordBagBuilderOperator> _operators;
    private string[] _tokens;

    public WordBagBuilder(IEnumerable<string> tokens)
    {
      InitializeComponent();

      _tokens = tokens.ToArray();
      txt_results.AutoCompleteDataSource = _tokens;

      _operators = new Dictionary<string, AbstractWordBagBuilderOperator>
      {
        {"Startet mit...", new WordBagBuilderOperatorStartsWith()},
        {"Startet mit (case-sensitive)...", new WordBagBuilderOperatorStartsWithCaseSensitive()},
        {"Endet mit...", new WordBagBuilderOperatorEndsWith()},
        {"Endet mit (case-sensitive)...", new WordBagBuilderOperatorEndsWithCaseSensitive()},
        {"Wildcard-Filter [*]", new WordBagBuilderOperatorContains()},
        {"Wildcard-Filter [*] (case-sensitive)", new WordBagBuilderOperatorContainsCaseSensitive()},
        {"Regulärer Ausdruck", new WordBagBuilderOperatorRegex()}
      };

      drop_operator.Items.AddRange(_operators.Keys);
      drop_operator.SelectedIndex = 0;
    }

    private void btn_go_Click(object sender, EventArgs e)
    {
      if (!_operators.ContainsKey(drop_operator.SelectedItem.Text))
        return;
      if (string.IsNullOrWhiteSpace(txt_query.Text))
        return;

      try
      {
        var opr = _operators[drop_operator.SelectedItem.Text];
        opr.Initialize(txt_query.Text);

        txt_results.Text += $"{string.Join(";", _tokens.Where(t => opr.IsMatch(t)))};";
      }
      catch
      {
        // ignore
      }
    }

    public IEnumerable<string> Result => txt_results.Text.Split(';');
  }
}
