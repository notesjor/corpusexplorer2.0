#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.NamedEntity;
using CorpusExplorer.Terminal.WinForm.Forms.Simple;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.View.AbstractTemplates;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.Special
{
  /// <summary>
  ///   The grid visualisation.
  /// </summary>
  public partial class NamedEntityGrid : AbstractGridView
  {
    private GridViewTemplate _childTemplate;
    private DateTime _preventDoubleCommandClick;
    private NamedEntityDetectionViewModel _vm;

    /// <summary>
    ///   Initializes a new instance
    /// </summary>
    public NamedEntityGrid()
    {
      InitializeComponent();
      InitializeGrid(radGridView1);
      ShowView += ShowViewCall;
    }

    private void Analyse()
    {
      _vm = GetViewModel<NamedEntityDetectionViewModel>();
      if (_vm == null)
        return;

      _vm.Execute();

      radGridView1.DataSource = _vm.GetDataTable();
      radGridView1.ResetBindings();

      AddSummaryRow();
      AddChildTemplate();

      radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
    }

    protected void AddChildTemplate()
    {
      if (_grid == null)
        throw GridException;

      _grid.Templates.Clear();
      _childTemplate = CreateChildTemplate();
      _grid.Templates.Add(_childTemplate);
      _childTemplate.HierarchyDataProvider = new GridViewEventDataProvider(_childTemplate);

      _grid.RowSourceNeeded -= radGridView1_RowSourceNeeded;
      _grid.RowSourceNeeded += radGridView1_RowSourceNeeded;
    }

    private void radGridView1_RowSourceNeeded(object sender, GridViewRowSourceNeededEventArgs e)
    {
      var parent = e.ParentRow.DataBoundItem as DataRowView;
      if (parent == null)
        return;

      var dt = _vm.GetEntityEntriesWithFulltext(parent["Entität"].ToString());

      foreach (var row in dt)
      {
        var r = e.Template.Rows.NewRow();
        r.Cells[Resources.Fundstelle].Value = row.Item3;
        r.Cells["Info"].Value = new KeyValuePair<Guid, int>(row.Item1, row.Item2);
        e.SourceCollection.Add(r);
      }
    }

    private GridViewTemplate CreateChildTemplate()
    {
      if (_grid == null)
        throw GridException;

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

      var txtcontent = new GridViewTextBoxColumn(Resources.Fundstelle)
      {
        AutoSizeMode = BestFitColumnMode.AllCells
      };
      var txtbtn = new GridViewCommandColumn(Resources.Details)
      {
        AllowFiltering = false,
        AllowGroup = false,
        HeaderText = "",
        DefaultText = "",
        UseDefaultText = true,
        MaxWidth = 37,
        Image = Resources.find
      };
      var txtindex = new GridViewTextBoxColumn("Info")
      {
        IsVisible = false,
        DataType = typeof(KeyValuePair<Guid, int>)
      };

      template.Columns.AddRange(
                                txtcontent,
                                new GridViewTextBoxColumn("Rang")
                                {
                                  DataType = typeof(double),
                                  MaxWidth = 85,
                                  TextAlignment = ContentAlignment.MiddleCenter
                                },
                                txtbtn,
                                txtindex);

      template.SortDescriptors.Add(Resources.Frequency, ListSortDirection.Descending);
      _grid.CommandCellClick += OnGridOnCommandCellClick;

      return template;
    }

    private void OnGridOnCommandCellClick(object sender, GridViewCellEventArgs arg)
    {
      if ((DateTime.Now - _preventDoubleCommandClick).Seconds < 1)
        return;

      if (!(sender is GridCommandCellElement cell))
        return;

      var vm = GetViewModel<QuickInfoTextViewModel>();
      vm.Documents = new[] {(KeyValuePair<Guid, int>) cell.RowElement.RowInfo.Cells["Info"].Value};
      vm.Execute();

      var form = new SimpleTextView(vm.QuickDocumentInfoResults, Project);
      form.NewProperty += (o, a) => { vm.SetNewDocumentMetadata((KeyValuePair<string, Type>) o); };

      if (form.ShowDialog() == DialogResult.OK)
        foreach (var doc in form.Documents)
          Project.CurrentSelection.SetDocumentMetadata(doc.DocumentGuid, doc.DocumentMetadata);

      _preventDoubleCommandClick = DateTime.Now;
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
      FilterListFunction("Wort");
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
      var res = new HashSet<Guid>();
      foreach (var row in radGridView1.SelectedRows)
      foreach (var guid in _vm.GetEntityEntries(row.Cells["Entität"].ToString()).Select(x => x.Item1))
        res.Add(guid);

      CreateSelection(res);
    }

    private void ShowViewCall(object sender, EventArgs e)
    {
      Processing.Invoke(Resources.AnalysiereUndStelleRelationenHer, Analyse);
    }

    private void commandBarButton1_Click(object sender, EventArgs e)
    {
      var form = new NamedEntityConfiguration();
      if (form.ShowDialog() != DialogResult.OK)
        return;

      commandBarLabel1.Text = $"Das Model ist: {form.ModelDisplayname}";
      _vm = GetViewModel<NamedEntityDetectionViewModel>();

      Processing.Invoke("Suche nach Entitäten...", () =>
      {
        _vm.Model = form.Model;

        if (!_vm.Execute())
          return;

        radGridView1.DataSource = _vm.GetDataTable();
      });
    }

    private void btn_regex_Click(object sender, EventArgs e)
    {
      RegexFunction();
    }
  }
}