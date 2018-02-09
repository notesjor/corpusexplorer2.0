#region

using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Kwic;
using CorpusExplorer.Terminal.WinForm.Forms.Simple;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Blocks.Flow;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;
using PositionChangedEventArgs = Telerik.WinControls.UI.Data.PositionChangedEventArgs;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.Fulltext
{
  public partial class FulltextKwicTree : AbstractView
  {
    private TextFlowSearchViewModel _vm;

    public FulltextKwicTree()
    {
      InitializeComponent();
      ShowView += OnShowView;
    }

    private void OnShowView(object sender, EventArgs eventArgs)
    {
      _vm = ViewModelGet<TextFlowSearchViewModel>();
      txt_query.AutoCompleteDataSource = _vm.LayerValues;
    }

    private void Analyse(bool highlight)
    {
      if ((txt_query.Items == null) ||
          (txt_query.Items.Count == 0))
        return;

      Processing.Invoke(
        Resources.SucheFundstellen,
        () =>
        {
          _vm.LayerQueryPhrase = txt_query.Text.Split(new[] {" ", ";"}, StringSplitOptions.RemoveEmptyEntries);
          _vm.HighlightCooccurrences = highlight;
          _vm.Analyse();          

          wpfDiagram1.CallNew();
          BuildTree();
        });
    }

    private void BuildTree()
    {
      Processing.Invoke("Setze Struktur zusammen...",
        () =>
        {
          elementHost1.SuspendLayout();
          BuildTree(_vm.BranchPost, BuildTree(_vm.BranchPre, Guid.Empty, true, true), false, false);
          wpfDiagram1.CallLayoutAsHorizontalTree();
          elementHost1.ResumeLayout(false);
        });      
    }

    private Guid BuildTree(FlowNode node, Guid parentNodeGuid, bool forward, bool first)
    {
      var current = wpfDiagram1.CallAddNode(node.Content, first ? new UniversalColor(150, 255, 180) : null);
      if(parentNodeGuid != Guid.Empty)
        if (forward)
          wpfDiagram1.CallAddConnection(current, parentNodeGuid, true);
        else
          wpfDiagram1.CallAddConnection(parentNodeGuid, current, true);

      foreach (var child in node.Children)
      {
        BuildTree(child, current, forward, false);
      }

      return current;
    }

    private void btn_start_cooccurrence_Click(object sender, EventArgs e)
    {
      Analyse(true);
    }

    private void btn_start_normal_Click(object sender, EventArgs e)
    {
      Analyse(false);
    }
  }
}