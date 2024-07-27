#region

using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator
{
  public class SelectionClusterGeneratorDateTime :
    AbstractSelectionClusterGeneratorDateTime
  {
    protected override string GenerateKey(DateTime value) 
      => value.ToString("yyyy-MM-dd_HH:mm:ss");

    protected override AbstractCluster NewCluster(DateTime value) =>
      new DateTimeCluster(value);
  }
}