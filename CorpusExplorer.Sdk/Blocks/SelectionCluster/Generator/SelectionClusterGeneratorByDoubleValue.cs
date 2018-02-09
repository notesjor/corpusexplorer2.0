using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator
{
  public class SelectionClusterGeneratorByDoubleValue : AbstractSelectionClusterGeneratorByValue
  {
    protected override AbstractCluster NewCluster(object value) { return new DoubleCluster(value as double? ?? 0); }
  }
}