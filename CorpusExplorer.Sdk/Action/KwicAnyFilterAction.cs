using System.Collections.Generic;
using CorpusExplorer.Sdk.Action.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

namespace CorpusExplorer.Sdk.Action
{
  public class KwicAnyFilterAction : AbstractFilterAction
  {
    public override string Action => "kwic-any";

    public override string Description =>
      "kwic-any [LAYER] [WORDS] - KWIC any occurrence - [WORDS] = space separated tokens";

    protected override AbstractFilterQuery GetQuery(string layerDisplayname, IEnumerable<string> queries)
    {
      return new FilterQuerySingleLayerAnyMatch {LayerDisplayname = layerDisplayname, LayerQueries = queries};
    }
  }
}