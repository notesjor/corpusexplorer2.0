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

    public string NewColumnName { get; private set; }
    public DataTable Output { get; private set; }

    private void PredefinedFunctions_ButtonOkClick(object sender, EventArgs e)
    {
      foreach (var columnName in _columnNames)
      {
        var sum = _table.Rows.Cast<DataRow>().Sum(row => (double) row[columnName]);
        var fac = (double) drop_funcs.SelectedValue;

        var res = columnName + " (relativ)";
        _table.Columns.Add(res, typeof(double));

        foreach (DataRow row in _table.Rows)
          row[res] = (double) row[columnName] / sum * fac;

        NewColumnName = res;
        Output = _table;
      }
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