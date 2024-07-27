#region

using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator
{
  public class SelectionClusterGeneratorDateTimeYear :
    AbstractSelectionClusterGeneratorDateTime
  {
    protected override string GenerateKey(DateTime value) 
      => value.ToString("yyyy");

    protected override AbstractCluster NewCluster(DateTime value) =>
      new DateTimeYearCluster(value);
  }
}