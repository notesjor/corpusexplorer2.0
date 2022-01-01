#region

using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;
using CorpusExplorer.Sdk.Helper;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator
{
  public class SelectionClusterGeneratorDoubleValue : AbstractSelectionClusterGeneratorValue
  {
    protected override string GenerateKey(object value) => value.SafeCastString();

    protected override AbstractCluster NewCluster(object value) => new DoubleCluster(value as double? ?? 0);
  }
}