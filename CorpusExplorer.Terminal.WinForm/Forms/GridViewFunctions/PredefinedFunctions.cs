using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using CorpusExplorer.Terminal.WinForm.Helper;
using CorpusExplorer.Terminal.WinForm.Properties;

namespace CorpusExplorer.Terminal.WinForm.Forms.GridViewFunctions
{
  public partial class PredefinedFunctions : AbstractDialog
  {
    private readonly string[] _columnNames;
    private readonly DataTable _table;
    private Dictionary<double, string> _actions;

    public PredefinedFunctions(string[] columnNames, DataTable table)
    {
      _columnNames = columnNames;
      _table = table;
      InitializeComponent();
    }

    public string CalculateColumnName { get; private set; }
    public DataTable Output { get; private set; }

    private void PredefinedFunctions_ButtonOkClick(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(CalculateColumnName))
        CalculateColumnName = _table.Columns[_table.Columns.Count - 1].ColumnName;

      double sum;
      var useInt = false;
      try
      {
        sum = _table.Rows.Cast<DataRow>().Sum(row => (double)row[CalculateColumnName]);
      }
      catch
      {
        sum = _table.Rows.Cast<DataRow>().Sum(row => (int)row[CalculateColumnName]);
        useInt = true;
      }

      var col = CalculateColumnName + " (relativ)";
      var fac = (double)drop_funcs.SelectedValue;
      _table.Columns.Add(col, typeof(double));

      if (useInt)
        foreach (DataRow row in _table.Rows)
          row[col] = (int)row[CalculateColumnName] / sum * fac;
      else
        foreach (DataRow row in _table.Rows)
          row[col] = (double)row[CalculateColumnName] / sum * fac;

      CalculateColumnName = col;
      Output = _table;
    }

    private void PredefinedFunctions_Load(object sender, EventArgs e)
    {
      _actions = new Dictionary<double, string>
      {
        {100d, Resources.RelativeFrequenz100},
        {1000000d, Resources.RelativeFrequenz1Mio}
      };

      DictionaryBindingHelper.BindDictionary(_actions, drop_funcs);
    }
  }
}