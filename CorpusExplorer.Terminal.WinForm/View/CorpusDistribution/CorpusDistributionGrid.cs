#region

using System;
using System.Linq;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Sdk.ViewModel.Interfaces;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.View.AbstractTemplates;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.CorpusDistribution
{
  /// <summary>
  ///   The grid visualisation.
  /// </summary>
  public partial class CorpusDistributionGrid : AbstractGridView
  {
    private IProvideDataTable _vm;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractView" /> class.
    /// </summary>
    public CorpusDistributionGrid()
    {
      InitializeComponent();
      InitializeGrid(radGridView1);
      ShowView += ShowViewCall;
    }

    private void Analyse()
    {
      _vm = GetViewModel<CorpusWeightUnlimmitedViewModel>();
      _vm.Execute();

      radGridView1.DataSource = _vm.GetDataTable();
      radGridView1.ResetBindings();
      radGridView1.BestFitColumns(BestFitColumnMode.HeaderCells);
      radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

      AddSummaryRow();
      ApplyFilterDelay();
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

    private void btn_filtereditor_Click(object sender, EventArgs e)
    {
      QueryBuilderFunction(Resources.CorpusDistribution);
    }

    private void btn_filterlist_Click(object sender, EventArgs e)
    {
      FilterListFunction(Resources.Category, Resources.MetadataLabel);
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
      PredefinedFunctions(_vm, Resources.Token, Resources.Types, Resources.Dokumente);
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
      CreateSelection(
                      radGridView1.SelectedRows.Select(
                                                       row => new FilterQueryMetaContains
                                                       {
                                                         Inverse = false,
                                                         MetaLabel =
                                                           row.Cells[Resources.Kategorie].Value.ToString(),
                                                         MetaValues =
                                                           new[]
                                                             {row.Cells[Resources.Metadaten].Value.ToString()}
                                                       }));
    }

    private void ShowViewCall(object sender, EventArgs e)
    {
      Processing.Invoke(Resources.ZählungLäuft, Analyse);
    }

    private void btn_regex_Click(object sender, EventArgs e)
    {
      RegexFunction();
    }
  }
}