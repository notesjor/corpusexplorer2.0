#region

using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;
using CorpusExplorer.Sdk.Helper;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator
{
  public class SelectionClusterGeneratorDateTimeYearWeekOnlyValue :
    AbstractSelectionClusterGeneratorValue
  {
    protected override string GenerateKey(object value) =>
      value == null
        ? string.Empty
        : value is DateTime
          ? $"{(DateTime)value:yyyy}-W{DateTimeHelper.GetYearWeek((DateTime)value):D2}"
          : value.ToString();

    protected override AbstractCluster NewCluster(object value) =>
      new DateTimeYearWeekOnlyCluster(value as DateTime? ?? DateTime.MinValue);
  }
}