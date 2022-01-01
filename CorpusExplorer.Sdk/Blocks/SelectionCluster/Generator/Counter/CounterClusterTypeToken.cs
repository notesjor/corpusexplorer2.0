#region

using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Counter.Abstract;
using CorpusExplorer.Sdk.Model;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Counter
{
  public class CounterClusterTypeToken : AbstractCounterClusterType
  {
    protected override Selection Selection { get; set; }

    public override int BaseSum(Selection selection)
    {
      Selection = selection;
      return (int)selection.CountToken;
    }

    public override AbstractCluster NewCluster(string displayname, int max, bool acceptAll) =>
      new TokenCounterCluster(Selection, displayname)
      {
        Max = max,
        AcceptAll = acceptAll
      };
  }
}