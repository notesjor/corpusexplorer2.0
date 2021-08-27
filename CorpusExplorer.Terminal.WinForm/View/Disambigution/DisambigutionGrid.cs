#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.View.AbstractTemplates;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.Disambigution
{
  /// <summary>
  ///   The grid visualisation.
  /// </summary>
  public partial class DisambigutionGrid : AbstractGridViewWithTextLense
  {
    private DisambiguationViewModel _vm;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractView" /> class.
    /// </summary>
    public DisambigutionGrid()
    {
      InitializeComponent();
      InitializeGrid(radGridView1);
    }

    private void Analyse()
    {
      _vm = GetViewModel<DisambiguationViewModel>();
      _vm.LayerQuery = wordBag1.ResultQueries.First();
      _vm.LayerDisplayname = wordBag1.ResultSelectedLayerDisplayname;
      _vm.Execute();
      _vm.DataTableLevel = int.Parse(txt_level.Text);

      radGridView1.DataSource = _vm.GetDataTable();
      radGridView1.ResetBindings();
      radGridView1.BestFitColumns(BestFitColumnMode.HeaderCells);
      radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

      AddSummaryRow();
      ApplyFilterDelay();
      AddChildTemplate(
                       delegate(DataRowView x)
                       {
                         var cnt = wordBag1.ResultQueries.Count();
                         if (cnt == 1)
                         {
                           var q = wordBag1.ResultQueries.First();
                           var bag = new List<string> {q};
                           bag.AddRange(x[Resources.Label]
                                       .ToString().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries));

                           return new FilterQuerySingleLayerFirstAndAnyOtherMatch
                           {
                             Inverse = false,
                             LayerDisplayname = _vm.LayerDisplayname,
                             LayerQueries = bag
                           };
                         }

                         if (cnt > 1)
                         {
                           var qs = wordBag1.ResultQueries.ToArray();
                           var bag = new List<string> {qs[0]};
                           var other = x[Resources.Label]
                                      .ToString()
                                      .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries);
                           bag.AddRange(other);

                           var or = new List<AbstractFilterQuery>();
                           for (var i = 1; i < qs.Length; i++)
                           {
                             bag = new List<string> {qs[1]};
                             bag.AddRange(other);

                             or.Add(new FilterQuerySingleLayerFirstAndAnyOtherMatch
                             {
                               Inverse = false,
                               LayerDisplayname = _vm.LayerDisplayname,
                               LayerQueries = bag.ToArray()
                             });
                           }

                           return new FilterQuerySingleLayerFirstAndAnyOtherMatch
                           {
                             Inverse = false,
                             LayerDisplayname = _vm.LayerDisplayname,
                             LayerQueries = bag.ToArray(),
                             OrFilterQueries = or
                           };
                         }

                         return null;
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
      QueryBuilderFunction(Resources.Disambiguierung);
    }

    private void btn_filterlist_Click(object sender, EventArgs e)
    {
      FilterListFunction(Resources.Label);
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
      PredefinedFunctions(_vm, Resources.Wert);
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

    private void wordBag1_ExecuteButtonClicked(object sender, EventArgs e)
    {
      Processing.Invoke(Resources.ZählungLäuft, Analyse);
    }

    private void btn_regex_Click(object sender, EventArgs e)
    {
      RegexFunction();
    }
  }
}