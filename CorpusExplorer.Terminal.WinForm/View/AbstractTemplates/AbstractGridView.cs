using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm;
using CorpusExplorer.Terminal.WinForm.Forms.GridViewFunctions;
using CorpusExplorer.Terminal.WinForm.Forms.RegEx;
using CorpusExplorer.Terminal.WinForm.Forms.SelectLayer;
using CorpusExplorer.Terminal.WinForm.Helper;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.View.AbstractTemplates
{
  public partial class AbstractGridView : AbstractView
  {
    protected readonly GridException GridException =
      new GridException("Use InitializeGrid to set the default RadGridView");

    private int _delay = 500;
    private DataTable _backup;
    protected RadGridView _grid;

    public AbstractGridView()
    {
      InitializeComponent();
      CloseView += (x, e) =>
      {
        if (_grid != null)
        {
          _grid.DataSource = null;
          _grid.ResetBindings();
        }
      };
    }

    protected void ApplyFilterDelay()
    {
      foreach (var column in _grid.Columns)
        column.AutoFilterDelay = _delay;
    }

    protected void AddSummaryRow()
    {
      if (_grid == null)
        throw GridException;

      _grid.SuspendLayout();
      _grid.SuspendUpdate();

      if (_grid.SummaryRowsTop.Count > 0)
      {
        _grid.SummaryRowsTop.Clear();
        _grid.SummaryRowsBottom.Clear();
      }

      var summaryRowItem = new GridViewSummaryRowItem();

      foreach (var column in _grid.Columns)
        if (column.DataType == typeof(string))
          summaryRowItem.Add(
                             new GridViewHashSetSummaryItem
                             { Name = column.Name, Aggregate = GridAggregateFunction.Last });
        else
          summaryRowItem.Add(
                             new GridViewSummaryItem
                             {
                               Name = column.Name,
                               Aggregate = GridAggregateFunction.Sum
                             });

      _grid.SummaryRowsTop.Add(summaryRowItem);
      _grid.SummaryRowsBottom.Add(summaryRowItem);

      _grid.ResumeUpdate();
      _grid.ResumeLayout();
    }

    protected void CalculatorFunction()
    {
      if (_grid == null)
        throw GridException;

      if (!_grid.Columns.Contains(Resources.Result))
        _grid.Columns.Add(
                          new GridViewTextBoxColumn
                          {
                            Name = Resources.Result,
                            HeaderText = Resources.Result,
                            Width = 150,
                            EnableExpressionEditor = true
                          });

      RadExpressionEditorForm.Show(_grid, _grid.Columns[Resources.Result]);
    }

    protected void ExportFunction()
    {
      DataTableExporter.Export(_grid);
    }

    protected void FilterListFunction(params string[] properties)
    {
      if (_grid == null)
        throw GridException;

      var form = new FilterListFunction();
      form.ShowDialog();

      if (form.DialogResult != DialogResult.OK)
        return;

      _grid.SuspendUpdate();
      _grid.FilterDescriptors.Clear();
      var filter = new CompositeFilterDescriptor();
      foreach (var query in form.Result)
        foreach (var p in properties)
          filter.FilterDescriptors.Add(new FilterDescriptor(p, form.ResultFilterOperator, query));

      filter.LogicalOperator = FilterLogicalOperator.Or;
      filter.NotOperator = !form.ResultSelectAll;
      _grid.FilterDescriptors.Add(filter);
      _grid.ResumeUpdate();
    }

    protected void InitializeGrid(RadGridView grid)
    {
      _grid = grid;
      _grid.ShowRowHeaderColumn = false;
      _grid.FilterChanged -= _grid_FilterChanged;
      _grid.FilterChanged += _grid_FilterChanged;
    }

    protected void RegexFunction()
    {
      var dt = _grid.DataSource as DataTable ?? _backup;
      var names = new List<string>();
      foreach (DataColumn c in dt.Columns)
        names.Add(c.ColumnName);

      var form = new RegExForm(names.ToArray());
      var res = form.ShowDialog();

      _grid.DataSource = null;
      if (res == DialogResult.OK)
      {
        var tmp = _grid.DataSource as DataTable;
        if (tmp != null)
          _backup = tmp;
        _grid.DataSource = dt.RegexFilter(form.SelectColumn, form.RegularExpression);
      }
      else
        _grid.DataSource = _backup;
    }

    protected void PredefinedFunctions(IProvideDataTable vm, params string[] properties)
    {
      if (_grid == null)
        throw GridException;

      var func = new PredefinedFunctions(properties, vm.GetDataTable());
      if (func.ShowDialog() != DialogResult.OK)
        return;

      _grid.DataSource = func.Output;

      if (_grid.SummaryRowsTop.Count == 0)
        return;
      if (_grid.SummaryRowsTop[0].All(item => item.Name != func.CalculateColumnName))
        _grid.SummaryRowsTop[0].Add(
                                    new GridViewSummaryItem
                                    {
                                      Name = func.CalculateColumnName,
                                      Aggregate = GridAggregateFunction.Sum
                                    });
    }

    protected void QueryBuilderFunction(string name)
    {
      if (_grid == null)
        throw GridException;

      var table = _grid.DataSource as DataTable;
      if (table == null)
        throw new GridException("GridQueryBuilder is only available for DataTable-Binding-Contexts");

      var form =
        new GridQueryBuilder(
                             table.Columns.Cast<DataColumn>()
                                  .ToDictionary(column => column.ColumnName, column => column.DataType),
                             _grid.FilterDescriptors,
                             name);
      if (form.ShowDialog() != DialogResult.OK)
        return;

      _grid.SuspendUpdate();
      _grid.FilterDescriptors.Clear();
      foreach (var filter in form.Result)
        _grid.FilterDescriptors.Add(filter);
      _grid.ResumeUpdate();
    }

    private void _grid_FilterChanged(object sender, GridViewCollectionChangedEventArgs e)
    {
      AddSummaryRow();
    }
  }
}