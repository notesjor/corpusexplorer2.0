using CorpusExplorer.Terminal.WinForm.Properties;

#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Disambiguation;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.Disambigution
{
  public partial class DisambigutionTree : AbstractView
  {
    public DisambigutionTree()
    {
      InitializeComponent();
    }

    private void Analyse()
    {
      var vm = GetViewModel<DisambiguationViewModel>();
      vm.LayerQuery = wordBag1.ResultQueries.First();
      vm.LayerDisplayname = wordBag1.ResultSelectedLayerDisplayname;
      vm.Analyse();

      var root = new RadTreeNode(string.Format(Resources.ProfilVon0, wordBag1.ResultQueries.First()));
      RecursivFillNode(root, vm.RootCluster.GetClusters());

      radTreeView1.Nodes.Clear();
      radTreeView1.Nodes.Add(root);
    }

    private void wordBag1_ExecuteButtonClicked(object sender, EventArgs e)
    {
      Processing.Invoke(Resources.DisambiguierungLäuft, Analyse);
    }

    private void RecursivFillNode(RadTreeNode parent, IEnumerable<IDisambiguationCluster> clusters)
    {
      if (clusters == null)
        return;

      var c = clusters.ToArray();
      if (c.Length < 2 ||
          c[1] == null)
        return;

      foreach (var cluster in c)
      {
        var node = new RadTreeNode(cluster.Label);
        parent.Nodes.Add(node);
        RecursivFillNode(node, cluster.GetClusters());
      }
    }
  }
}