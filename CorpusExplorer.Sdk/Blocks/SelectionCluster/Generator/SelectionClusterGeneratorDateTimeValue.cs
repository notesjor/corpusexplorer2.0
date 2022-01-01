#region

using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator
{
  public class SelectionClusterGeneratorDateTimeValue :
    AbstractSelectionClusterGeneratorValue
  {
    protected override string GenerateKey(object value) =>
      value == null
        ? string.Empty
        : value is DateTime
          ? ((DateTime)value).ToString("yyyy-MM-dd_HH:mm:ss")
          : value.ToString();

    protected override AbstractCluster NewCluster(object value) =>
      new DateTimeCluster(value as DateTime? ?? DateTime.MinValue);
  }
}