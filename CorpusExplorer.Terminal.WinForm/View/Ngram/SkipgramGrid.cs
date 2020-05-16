#region

using System;
using System.Linq;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.SelectLayer;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.View.AbstractTemplates;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.Ngram
{
  /// <summary>
  ///   The grid visualisation.
  /// </summary>
  public partial class SkipgramGrid : AbstractGridViewWithTextLense
  {
    private NormalizedSkipgramProbabilityViewModel _vm;

    public SkipgramGrid()
    {
      InitializeComponent();
      InitializeGrid(radGridView1);
      SelectedLayerDisplaynames = new[] {"Wort"};
      ShowView += ShowViewCall;
    }

    private void Analyse()
    {
      _vm = GetViewModel<NormalizedSkipgramProbabilityViewModel>();
      if (SelectedLayerDisplaynames != null)
        _vm.LayerDisplayname = SelectedLayerDisplaynames[0];
      if (!_vm.Execute())
        return;

      radGridView1.DataSource = _vm.GetDataTable();
      radGridView1.ResetBindings();
      radGridView1.BestFitColumns(BestFitColumnMode.HeaderCells);
      radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

      AddSummaryRow();
      ApplyFilterDelay();
      AddChildTemplate(
                       x => new FilterQuerySingleLayerAllInOneSentence
                       {
                         Inverse = false,
                         LayerDisplayname = _vm.LayerDisplayname,
                         LayerQueries =
                           new[]
                           {
                             x[$"{_vm.LayerDisplayname} A"].ToString(),
                             x[$"{_vm.LayerDisplayname} B"].ToString()
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
      radGridView1.FilterDescriptors.Clear();

      var composite = new CompositeFilterDescriptor {LogicalOperator = FilterLogicalOperator.Or};

      composite.FilterDescriptors.Add(
                                      new FilterDescriptor
                                      {
                                        PropertyName = $"{_vm.LayerDisplayname} A",
                                        Operator = FilterOperator.IsEqualTo,
                                        Value = txt_query.Text,
                                        IsFilterEditor = true
                                      });
      composite.FilterDescriptors.Add(
                                      new FilterDescriptor
                                      {
                                        PropertyName = $"{_vm.LayerDisplayname} B",
                                        Operator = FilterOperator.IsEqualTo,
                                        Value = txt_query.Text,
                                        IsFilterEditor = true
                                      });

      radGridView1.FilterDescriptors.Add(composite);
    }

    private void btn_snapshot_create_Click(object sender, EventArgs e)
    {
      CreateSelection(
                      radGridView1.SelectedRows.Select(
                                                       row => new FilterQuerySingleLayerAllInOneSentence
                                                       {
                                                         LayerDisplayname = _vm.LayerDisplayname,
                                                         Inverse = false,
                                                         LayerQueries =
                                                           new[]
                                                           {
                                                             row.Cells[$"{_vm.LayerDisplayname} A"].Value.ToString(),
                                                             row.Cells[$"{_vm.LayerDisplayname} B"].Value.ToString()
                                                           }
                                                       }));
    }

    private void ShowViewCall(object sender, EventArgs e)
    {
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