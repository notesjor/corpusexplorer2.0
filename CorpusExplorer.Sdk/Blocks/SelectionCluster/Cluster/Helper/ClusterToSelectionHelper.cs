using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Helper
{
  public static class ClusterToSelectionHelper
  {
    public static Selection ToSelection(this AbstractCluster cluster, Project project)
    {
      return ToSelection(cluster, project.SelectAll);
    }

    public static Selection ToSelection(this AbstractCluster cluster, Selection selection)
    {
      return selection.Create(cluster.DocumentGuids, cluster.Displayname);
    }

    public static IEnumerable<Selection> ToSelection(this IEnumerable<AbstractCluster> clusters, Project project)
    {
      return ToSelection(clusters, project.SelectAll);
    }

    public static IEnumerable<Selection> ToSelection(this IEnumerable<AbstractCluster> clusters, Selection selection)
    {
      return clusters.Select(cluster => ToSelection(cluster, selection));
    }
  }
}