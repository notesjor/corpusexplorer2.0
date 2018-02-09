#region

using System;
using System.Data;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper;
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
  public partial class CompareNGram : AbstractGridView
  {
    private DataTable _table;
    private NgramCompareViewModel _vm;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractView" /> class.
    /// </summary>
    public CompareNGram()
    {
      InitializeComponent();
      InitializeGrid(radGridView1);
      radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
      radGridView1.AllowAutoSizeColumns = true;
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
      QueryBuilderFunction(Resources.NGramm + "_" + Resources.Vergleich);
    }

    private void btn_filterlist_Click(object sender, EventArgs e) { FilterListFunction(Resources.NGram); }

    private void btn_go_Click(object sender, EventArgs e)
    {
      if (!(drop_snapshot2.SelectedValue is Selection))
        return;

      Processing.Invoke(
        Resources.VergleicheSchnappschüsse,
        () =>
        {
          _vm.Selection = Project.CurrentSelection;
          _vm.SelectionToCompare = (Selection) drop_snapshot2.SelectedValue;
          _vm.NGramSize = int.Parse(txt_size.Text);
          _vm.NGramPatternSize = int.Parse(txt_patternSize.Text);
          _vm.LayerDisplayname = combo_layer.SelectedItem.Text;
          _vm.Analyse();

          _table = _vm.GetDataTable();

          radGridView1.DataSource = _table;
          radGridView1.ResetBindings();
          radGridView1.BestFitColumns(BestFitColumnMode.HeaderCells);
          radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
        });
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

    private void GridNGramVisualisation_ShowVisualisation(object sender, EventArgs e)
    {
      _vm = ViewModelGet<NgramCompareViewModel>();
      combo_layer.DataSource = _vm.LayerDisplaynames;
      DictionaryBindingHelper.BindDictionary(_vm.SelectionsAvailable, drop_snapshot2);
    }
  }
}