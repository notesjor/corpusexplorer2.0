#region

using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator
{
  public class SelectionClusterGeneratorDateTimeDecade :
    AbstractSelectionClusterGeneratorDateTime
  {
    protected override string GenerateKey(DateTime value)
      => value.Year.ToString().Substring(0, 3);

    protected override AbstractCluster NewCluster(DateTime value) =>
      new DateTimeDecadeCluster(value);
  }
}