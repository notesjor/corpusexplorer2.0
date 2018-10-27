using System;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using Telerik.WinControls.UI.Data;

#region

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.StyleMetrics
{
  /// <summary>
  ///   The heat map visualisation.
  /// </summary>
  public partial class CompareBasedOnBurrowsDelta : AbstractView
  {
    private ClusterMetadataByBurrowsDeltaViewModel _vm;
    private DataTable _data;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractView" /> class.
    /// </summary>
    public CompareBasedOnBurrowsDelta()
    {
      InitializeComponent();
      ShowView += ShowViewCall;
    }

    private void Analyse()
    {
      _vm.Execute();
      _data = _vm.GetDataTable();
      radPivotGrid1.DataSource = _data;
    }

    private void btn_export_Click(object sender, EventArgs e)
    {
      DataTableExporter.Export(_data);
    }

    private void ShowViewCall(object sender, EventArgs e)
    {
      _vm = GetViewModel<ClusterMetadataByBurrowsDeltaViewModel>();

      var groupA = Project.CurrentSelection.GetDocumentMetadataPrototypeOnlyProperties().ToList();
      var groupB = Project.CurrentSelection.GetDocumentMetadataPrototypeOnlyProperties().ToList();

      combo_groupA.DataSource = groupA;
      combo_groupB.DataSource = groupB;

      combo_groupA.SelectedValue = groupA.FirstOrDefault();
      combo_groupB.SelectedValue = groupB.Last();
    }

    private void btn_start_Click(object sender, EventArgs e)
    {
      if (combo_groupA.SelectedIndex == -1 ||
          combo_groupB.SelectedIndex == -1 ||
          combo_groupA.SelectedIndex == combo_groupB.SelectedIndex)
        return;

      _vm.MetadataKeyA = combo_groupA.SelectedItem.Text;
      _vm.MetadataKeyB = combo_groupB.SelectedItem.Text;

      Processing.Invoke(Resources.VergleicheMetadaten, Analyse);
    }
  }
}