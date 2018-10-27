#region

using System;
using System.Data;
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

namespace CorpusExplorer.Terminal.WinForm.View.Ngram
{
  /// <summary>
  ///   The grid visualisation.
  /// </summary>
  public partial class NGramGrid : AbstractGridViewWithTextLense
  {
    private NgramViewModel _vm;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractView" /> class.
    /// </summary>
    public NGramGrid()
    {
      InitializeComponent();
      radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
      radGridView1.AllowAutoSizeColumns = true;
      InitializeGrid(radGridView1);
    }

    private void Analyse()
    {
      _vm = GetViewModel<NgramViewModel>();
      _vm.NGramSize = int.Parse(txt_size.Text);
      _vm.NGramPatternSize = int.Parse(txt_pattern.Text);
      if (SelectedLayerDisplaynames != null)
        _vm.LayerDisplayname = SelectedLayerDisplaynames[0];
      if (!_vm.Execute())
        return;
      BindData();

      UseParentCellForHighlighting = Resources.NGramm;

      AddSummaryRow();
      AddChildTemplate(
        delegate(DataRowView x)
        {
          var queries = x[Resources.NGramm].ToString()
            .Replace(
              _vm.NGramPattern,
              FilterQuerySingleLayerExactPhrase.SearchPattern)
            .Split(
              new[] {" "},
              StringSplitOptions.RemoveEmptyEntries);
          return new FilterQuerySingleLayerExactPhrase
          {
            Inverse = false,
            LayerDisplayname = _vm.LayerDisplayname,
            LayerQueries = queries
          };
        });
    }

    private void BindData()
    {
      radGridView1.DataSource = _vm.GetDataTable();
      radGridView1.ResetBindings();
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

    private void btn_execute_Click(object sender, EventArgs e)
    {
      Processing.Invoke(Resources.ErstelleUndZähleNGramme, Analyse);
    }

    private void btn_filtereditor_Click(object sender, EventArgs e)
    {
      QueryBuilderFunction(Resources.NGramm);
    }

    private void btn_filterlist_Click(object sender, EventArgs e)
    {
      FilterListFunction(Resources.NGram);
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
          row => new FilterQuerySingleLayerExactPhrase
          {
            Inverse = false,
            LayerDisplayname = _vm.LayerDisplayname,
            LayerQueries =
              row.Cells[Resources.NGramm].Value.ToString()
                .Replace(
                  _vm.NGramPattern,
                  FilterQuerySingleLayerExactPhrase
                    .SearchPattern)
                .Split(
                  new[] {" "},
                  StringSplitOptions
                    .RemoveEmptyEntries)
          }));
    }

    private void GridNGramVisualisation_ShowVisualisation(object sender, EventArgs e)
    {
      _vm = GetViewModel<NgramViewModel>();
    }

    private void btn_layer_Click(object sender, EventArgs e)
    {
      var form = new Select1Layer(SelectedLayerDisplaynames);
      form.ShowDialog();
      SelectedLayerDisplaynames = form.ResultSelectedLayerDisplaynames;
      Analyse();
    }
  }
}