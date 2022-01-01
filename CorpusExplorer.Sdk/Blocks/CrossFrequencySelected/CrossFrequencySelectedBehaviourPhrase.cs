using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.CrossFrequencySelected.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

namespace CorpusExplorer.Sdk.Blocks.CrossFrequencySelected
{
  public class CrossFrequencySelectedBehaviourPhrase : AbstractCrossFrequencySelectedBehaviour
  {
    public override AbstractFilterQuery GetFilterQuery(string layerDisplayname, IEnumerable<string> layerQueries)
      => new FilterQuerySingleLayerExactPhrase { LayerDisplayname = layerDisplayname, LayerQueries = layerQueries };
  }
}
