using System.Collections.Generic;
using CorpusExplorer.Sdk.Action.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

namespace CorpusExplorer.Sdk.Action
{
  public class KwicAllInDocumentFilterAction : AbstractFilterAction
  {
    public override string Action => "kwic-document";

    public override string Description =>
      "kwic-document [LAYER] [WORDS] - [WORDS] = space separated tokens - a document must contains all token";

    protected override AbstractFilterQuery GetQuery(string layerDisplayname, IEnumerable<string> queries)
    {
      return new FilterQuerySingleLayerAllInOnDocument {LayerDisplayname = layerDisplayname, LayerQueries = queries};
    }
  }
}