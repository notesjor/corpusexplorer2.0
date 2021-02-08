using System.Linq;
using CorpusExplorer.Terminal.WinForm.Forms.WordBag.Operator.Abstract;

namespace CorpusExplorer.Terminal.WinForm.Forms.WordBag.Operator
{
  public class WordBagBuilderOperatorContainsCaseSensitive : AbstractWordBagBuilderOperator
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
}