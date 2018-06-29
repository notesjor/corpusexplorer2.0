using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator
{
  public class SelectionClusterGeneratorDateTimeYearMonthDayHourOnlyValue :
    AbstractSelectionClusterGeneratorValue
  {
    protected override string GenerateKey(object value)
    {
      return value == null
        ? string.Empty
        : value is DateTime
          ? ((DateTime) value).ToString("yyyy-MM-dd_HH")
          : value.ToString();
    }

    protected override AbstractCluster NewCluster(object value)
    {
      return new DateTimeYearMonthDayHourOnlyCluster(value as DateTime? ?? DateTime.MinValue);
    }
  }
}