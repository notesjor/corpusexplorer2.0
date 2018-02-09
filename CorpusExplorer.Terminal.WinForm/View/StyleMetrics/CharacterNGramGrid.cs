#region

using System;
using CorpusExplorer.Sdk.ViewModel;
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
  public partial class CharacterNGramGrid : AbstractGridView
  {
    private NgramPhoneticViewModel _vm;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractView" /> class.
    /// </summary>
    public CharacterNGramGrid()
    {
      InitializeComponent();
      radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
      radGridView1.AllowAutoSizeColumns = true;
      InitializeGrid(radGridView1);
    }

    private void Analyse()
    {
      _vm = ViewModelGet<NgramPhoneticViewModel>();
      _vm.NGramSize = int.Parse(txt_size.Text);
      _vm.Analyse();
      BindData();

      AddSummaryRow();
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

    private void btn_filtereditor_Click(object sender, EventArgs e) { QueryBuilderFunction(Resources.NgramCharakter); }

    private void btn_filterlist_Click(object sender, EventArgs e) { FilterListFunction(Resources.NGram); }

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

    private void GridNGramVisualisation_ShowVisualisation(object sender, EventArgs e) { }
  }
}