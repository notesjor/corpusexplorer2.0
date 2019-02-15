using System;
using CorpusExplorer.Sdk.Blocks.ClusterMetadata;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using Telerik.WinControls.UI;

#region

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.StyleMetrics
{
  /// <summary>
  ///   The text similarity page.
  /// </summary>
  public partial class CompareBasedOnNgrams : AbstractView
  {
    private ClusterMetadataByNGramViewModel _vm;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractView" /> class.
    /// </summary>
    public CompareBasedOnNgrams()
    {
      InitializeComponent();
    }

    private void ResetNodes()
    {
      if (combo_meta.SelectedItem == null)
        return;

      tree_results.Nodes.Clear();

      Processing.Invoke("Der Cluster-Baum wächst und wächst und ...", () =>
      {
        _vm.NGramSize = int.Parse(txt_ngramSize.Text);
        _vm.NGramMinFrequency = 5;
        _vm.Execute();
        BuildTree(tree_results.Nodes.Add("/WURZEL/"), _vm.RootCluster);

        tree_results.ExpandAll();
      });
    }

    private void BuildTree(RadTreeNode parent, ClusterMetadataItem cluster)
    {
      if (cluster == null)
        return;

      var current = parent.Nodes.Add($"{Math.Round(cluster.Similarity, 4)} - {cluster.Label}");
      BuildTree(current, cluster.CA);
      BuildTree(current, cluster.CB);
    }

    private void TextSimilarityPage_ShowVisualisation(object sender, EventArgs e)
    {
      _vm = GetViewModel<ClusterMetadataByNGramViewModel>();
      combo_meta.DataSource = _vm.DocumentMetaProperties;
      combo_meta.SelectedIndex = 0;
    }

    private void txt_searchQuery_TextChanged(object sender, EventArgs e)
    {
      tree_results.Filter = txt_searchQuery.Text;
    }

    private void btn_start_Click(object sender, EventArgs e)
    {
      if (combo_meta.SelectedItem == null)
        return;

      _vm.MetadataKey = combo_meta.SelectedItem.Text;

      ResetNodes();
    }
  }
}