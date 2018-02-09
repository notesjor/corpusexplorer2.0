﻿#region

using System;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.View.AbstractTemplates;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.Disambigution
{
  /// <summary>
  ///   The grid visualisation.
  /// </summary>
  public partial class DisambigutionGrid : AbstractGridViewWithCodeLense
  {
    private DisambiguationViewModel _vm;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractView" /> class.
    /// </summary>
    public DisambigutionGrid()
    {
      InitializeComponent();
      InitializeGrid(radGridView1);
    }

    private void Analyse()
    {
      _vm = ViewModelGet<DisambiguationViewModel>();
      _vm.LayerQuery = txt_queryA.Text;
      _vm.Analyse();
      _vm.DataTableLevel = (int) num_level.Value;

      radGridView1.DataSource = _vm.GetDataTable();
      radGridView1.ResetBindings();
      radGridView1.BestFitColumns(BestFitColumnMode.HeaderCells);
      radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

      AddSummaryRow();
      AddChildTemplate(
        x => new FilterQuerySingleLayerAllInOneSentence
        {
          Inverse = false,
          LayerDisplayname = "Wort",
          LayerQueries = new[] {txt_queryA.Text, x[Resources.Bezeichnung].ToString()}
        });
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
    private void btn_calc_Click(object sender, EventArgs e) { CalculatorFunction(); }

    /// <summary>
    ///   The btn_csv export_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void btn_csvExport_Click(object sender, EventArgs e) { ExportFunction(); }

    private void btn_filtereditor_Click(object sender, EventArgs e) { QueryBuilderFunction(Resources.Disambiguierung); }

    private void btn_filterlist_Click(object sender, EventArgs e) { FilterListFunction(Resources.Label); }

    /// <summary>
    ///   The btn_function_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void btn_function_Click(object sender, EventArgs e) { PredefinedFunctions(_vm, Resources.Wert); }

    /// <summary>
    ///   The btn_print_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void btn_print_Click(object sender, EventArgs e) { radGridView1.PrintPreview(); }

    private void btn_start_Click(object sender, EventArgs e) { Processing.Invoke(Resources.ZählungLäuft, Analyse); }
  }
}