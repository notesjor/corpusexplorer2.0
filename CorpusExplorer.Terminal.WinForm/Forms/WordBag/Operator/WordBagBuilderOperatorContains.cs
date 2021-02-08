using System.Linq;
using CorpusExplorer.Terminal.WinForm.Forms.WordBag.Operator.Abstract;

namespace CorpusExplorer.Terminal.WinForm.Forms.WordBag.Operator
{
  public class WordBagBuilderOperatorContains : AbstractWordBagBuilderOperator
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
}