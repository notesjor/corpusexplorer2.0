#region

using System;
using System.Data;
using System.Drawing;
using System.Linq;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.View.AbstractTemplates;
using Telerik.WinControls.UI;
using PositionChangedEventArgs = Telerik.WinControls.UI.Data.PositionChangedEventArgs;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.Ngram
{
  /// <summary>
  ///   The grid visualisation.
  /// </summary>
  public partial class PhrasesGrid : AbstractGridViewWithTextLense
  {
    private GridViewTemplate _childTemplate;
    private Phrases2ViewModel _vm;

    /// <summary>
    ///   Initializes a new instance
    /// </summary>
    public PhrasesGrid()
    {
      InitializeComponent();
      InitializeGrid(radGridView1);
      ShowView += ShowViewCall;
    }

    private void Analyse()
    {
      //_vm = GetViewModel<Phrases2ViewModel>(false);
      if (drop_group.SelectedIndex != -1)
        _vm.Layer1Displayname = drop_group.SelectedValue.ToString();
      if (drop_values.SelectedIndex != -1)
        _vm.Layer2Displayname = drop_values.SelectedValue.ToString();
      _vm.Execute();

      radGridView1.DataSource = _vm.GetDataTable();
      radGridView1.ResetBindings();
      radGridView1.BestFitColumns(BestFitColumnMode.HeaderCells);

      radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

      AddSummaryRow();
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
      QueryBuilderFunction(Resources.Phrasen);
    }

    private void btn_filterlist_Click(object sender, EventArgs e)
    {
      FilterListFunction(Resources.Group, Resources.Pattern);
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
            LayerDisplayname = _vm.Layer2Displayname,
            LayerQueries =
              row.Cells[Resources.Muster].Value.ToString()
                .Split(
                  new[] {" "},
                  StringSplitOptions
                    .RemoveEmptyEntries)
          }));
    }

    private GridViewTemplate CreateChildTemplate()
    {
      var template = new GridViewTemplate
      {
        AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill,
        AllowAddNewRow = false,
        AllowDeleteRow = false,
        AllowEditRow = false,
        EnableGrouping = true,
        EnableFiltering = true
        //EnableSorting = true, HorizontalScrollState = ScrollState.AlwaysShow
      };

      var txtpre = new GridViewTextBoxColumn(Resources.Pre) {TextAlignment = ContentAlignment.MiddleRight};
      var txtcontent = new GridViewTextBoxColumn(Resources.Match) {TextAlignment = ContentAlignment.MiddleCenter};
      var txtpost = new GridViewTextBoxColumn(Resources.Post) {TextAlignment = ContentAlignment.MiddleLeft};
      var txtcount = new GridViewTextBoxColumn(Resources.Frequency) {TextAlignment = ContentAlignment.MiddleCenter};

      template.Columns.AddRange(txtpre, txtcontent, txtpost, txtcount);

      return template;
    }

    private void drop_group_Click(object sender, EventArgs e)
    {
    }

    private void drop_group_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      if (drop_group.SelectedIndex != -1)
        Processing.Invoke(Resources.ZählungLäuft, Analyse);
    }

    private void drop_values_Click(object sender, EventArgs e)
    {
    }

    private void drop_values_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      if (drop_values.SelectedIndex != -1)
        Processing.Invoke(Resources.ZählungLäuft, Analyse);
    }

    private void radGridView1_RowSourceNeeded(object sender, GridViewRowSourceNeededEventArgs e)
    {
      var parent = e.ParentRow.DataBoundItem as DataRowView;
      if (parent == null)
        return;

      var vm = new TextLiveSearchViewModel {Selection = Project.CurrentSelection};
      vm.AddQuery(
        new FilterQuerySingleLayerExactPhrase
        {
          Inverse = false,
          LayerDisplayname = drop_values.SelectedValue.ToString(),
          LayerQueries =
            parent[Resources.Muster].ToString().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
        });
      vm.Execute();

      var dt = vm.GetUniqueData();
      foreach (var row in dt)
      {
        var r = e.Template.Rows.NewRow();
        r.Cells[Resources.Pre].Value = row.Pre;
        r.Cells[Resources.Match].Value = row.Match;
        r.Cells[Resources.Post].Value = row.Post;
        e.SourceCollection.Add(r);
      }
    }

    private void ShowViewCall(object sender, EventArgs e)
    {
      _vm = GetViewModel<Phrases2ViewModel>();
      drop_group.DataSource = _vm.Layer;
      drop_values.DataSource = _vm.Layer;

      drop_group.SelectedItem = (from x in drop_group.Items where x.Text == "Phrase" select x).FirstOrDefault();
      drop_values.SelectedItem = (from x in drop_group.Items where x.Text == "Wort" select x).FirstOrDefault();

      radGridView1.Templates.Clear();
      _childTemplate = CreateChildTemplate();
      radGridView1.Templates.Add(_childTemplate);
      _childTemplate.HierarchyDataProvider = new GridViewEventDataProvider(_childTemplate);

      radGridView1.RowSourceNeeded -= radGridView1_RowSourceNeeded;
      radGridView1.RowSourceNeeded += radGridView1_RowSourceNeeded;
    }
  }
}