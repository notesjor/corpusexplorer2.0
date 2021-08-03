using System;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster
{
  public class TokenCounterCluster : AbstractCountCluster
  {
    public TokenCounterCluster(Selection selection, string displayname) : base(selection, displayname)
    {
    }

    protected override bool CanAdd(Guid documentGuid, long counter, long max)
    {
      return AcceptAll || counter < max;
    }

    protected override long Count(Guid documentGuid)
    {
      return Selection.GetDocumentLengthInWords(documentGuid);
    }
  }
}