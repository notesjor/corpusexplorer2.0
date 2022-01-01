#region

using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Model;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster
{
  public class DocumentCounterCluster : AbstractCountCluster
  {
    public DocumentCounterCluster(Selection selection, string displayname) : base(selection, displayname)
    {
    }

    protected override bool CanAdd(Guid documentGuid, long counter, long max) => AcceptAll || counter < max;

    protected override long Count(Guid documentGuid) => 1;
  }
}