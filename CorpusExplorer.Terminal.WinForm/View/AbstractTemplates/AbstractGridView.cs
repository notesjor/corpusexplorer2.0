using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Sdk.ViewModel.Interfaces;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm;
using CorpusExplorer.Terminal.WinForm.Forms.GridViewFunctions;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using CorpusExplorer.Terminal.WinForm.Properties;
using Telerik.Documents.SpreadsheetStreaming;
using Telerik.WinControls.Data;
using Telerik.WinControls.Export;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;

namespace CorpusExplorer.Terminal.WinForm.View.AbstractTemplates
{
  public partial class AbstractGridView : AbstractView
  {
    protected RadGridView _grid;
    protected GridException _gridException = new GridException("Use InitializeGrid to set the default RadGridView");

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

    private void _grid_FilterChanged(object sender, GridViewCollectionChangedEventArgs e) { AddSummaryRow(); }

    protected void AddSummaryRow()
    {
      if (_grid == null)
        throw _gridException;

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
            new GridViewHashSetSummaryItem {Name = column.Name, Aggregate = GridAggregateFunction.Last});
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
        throw _gridException;

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
      var sfd = new SaveFileDialog
      {
        Filter = "CSV (*.csv)|*.csv|Microsoft Excel (*.xlsx)|*.xlsx|HTML (*.html)|*.html|PDF (*.pdf)|*.pdf",
        CheckPathExists = true
      };

      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      switch (sfd.FilterIndex)
      {
        case 1:
          ExportToStream(sfd.FileName, SpreadDocumentFormat.Csv);
          break;
        case 2:
          ExportToStream(sfd.FileName, SpreadDocumentFormat.Xlsx);
          break;
        case 3:
          new ExportToHTML(_grid).RunExport(sfd.FileName);
          break;
        case 4:
          new ExportToPDF(_grid).RunExport(sfd.FileName);
          break;
      }
    }

    private void ExportToStream(string filename, SpreadDocumentFormat format)
    {
      using (var fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
      {
        using (var workbook = SpreadExporter.CreateWorkbookExporter(format, fs))
        {
          using (var sheet = workbook.CreateWorksheetExporter("CorpusExplorer"))
          {
            foreach (var c in _grid.Columns)
            {
              using (var column = sheet.CreateColumnExporter())
              {
                column.SetHidden(false);
                column.SetWidthInPixels(256);
              }
            }

            foreach (var r in _grid.Rows)
            {
              using (var row = sheet.CreateRowExporter())
              {
                foreach (GridViewCellInfo c in r.Cells)
                {
                  using (var cell = row.CreateCellExporter())
                  {
                    cell.SetValue(c.Value.ToString());
                  }
                }
              }
            }
          }
        }
      }
    }

    protected void FilterListFunction(params string[] properties)
    {
      if (_grid == null)
        throw _gridException;

      var form = new FilterListFunction();
      form.ShowDialog();

      if (form.DialogResult != DialogResult.OK)
        return;

      _grid.SuspendUpdate();
      _grid.FilterDescriptors.Clear();
      var filter = new CompositeFilterDescriptor();
      foreach (var query in form.Result)
        foreach (var p in properties)
          filter.FilterDescriptors.Add(new FilterDescriptor(p, FilterOperator.IsEqualTo, query));

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

    protected void PredefinedFunctions(IProvideDataTable vm, params string[] properties)
    {
      if (_grid == null)
        throw _gridException;

      var func = new PredefinedFunctions(properties, vm.GetDataTable());
      if (func.ShowDialog() != DialogResult.OK)
        return;

      _grid.DataSource = func.Output;

      if (_grid.SummaryRowsTop.Count == 0)
        return;
      if (_grid.SummaryRowsTop[0].All(item => item.Name != func.NewColumnName))
        _grid.SummaryRowsTop[0].Add(
               new GridViewSummaryItem
               {
                 Name = func.NewColumnName,
                 Aggregate = GridAggregateFunction.Sum
               });
    }

    protected void QueryBuilderFunction(string name)
    {
      if (_grid == null)
        throw _gridException;

      var table = _grid.DataSource as DataTable;
      if (table == null)
        throw new GridException("GridQueryBuilder is only available for DataTable-Binding-Contexts");

      var form =
        new GridQueryBuilder(
          table.Columns.Cast<DataColumn>().ToDictionary(column => column.ColumnName, column => column.DataType),
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
  }
}