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
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.View.AbstractTemplates;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.Frequency
{
  /// <summary>
  ///   The grid visualisation.
  /// </summary>
  public partial class FrequencyGrid : AbstractGridViewWithTextLense
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

    private void Analyse(string[] layerDisplaynames = null)
    {
      _vm = GetViewModel<FrequencyViewModel>();
      if (_vm == null)
        return;
      if (layerDisplaynames != null)
        _vm.Mapper.MappedLayerDisplaynames = layerDisplaynames;

      _vm.Execute();

      radGridView1.DataSource = _vm.GetDataTable();
      radGridView1.ResetBindings();

      AddSummaryRow();
      ApplyFilterDelay();
      AddChildTemplate(SetFilter);

      radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
    }

    private AbstractFilterQuery SetFilter(DataRowView row)
    {
      try
      {
        switch (_vm.Mapper.MappedLayerDisplaynames.Count(x => !string.IsNullOrEmpty(x)))
        {
          case 1:
            return new FilterQuerySingleLayerAnyMatch
            {
              Inverse = false,
              LayerDisplayname = _vm.Layer1Displayname,
              LayerQueries = new[] { row[_vm.Layer1Displayname].ToString() }
            };
          case 2:
            return new FilterQueryMultiLayerAll
            {
              Inverse = false,
              MultilayerValues = new Dictionary<string, string>
            {
              { _vm.Layer1Displayname, row[_vm.Layer1Displayname].ToString() },
              { _vm.Layer2Displayname, row[_vm.Layer2Displayname].ToString() }
            }
            };
          case 3:
            return new FilterQueryMultiLayerAll
            {
              Inverse = false,
              MultilayerValues = new Dictionary<string, string>
            {
              { _vm.Layer1Displayname, row[_vm.Layer1Displayname].ToString() },
              { _vm.Layer2Displayname, row[_vm.Layer2Displayname].ToString() },
              { _vm.Layer3Displayname, row[_vm.Layer3Displayname].ToString() }
            }
            };
          default:
            return new FilterQuerySingleLayerAnyMatch
            {
              Inverse = false,
              LayerDisplayname = _vm.Mapper.MappedLayerDisplaynames.Last(),
              LayerQueries = new[] { row[_vm.Mapper.MappedLayerDisplaynames.Last()].ToString() }
            };
        }
      }
      catch
      {
        return new FilterQuerySingleLayerAnyMatch
        {
          Inverse = false,
          LayerDisplayname = _vm.Mapper.MappedLayerDisplaynames.Last(),
          LayerQueries = new[] { row[_vm.Mapper.MappedLayerDisplaynames.Last()].ToString() }
        };
      }
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

    private void btn_filter_Click(object sender, EventArgs e)
    {
      FilterListFunction(_vm.Mapper.MappedLayerDisplaynames.ToArray());
    }

    private void btn_filterEditor_Click(object sender, EventArgs e)
    {
      QueryBuilderFunction(Resources.Frequency);
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

    private void btn_layers_Click(object sender, EventArgs e)
    {
      var form = new Select3Layer(_vm.Mapper.MappedLayerDisplaynames);
      form.ShowDialog();
      Analyse(form.ResultSelectedLayerDisplaynames);
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
      var map = _vm.Mapper.MappedLayerDisplaynames.ToArray();

      CreateSelection(
                      radGridView1.SelectedRows.Select(
                                                       row => new FilterQueryMultiLayerAny
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
      Processing.Invoke(Resources.AnalysiereUndStelleRelationenHer, () => Analyse());
    }

    private void btn_regex_Click(object sender, EventArgs e)
    {
      RegexFunction();
    }
  }
}