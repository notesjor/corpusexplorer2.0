using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator
{
  public class SelectionClusterGeneratorByDateTimeYearOnlyValue :
    AbstractSelectionClusterGeneratorByValue
  {
    protected override AbstractCluster NewCluster(object value)
    {
      return new DateTimeYearOnlyCluster(value as DateTime? ?? DateTime.MinValue);
    }
  }
}