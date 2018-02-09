#region

using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Sdk.ViewModel.Interfaces;
using CorpusExplorer.Terminal.WinForm.Forms.PosFilter;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.View.AbstractTemplates;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Terminal.WinForm.Forms.Simple;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.Cooccurrence
{
  /// <summary>
  ///   The grid visualisation.
  /// </summary>
  public partial class CooccurrenceGridSearch : AbstractGridViewWithCodeLense
  {
    private CooccurrenceSelectiveViewModel _vm;

    public CooccurrenceGridSearch()
    {
      InitializeComponent();
      InitializeGrid(radGridView1);
      ShowView += ShowViewCall;
    }

    private void Analyse()
    {
      _vm = ViewModelGet<CooccurrenceSelectiveViewModel>();
      _vm.Analyse();
      txt_query.AutoCompleteDataSource = _vm.AvailableLayerValues;
    }

    private void btn_search_Click(object sender, EventArgs e)
    {
      Processing.Invoke(
        "Berechne Kookkurrenzen...",
        () =>
        {
          _vm.LayerQueries = txt_query.Text.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
          _vm.Analyse();
          
          radGridView1.DataSource = _vm.GetDataTable();
          radGridView1.ResetBindings();
          radGridView1.BestFitColumns(BestFitColumnMode.HeaderCells);
          radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

          AddSummaryRow();
          AddChildTemplate(CreateChildTemplate);
        });
    }

    private AbstractFilterQuery CreateChildTemplate(DataRowView row)
    {
      var queries = txt_query.Items.Select(x => x.Text).ToList();
      queries.Add(row[Resources.Kookkurrenz].ToString());

      return new FilterQuerySingleLayerAllInOneSentence
      {
        Inverse = false,
        LayerDisplayname = "Wort",
        LayerQueries = queries
      };
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

    private void btn_filtereditor_Click(object sender, EventArgs e) { QueryBuilderFunction(Resources.Kookkurrenz); }

    private void btn_filterlist_Click(object sender, EventArgs e)
    {
      FilterListFunction(Resources.StringLabel, Resources.Cooccurrence);
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
                      row => new FilterQuerySingleLayerAllInOneSentence
                      {
                        LayerDisplayname = "Wort",
                        Inverse = false,
                        LayerQueries =
                          new[]
                          {
                            txt_query.Text,
                            row.Cells[Resources.Kookkurrenz].Value.ToString()
                          }
                      }));
    }

    private void ShowViewCall(object sender, EventArgs e)
    {
      Processing.Invoke(Resources.ZählungLäuft, Analyse);
    }
  }
}