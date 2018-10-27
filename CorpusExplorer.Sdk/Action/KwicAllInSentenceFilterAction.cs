using System.Collections.Generic;
using CorpusExplorer.Sdk.Action.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

namespace CorpusExplorer.Sdk.Action
{
  public class KwicAllInSentenceFilterAction : AbstractFilterAction
  {
    public override string Action => "kwic-sentence";

    public override string Description =>
      "kwic-sentence [LAYER] [WORDS] - [WORDS] = space separated tokens - a sentence must contains all token";

    protected override AbstractFilterQuery GetQuery(string layerDisplayname, IEnumerable<string> queries)
    {
      return new FilterQuerySingleLayerAllInOneSentence {LayerDisplayname = layerDisplayname, LayerQueries = queries};
    }
  }
}