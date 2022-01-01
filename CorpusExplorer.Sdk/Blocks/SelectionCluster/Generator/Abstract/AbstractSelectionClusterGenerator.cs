#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Model;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract
{
  public abstract class AbstractSelectionClusterGenerator
  {
    public string MetadataKey { get; set; }

    public abstract AbstractCluster[] AutoGenerate(Selection selection);

    protected internal virtual KeyValuePair<Guid, Dictionary<string, object>>[] GetDocumentGuids(Selection selection) =>
      selection.DocumentMetadata.ToArray();
  }
}