using System.Linq;
using CorpusExplorer.Terminal.WinForm.Forms.Simple;
using CorpusExplorer.Terminal.WinForm.Properties;

#region

using System;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using Telerik.WinControls.UI;
using PositionChangedEventArgs = Telerik.WinControls.UI.Data.PositionChangedEventArgs;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.EditionTools
{
  /// <summary>
  ///   The text similarity page.
  /// </summary>
  public partial class TextSimilarity : AbstractView
  {
    private DocumentSimilarityViewModel _vm;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractView" /> class.
    /// </summary>
    public TextSimilarity()
    {
      InitializeComponent();
    }

    private void combo_meta_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      if (combo_meta.SelectedItem == null)
        return;

      _vm.SelectedDocumentMetaProperty = combo_meta.SelectedItem.Text;

      ResetNodes();
    }

    private void ResetNodes()
    {
      if (combo_meta.SelectedItem == null)
        return;

      tree_results.Nodes.Clear();
    }

    private void TextSimilarityPage_ShowVisualisation(object sender, EventArgs e)
    {
      _vm = GetViewModel<DocumentSimilarityViewModel>();
      _vm.Execute();
      combo_meta.DataSource = _vm.DocumentMetaProperties;
      combo_meta.SelectedIndex = 0;
    }

    private void tree_results_NodeMouseClick(object sender, RadTreeViewEventArgs e)
    {
      if (e.Node.Level != 1)
        return;
      var docsA = _vm.RequestDocumentGuidByMetadata((string) e.Node.Parent.Tag);
      var docsB = _vm.RequestDocumentGuidByMetadata((string) e.Node.Tag);

      var diff = GetViewModel<DiffViewModel>();

      var form = new SimpleTextCompare(diff, docsA, docsB);
      form.ShowDialog();
    }

    private void tree_results_NodesNeeded(object sender, NodesNeededEventArgs e)
    {
      if (_vm?.DocumentGuids == null)
        return;
      if (e.Parent == null)
      {
        foreach (var entry in _vm.RequestMetadataSimilarityValues())
          e.Nodes.Add(new RadTreeNode(entry) {Tag = entry});
        return;
      }

      if (e.Parent.Level != 0)
        return;

      var value = (string) e.Parent.Tag;

      var dic = _vm.RequestMetadataSimilarity(value);
      if (dic       == null ||
          dic.Count == 0)
        return;

      var requ = dic.ToList();
      requ.Sort((x, y) => y.Value.CompareTo(x.Value));

      foreach (
        var node in
        requ.Select(
                    entry =>
                      new RadTreeNode(string.Format(Resources.DashboardPatternProcent, entry.Value * 100, entry.Key))
                      {
                        Tag = entry.Key
                      }))
        e.Nodes.Add(node);
    }

    private void txt_searchQuery_TextChanged(object sender, EventArgs e)
    {
      tree_results.Filter = txt_searchQuery.Text;
    }
  }
}