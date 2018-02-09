#region

using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.View.AbstractTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.Frequency
{
  /// <summary>
  ///   The grid visualisation.
  /// </summary>
  public partial class FrequencyGrid : AbstractGridViewWithCodeLense
  {
    private FrequencyViewModel _vm;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractView" /> class.
    /// </summary>
    public FrequencyGrid()
    {
      InitializeComponent();
      InitializeGrid(radGridView1);
      ShowView += ShowViewCall;
    }

    private void Analyse()
    {
      _vm = ViewModelGet<FrequencyViewModel>();
      if (_vm == null)
        return;

      _vm.Analyse();

      radGridView1.DataSource = _vm.GetDataTable();
      radGridView1.ResetBindings();

      AddSummaryRow();
      AddChildTemplate(
        x => new FilterQuerySingleLayerAnyMatch
        {
          Inverse = false,
          LayerDisplayname = "Wort",
          LayerQueries = new[] { x[Resources.ZeichenketteWortform].ToString() }
        });

      radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
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

    private void btn_filter_Click(object sender, EventArgs e) { FilterListFunction("Wort"); }

    private void btn_filterEditor_Click(object sender, EventArgs e) { QueryBuilderFunction(Resources.Frequency); }

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
      var map = _vm.LayerDisplaynames.ToArray();

      CreateSelection(
        radGridView1.SelectedRows.Select(
                      row => new FilterQueryMultiLayer
                      {
                        Inverse = false,
                        MultilayerValues = new Dictionary<string, string>
                        {
                          {
                            map[0],
                            row.Cells[map[0]].Value
                               .ToString()
                          },
                          {
                            map[1],
                            row.Cells[map[1]].Value
                               .ToString()
                          },
                          {
                            map[2],
                            row.Cells[map[2]].Value
                               .ToString()
                          }
                        }
                      }));
    }

    private void ShowViewCall(object sender, EventArgs e)
    {
      Processing.Invoke(Resources.AnalysiereUndStelleRelationenHer, Analyse);
    }
  }
}