#region

using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Model;

#endregion

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Helper
{
  public static class ClusterToSelectionHelper
  {
    public static Selection ToSelection(this AbstractCluster cluster, Project project, Selection selection)
      => selection == null
           ? project.SelectAll.Create(cluster.DocumentGuids, cluster.Displayname, true)
           : selection.Create(cluster.DocumentGuids, cluster.Displayname, false);

    public static IEnumerable<Selection> ToSelection(this IEnumerable<AbstractCluster> clusters, Project project,
                                                     Selection selection)
      => clusters.Select(cluster => ToSelection(cluster, project, selection));

    public static Selection ToTemporarySelection(this AbstractCluster cluster, Selection selection)
    {
      var res = selection.CreateTemporary(cluster.DocumentGuids);
      res.Displayname = cluster.Displayname;
      return res;
    }

    public static IEnumerable<Selection> ToTemporarySelection(this IEnumerable<AbstractCluster> clusters,
                                                              Selection selection)
      => clusters.Select(cluster => ToTemporarySelection(cluster, selection));
  }
}