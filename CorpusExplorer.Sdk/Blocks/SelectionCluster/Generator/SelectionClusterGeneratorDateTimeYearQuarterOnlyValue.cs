using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator
{
  public class SelectionClusterGeneratorDateTimeYearQuarterOnlyValue :
    AbstractSelectionClusterGeneratorValue
  {
    protected override string GenerateKey(object value)
    {
      return value == null
               ? string.Empty
               : value is DateTime
                 ? $"{(DateTime) value:yyyy}-Q{DateTimeHelper.GetYearQuarter((DateTime) value)}"
                 : value.ToString();
    }

    protected override AbstractCluster NewCluster(object value)
    {
      return new DateTimeYearQuarterOnlyCluster(value as DateTime? ?? DateTime.MinValue);
    }
  }
}