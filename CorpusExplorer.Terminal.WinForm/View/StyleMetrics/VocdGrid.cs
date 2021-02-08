#region

using System;
using System.Linq;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.SelectLayer;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.View.AbstractTemplates;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.StyleMetrics
{
  /// <summary>
  ///   The grid visualisation.
  /// </summary>
  public partial class VocdGrid : AbstractGridView
  {
    private VocdViewModel _vm;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractView" /> class.
    /// </summary>
    public VocdGrid()
    {
      InitializeComponent();
      InitializeGrid(radGridView1);
      ShowView += ShowViewCall;
    }

    /// <summary>
    ///   The btn_calc_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void btn_calc_Click(object sender, EventArgs e)
    {
      CalculatorFunction();
    }

    /// <summary>
    ///   The btn_csv export_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void btn_csvExport_Click(object sender, EventArgs e)
    {
      ExportFunction();
    }

    private void btn_filter_Click(object sender, EventArgs e)
    {
      FilterListFunction(_vm.LayerDisplayname);
    }

    private void btn_filterEditor_Click(object sender, EventArgs e)
    {
      QueryBuilderFunction(Resources.Frequency);
    }

    /// <summary>
    ///   The btn_function_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void btn_function_Click(object sender, EventArgs e)
    {
      PredefinedFunctions(_vm, Resources.Frequency);
    }

    private void btn_layers_Click(object sender, EventArgs e)
    {
      var form = new Select1Layer(new[] { _vm.LayerDisplayname });
      form.ShowDialog();
      _vm.LayerDisplayname = form.ResultSelectedLayer1Displayname;
    }

    /// <summary>
    ///   The btn_print_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void btn_print_Click(object sender, EventArgs e)
    {
      radGridView1.PrintPreview();
    }

    private void btn_snapshot_create_Click(object sender, EventArgs e)
    {
      var queries = radGridView1.SelectedRows.Select(row => row.Cells[_vm.LayerDisplayname].Value.ToString());

      CreateSelection(new[]
      {
        new FilterQuerySingleLayerAnyMatch()
        {
          Inverse = false,
          LayerDisplayname = _vm.LayerDisplayname,
          LayerQueries = queries
        }
      });
    }

    private void ShowViewCall(object sender, EventArgs e)
    {
      _vm = GetViewModel<VocdViewModel>();
      var groupA = Project.CurrentSelection.GetDocumentMetadataPrototypeOnlyProperties().ToList();
      
      cmb_meta.DataSource = groupA;
      cmb_meta.SelectedValue = groupA.FirstOrDefault();
    }

    private void btn_regex_Click(object sender, EventArgs e)
    {
      RegexFunction();
    }

    private void btn_run_Click(object sender, EventArgs e)
    {
      Processing.Invoke(null, () =>
      {
        _vm.MetadataKey = cmb_meta.SelectedItem.Text;
        _vm.Execute();
        radGridView1.DataSource = _vm.GetDataTable();
        radGridView1.ResetBindings();

        AddSummaryRow();
        ApplyFilterDelay();

        radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
      });
    }
  }
}