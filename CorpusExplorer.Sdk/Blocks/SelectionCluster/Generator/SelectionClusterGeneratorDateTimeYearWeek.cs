#region

using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;
using CorpusExplorer.Sdk.Helper;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator
{
  public class SelectionClusterGeneratorDateTimeYearWeek :
    AbstractSelectionClusterGeneratorDateTime
  {
    protected override string GenerateKey(DateTime value) 
      => $"{value:yyyy}-W{DateTimeHelper.GetYearWeek(value):D2}";

    protected override AbstractCluster NewCluster(DateTime value) =>
      new DateTimeYearWeekCluster(value);
  }
}