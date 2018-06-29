using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Counter.Abstract;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Counter
{
  public class CounterClusterTypeDocument : AbstractCounterClusterType
  {
    protected override Selection Selection { get; set; }

    public override int BaseSum(Selection selection)
    {
      Selection = selection;
      return selection.CountDocuments;
    }

    public override AbstractCluster NewCluster(string displayname, int max, bool acceptAll)
    {
      return new DocumentCounterCluster(Selection, displayname)
      {
        Max = max,
        AcceptAll = acceptAll
      };
    }
  }
}