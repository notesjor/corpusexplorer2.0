using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator
{
  public class SelectionClusterGeneratorIntegerValue : AbstractSelectionClusterGeneratorValue
  {
    protected override string GenerateKey(object value)
    {
      return value.SafeCastString();
    }

    protected override AbstractCluster NewCluster(object value)
    {
      return new IntegerCluster(value as int? ?? 0);
    }
  }
}