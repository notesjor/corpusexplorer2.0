using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator
{
  public class SelectionClusterGeneratorDateTimeYearMonthOnlyValue :
    AbstractSelectionClusterGeneratorValue
  {
    protected override string GenerateKey(object value)
    {
      return value == null
               ? string.Empty
               : value is DateTime
                 ? ((DateTime) value).ToString("yyyy-MM")
                 : value.ToString();
    }

    protected override AbstractCluster NewCluster(object value)
    {
      return new DateTimeYearMonthOnlyCluster(value as DateTime? ?? DateTime.MinValue);
    }
  }
}