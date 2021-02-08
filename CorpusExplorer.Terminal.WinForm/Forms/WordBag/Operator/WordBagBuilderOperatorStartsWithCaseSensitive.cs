using CorpusExplorer.Terminal.WinForm.Forms.WordBag.Operator.Abstract;

namespace CorpusExplorer.Terminal.WinForm.Forms.WordBag.Operator
{
  public class WordBagBuilderOperatorStartsWithCaseSensitive : AbstractWordBagBuilderOperator
  {
    private string _query;

    public override void Initialize(string query)
      => _query = query;

    public override bool IsMatch(string token)
      => token.StartsWith(_query);
  }
}