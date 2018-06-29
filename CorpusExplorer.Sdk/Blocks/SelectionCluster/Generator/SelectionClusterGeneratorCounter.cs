using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Counter;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Counter.Abstract;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator
{
  public class SelectionClusterGeneratorCounter : AbstractSelectionClusterGenerator
  {
    public AbstractCounterClusterType ClusterType;
    public GetOrderByValueDelegate GetOrderByValue;

    public SelectionClusterGeneratorCounter()
    {
      ClusterType = new CounterClusterTypeDocument();
      GetOrderByValue = PredefinedGetOrderByValueDelegateDelegates.GetString;
    }

    public bool EnableAutoOrder { get; set; } = false;
    public int Ranges { get; set; } = 10;

    public override AbstractCluster[] AutoGenerate(Selection selection)
    {
      var sum = ClusterType.BaseSum(selection);
      var parts = sum / Ranges;

      var res = new AbstractCluster[Ranges + 1];
      for (var i = 0; i < res.Length; i++)
        res[i] = ClusterType.NewCluster(
          i + 1 == res.Length
            ? $"{selection.Displayname} - REST"
            : $"{selection.Displayname} - {i + 1}/{res.Length - 1}",
          parts,
          i + 1 == res.Length);

      return res;
    }

    protected internal override KeyValuePair<Guid, Dictionary<string, object>>[] GetDocumentGuids(Selection selection)
    {
      return EnableAutoOrder ? AutoOrder(selection) : base.GetDocumentGuids(selection);
    }

    private KeyValuePair<Guid, Dictionary<string, object>>[] AutoOrder(Selection selection)
    {
      return selection.DocumentMetadata.OrderBy(x =>
          GetOrderByValue(x.Value == null ? null : x.Value.ContainsKey(MetadataKey) ? x.Value[MetadataKey] : null))
        .ToArray();
    }
  }
}