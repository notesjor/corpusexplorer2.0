#region

using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Sdk.ViewModel.Interfaces;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.View.AbstractTemplates;
using System;
using System.Linq;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.Cooccurrence
{
  /// <summary>
  ///   The grid visualisation.
  /// </summary>
  public partial class CooccurrenceGridAggregated : AbstractGridViewWithCodeLense
  {
    private IProvideDataTable _vm;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractView" /> class.
    /// </summary>
    public CooccurrenceGridAggregated()
    {
      InitializeComponent();
      InitializeGrid(radGridView1);
      ShowView += ShowViewCall;

      wordBag1.AddToRow1(commandBarStripElement1);
      radCommandBar1.Parent.Controls.Remove(radCommandBar1);
    }

    private void Analyse()
    {
      _vm = ViewModelGet<CooccurrenceViewModel>();
      _vm.Analyse();

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
          LayerQueries =
            new[]
            {
              x[Resources.Zeichenkette].ToString(),
              x[Resources.Kookkurrenz].ToString()
            }
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
                            row.Cells[Resources.Zeichenkette].Value.ToString(),
                            row.Cells[Resources.Kookkurrenz].Value.ToString()
                          }
                      }));
    }

    private void ShowViewCall(object sender, EventArgs e) { Processing.Invoke(Resources.ZählungLäuft, Analyse); }

    private void wordBag1_ExecuteButtonClicked(object sender, EventArgs e) { }
  }
}