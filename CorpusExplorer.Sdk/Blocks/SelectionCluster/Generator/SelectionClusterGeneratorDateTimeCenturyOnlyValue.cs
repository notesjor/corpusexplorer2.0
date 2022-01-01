#region

using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator
{
  public class SelectionClusterGeneratorDateTimeCenturyOnlyValue :
    AbstractSelectionClusterGeneratorValue
  {
    protected override string GenerateKey(object value) =>
      value == null
        ? string.Empty
        : value is DateTime
          ? ((DateTime)value).Year.ToString().Substring(0, 2)
          : value.ToString();

    protected override AbstractCluster NewCluster(object value) =>
      new DateTimeCenturyOnlyCluster(value as DateTime? ?? DateTime.MinValue);
  }
}