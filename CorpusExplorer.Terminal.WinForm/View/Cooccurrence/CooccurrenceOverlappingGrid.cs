#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.SelectLayer;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.View.AbstractTemplates;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.Cooccurrence
{
  /// <summary>
  ///   The grid visualisation.
  /// </summary>
  public partial class CooccurrenceOverlappingGrid : AbstractGridViewWithTextLense
  {
    private CooccurrenceOverlappingViewModel _vm;

    public CooccurrenceOverlappingGrid()
    {
      InitializeComponent();
      InitializeGrid(radGridView1);
      ShowView += ShowViewCall;
    }

    private void Analyse()
    {
      _vm = GetViewModel<CooccurrenceOverlappingViewModel>();
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
      QueryBuilderFunction(Resources.Kookkurrenz);
    }

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

    private void btn_search_Click(object sender, EventArgs e)
    {
      Processing.Invoke(
                        "Berechne Multi-Kookkurrenzen...",
                        () =>
                        {
                          _vm.LayerDisplayname = wordBag1.ResultSelectedLayerDisplayname;
                          _vm.LayerQueries = wordBag1.ResultQueries;
                          if (!_vm.Execute())
                            return;
                          radGridView1.DataSource = _vm.GetDataTable();
                          radGridView1.ResetBindings();
                          radGridView1.BestFitColumns(BestFitColumnMode.HeaderCells);
                          radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

                          AddSummaryRow();
                          ApplyFilterDelay();
                          AddChildTemplate(CreateChildTemplate);
                        });
    }

    private void btn_snapshot_create_Click(object sender, EventArgs e)
    {
      CreateSelection(
                      radGridView1.SelectedRows.Select(
                                                       delegate (GridViewRowInfo row)
                                                       {
                                                         var queries = new List<string> { row.Cells[Resources.Kookkurrenz].ToString() };
                                                         queries.AddRange(wordBag1.ResultQueries);

                                                         return new FilterQuerySingleLayerFirstAndAnyOtherMatch
                                                         {
                                                           LayerDisplayname = wordBag1.ResultSelectedLayerDisplayname,
                                                           Inverse = false,
                                                           LayerQueries = queries
                                                         };
                                                       }));
    }

    private AbstractFilterQuery CreateChildTemplate(DataRowView row)
    {
      var queries = new List<string> { row[Resources.Kookkurrenz].ToString() };
      queries.AddRange(wordBag1.ResultQueries);

      return new FilterQuerySingleLayerFirstAndAnyOtherMatch
      {
        Inverse = false,
        LayerDisplayname = _vm.LayerDisplayname,
        LayerQueries = queries
      };
    }

    private void ShowViewCall(object sender, EventArgs e)
    {
      /*
      btn_posFilter.Visibility = Project.CurrentSelection.ContainsLayer("POS")
                                   ? ElementVisibility.Visible
                                   : ElementVisibility.Collapsed;
      */
      Processing.Invoke(Resources.ZählungLäuft, Analyse);
    }

    private void btn_layer_Click(object sender, EventArgs e)
    {
      var form = new Select1Layer(SelectedLayerDisplaynames);
      form.ShowDialog();
      SelectedLayerDisplaynames = form.ResultSelectedLayerDisplaynames;
      Analyse();
    }

    private void btn_regex_Click(object sender, EventArgs e)
    {
      RegexFunction();
    }
  }
}