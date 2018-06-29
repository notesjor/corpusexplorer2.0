using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator
{
  public class SelectionClusterGeneratorStringValue : AbstractSelectionClusterGeneratorValue
  {
    protected override string GenerateKey(object value)
    {
      return value?.ToString() ?? string.Empty;
    }

    protected override AbstractCluster NewCluster(object value)
    {
      return new StringCluster(value as string);
    }
  }
}