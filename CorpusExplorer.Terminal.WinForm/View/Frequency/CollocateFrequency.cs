using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.View.AbstractTemplates;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.View.Frequency
{
  public partial class CollocateFrequency : AbstractGridViewWithTextLense
  {
    private PositionFrequencyViewModel _vm;

    public CollocateFrequency()
    {
      InitializeComponent();
      InitializeGrid(radGridView1);
      ShowView += (s, e) => _vm = GetViewModel<PositionFrequencyViewModel>();
    }

    private void btn_function_Click(object sender, EventArgs e)
    {
      PredefinedFunctions(_vm, "Summe");
    }

    private void btn_calc_Click(object sender, EventArgs e)
    {
      CalculatorFunction();
    }

    private void btn_filterlist_Click(object sender, EventArgs e)
    {
      FilterListFunction(_vm.LayerDisplayname);
    }

    private void btn_filtereditor_Click(object sender, EventArgs e)
    {
      QueryBuilderFunction(_vm.LayerDisplayname);
    }

    private void btn_csvExport_Click(object sender, EventArgs e)
    {
      ExportFunction();
    }

    private void btn_print_Click(object sender, EventArgs e)
    {
      radGridView1.PrintPreview();
    }

    private void wordBag1_ExecuteButtonClicked(object sender, EventArgs e)
    {
      Processing.Invoke(
        "Berechne Kollokationen...",
        () =>
        {
          _vm.LayerDisplayname = wordBag1.ResultSelectedLayerDisplayname;
          _vm.LayerQueries = wordBag1.ResultQueries.ToArray();
          _vm.Execute();

          radGridView1.DataSource = _vm.GetDataTable();
          radGridView1.ResetBindings();
          radGridView1.BestFitColumns(BestFitColumnMode.HeaderCells);
          //radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

          AddSummaryRow();
          AddChildTemplate(
            x => new FilterQuerySingleLayerFirstAndAnyOtherMatch
            {
              Inverse = false,
              LayerDisplayname = wordBag1.ResultSelectedLayerDisplayname,
              LayerQueries = ValueMergeHelper.Merge(x[wordBag1.ResultSelectedLayerDisplayname].ToString(), wordBag1.ResultQueries)
            });
        });
    }

    private void btn_snapshot_new_Click(object sender, EventArgs e)
    {
      var queries = new List<AbstractFilterQuery>();
      foreach (var row in radGridView1.SelectedRows)
      {
        queries.Add(new FilterQuerySingleLayerFirstAndAnyOtherMatch
        {
          LayerDisplayname = wordBag1.ResultSelectedLayerDisplayname,
          Inverse = false,
          LayerQueries = ValueMergeHelper.Merge(row.Cells[wordBag1.ResultSelectedLayerDisplayname].Value.ToString(), wordBag1.ResultQueries)
        });
      }

      CreateSelection(queries);
    }
  }
}
