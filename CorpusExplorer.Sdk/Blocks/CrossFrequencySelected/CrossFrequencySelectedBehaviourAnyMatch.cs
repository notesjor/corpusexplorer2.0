using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.CrossFrequencySelected.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

namespace CorpusExplorer.Sdk.Blocks.CrossFrequencySelected
{
  public class CrossFrequencySelectedBehaviourAnyMatch : AbstractCrossFrequencySelectedBehaviour
  {
    public override AbstractFilterQuery GetFilterQuery(string layerDisplayname, IEnumerable<string> layerQueries) 
      => new FilterQuerySingleLayerAnyMatch { LayerDisplayname = layerDisplayname, LayerQueries = layerQueries };
  }
}
