using System.Collections.Generic;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;

namespace CorpusExplorer.Sdk.Blocks.CrossFrequencySelected.Abstract
{
  public abstract class AbstractCrossFrequencySelectedBehaviour
  {
    public abstract AbstractFilterQuery GetFilterQuery(string layer, IEnumerable<string> layerQueries);
  }
}
