#region

using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Model;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Counter.Abstract
{
  public abstract class AbstractCounterClusterType
  {
    protected abstract Selection Selection { get; set; }
    public abstract int BaseSum(Selection selection);
    public abstract AbstractCluster NewCluster(string displayname, int max, bool acceptAll);
  }
}