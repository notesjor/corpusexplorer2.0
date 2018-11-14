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

namespace CorpusExplorer.Terminal.WinForm.View.Cooccurrence
{
  /// <summary>
  ///   The grid visualisation.
  /// </summary>
  public partial class CooccurrenceMultiwordGrid : AbstractGridViewWithTextLense
  {
    private NGramHighlightCooccurrencesViewModel _vm;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractView" /> class.
    /// </summary>
    public CooccurrenceMultiwordGrid()
    {
      InitializeComponent();
      radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
      radGridView1.AllowAutoSizeColumns = true;
      InitializeGrid(radGridView1);
    }

    private void Analyse()
    {
      _vm.NGramSize = int.Parse(txt_size.Text);
      if (SelectedLayerDisplaynames != null)
        _vm.LayerDisplayname = SelectedLayerDisplaynames[0];
      if (!_vm.Execute())
        return;
      BindData();
    }

    private void BindData()
    {
      radGridView1.DataSource = _vm.GetDataTable();
      radGridView1.ResetBindings();
      radGridView1.Columns[0].DisableHTMLRendering = false;
      radGridView1.Columns[2].IsVisible = false;
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
      QueryBuilderFunction(Resources.Kookkurrenz + "_" + Resources.Mehrwort);
    }

    private void btn_filterlist_Click(object sender, EventArgs e)
    {
      FilterListFunction(Resources.Query);
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
              row.Cells["Query"].Value.ToString()
                .Split(
                  new[] {" "},
                  StringSplitOptions
                    .RemoveEmptyEntries)
          }));
    }

    private void GridNGramVisualisation_ShowVisualisation(object sender, EventArgs e)
    {
      _vm = GetViewModel<NGramHighlightCooccurrencesViewModel>();
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