using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract
{
  public abstract class AbstractSelectionClusterGenerator
  {
    public string MetadataKey { get; set; }

    public AbstractCluster[] AutoGenerate(Selection selection)
    {
      return AutoGenerate(
        selection.DocumentMetadata.AsParallel()
                 .Where(x => x.Value.ContainsKey(MetadataKey))
                 .ToDictionary(x => x.Key, x => x.Value[MetadataKey]));
    }

    protected abstract AbstractCluster[] AutoGenerate(Dictionary<Guid, object> metadataDictionary);
  }
}