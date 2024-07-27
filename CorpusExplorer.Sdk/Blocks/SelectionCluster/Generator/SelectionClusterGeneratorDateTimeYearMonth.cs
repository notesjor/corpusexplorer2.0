#region

using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator
{
  public class SelectionClusterGeneratorDateTimeYearMonth :
    AbstractSelectionClusterGeneratorDateTime
  {
    protected override string GenerateKey(DateTime value) 
      => value.ToString("yyyy-MM");

    protected override AbstractCluster NewCluster(DateTime value) =>
      new DateTimeYearMonthCluster(value);
  }
}