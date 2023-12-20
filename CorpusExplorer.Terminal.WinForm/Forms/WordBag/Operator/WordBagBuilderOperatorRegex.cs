using System.Text.RegularExpressions;
using CorpusExplorer.Terminal.WinForm.Forms.WordBag.Operator.Abstract;

namespace CorpusExplorer.Terminal.WinForm.Forms.WordBag.Operator
{
  public class WordBagBuilderOperatorRegex : AbstractWordBagBuilderOperator
  {
    private Regex _query;

    public override void Initialize(string query)
      => _query = new Regex(query, RegexOptions.Compiled);

    public override bool IsMatch(string token)
      => _query.IsMatch(token);
  }
}