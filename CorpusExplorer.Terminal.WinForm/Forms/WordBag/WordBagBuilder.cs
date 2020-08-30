using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;

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

    #region Operators

    private abstract class AbstractWordBagBuilderOperator
    {
      public abstract void Initialize(string query);
      public abstract bool IsMatch(string token);
    }

    private class WordBagBuilderOperatorStartsWith : AbstractWordBagBuilderOperator
    {
      private string _query;

      public override void Initialize(string query) 
        => _query = query.ToLower();

      public override bool IsMatch(string token) 
        => token.ToLower().StartsWith(_query);
    }

    private class WordBagBuilderOperatorStartsWithCaseSensitive : AbstractWordBagBuilderOperator
    {
      private string _query;

      public override void Initialize(string query) 
        => _query = query;

      public override bool IsMatch(string token) 
        => token.StartsWith(_query);
    }

    private class WordBagBuilderOperatorEndsWith : AbstractWordBagBuilderOperator
    {
      private string _query;

      public override void Initialize(string query) 
        => _query = query.ToLower();

      public override bool IsMatch(string token) 
        => token.ToLower().EndsWith(_query);
    }

    private class WordBagBuilderOperatorEndsWithCaseSensitive : AbstractWordBagBuilderOperator
    {
      private string _query;

      public override void Initialize(string query) => _query = query;

      public override bool IsMatch(string token) 
        => token.EndsWith(_query);
    }

    private class WordBagBuilderOperatorContains : AbstractWordBagBuilderOperator
    {
      private string _queryS;
      private string _queryE;

      public override void Initialize(string query)
      {
        query = query.ToLower();
        var split = query.Split('*');
        _queryS = split.First();
        _queryE = split.Last();
      }

      public override bool IsMatch(string token)
      {
        token = token.ToLower();
        return token.StartsWith(_queryS) && token.EndsWith(_queryE);
      }
    }

    private class WordBagBuilderOperatorContainsCaseSensitive : AbstractWordBagBuilderOperator
    {
      private string _queryS;
      private string _queryE;

      public override void Initialize(string query)
      {
        var split = query.Split('*');
        _queryS = split.First();
        _queryE = split.Last();
      }

      public override bool IsMatch(string token) 
        => token.StartsWith(_queryS) && token.EndsWith(_queryE);
    }

    private class WordBagBuilderOperatorRegex : AbstractWordBagBuilderOperator
    {
      private Regex _query;

      public override void Initialize(string query)
        => _query = new Regex(query);

      public override bool IsMatch(string token)
        => _query.IsMatch(token);
    }

    #endregion
  }
}
