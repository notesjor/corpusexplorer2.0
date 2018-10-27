using System.Collections.Generic;
using CorpusExplorer.Sdk.Action.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

namespace CorpusExplorer.Sdk.Action
{
  public class KwicFirstAnyFilterAction : AbstractFilterAction
  {
    public override string Action => "kwic-first-any";

    public override string Description =>
      "kwic-first-any [LAYER] [WORD] [WORDS] - KWIC any occurrence - [WORDS] = space separated tokens (KWIC must contains first token + any other)";

    protected override AbstractFilterQuery GetQuery(string layerDisplayname, IEnumerable<string> queries)
    {
      return new FilterQuerySingleLayerFirstAndAnyOtherMatch
      {
        LayerDisplayname = layerDisplayname,
        LayerQueries = queries
      };
    }
  }
}