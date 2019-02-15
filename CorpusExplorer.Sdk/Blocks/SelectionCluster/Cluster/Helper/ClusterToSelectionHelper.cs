using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Helper
{
  public static class ClusterToSelectionHelper
  {
    public static Selection ToSelection(this AbstractCluster cluster, Selection selection)
    {
      return selection.Create(cluster.DocumentGuids, cluster.Displayname);
    }

    public static IEnumerable<Selection> ToSelection(this IEnumerable<AbstractCluster> clusters, Selection selection)
    {
      return clusters.Select(cluster => ToSelection(cluster, selection));
    }

    public static Selection ToTemporarySelection(this AbstractCluster cluster, Selection selection)
    {
      var res = selection.CreateTemporary(cluster.DocumentGuids);
      res.Displayname = cluster.Displayname;
      return res;
    }

    public static IEnumerable<Selection> ToTemporarySelection(this IEnumerable<AbstractCluster> clusters,
                                                              Selection selection)
    {
      return clusters.Select(cluster => ToTemporarySelection(cluster, selection));
    }
  }
}