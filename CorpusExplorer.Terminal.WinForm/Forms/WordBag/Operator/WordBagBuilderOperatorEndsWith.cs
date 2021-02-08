using CorpusExplorer.Terminal.WinForm.Forms.WordBag.Operator.Abstract;

namespace CorpusExplorer.Terminal.WinForm.Forms.WordBag.Operator
{
  public class WordBagBuilderOperatorEndsWith : AbstractWordBagBuilderOperator
  {
    private string _query;

    public override void Initialize(string query)
      => _query = query.ToLower();

    public override bool IsMatch(string token)
      => token.ToLower().EndsWith(_query);
  }
}