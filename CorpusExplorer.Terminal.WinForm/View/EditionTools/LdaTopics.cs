#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Extern.MachineLearning.ViewModel;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.SelectLayer;
using CorpusExplorer.Terminal.WinForm.Forms.Simple;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.View.AbstractTemplates;
using Telerik.WinControls;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.EditionTools
{
  /// <summary>
  ///   The grid visualisation.
  /// </summary>
  public partial class LdaTopics : AbstractGridViewWithTextLense
  {
    private LdaViewModel _vm;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractView" /> class.
    /// </summary>
    public LdaTopics()
    {
      InitializeComponent();
      radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
      radGridView1.AllowAutoSizeColumns = true;
      InitializeGrid(radGridView1);      
    }

    private void Analyse()
    {
      if(_vm == null)
        _vm = GetViewModel<LdaViewModel>();
      if (!_vm.Execute())
        return;
      BindData();

      UseParentCellForHighlighting = Resources.NGramm;

      AddSummaryRow();
      ApplyFilterDelay();

      btn_showTopics.Visibility = ElementVisibility.Visible;
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
      var guids = radGridView1.SelectedRows.Select(row => Guid.Parse(row.Cells[Resources.GUID].Value.ToString()));

      CreateSelection(new[]{new FilterQueryDocumentGuid
      {
        Inverse = false,
        DocumentGuids = new HashSet<Guid>(guids)
      }});
    }

    private void GridNGramVisualisation_ShowVisualisation(object sender, EventArgs e)
    {
      _vm = GetViewModel<LdaViewModel>();
    }

    private void btn_regex_Click(object sender, EventArgs e)
    {
      RegexFunction();
    }

    private void btn_showTopics_Click(object sender, EventArgs e)
    {
      var form = new SimpleGrid(_vm.GetDataTableTopics(), "LDA-Topics");
      form.ShowDialog();
    }

    private void btn_settings_Click(object sender, EventArgs e)
    {
      var form = new SimpleObject(_vm.Configuration, "LDA-Einstellungen");
      if (form.ShowDialog() == DialogResult.OK)
        _vm.Configuration = form.GetResult(_vm.Configuration);
    }
  }
}