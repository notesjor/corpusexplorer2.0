using System.Collections.Generic;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  public class GridViewHashSetSummaryItem : GridViewSummaryItem
  {
    private readonly HashSet<string> _hashSet;

    public GridViewHashSetSummaryItem() { _hashSet = new HashSet<string>(); }

    public override object Evaluate(IHierarchicalRow row)
    {
      var template = row as MasterGridViewTemplate;
      if (template == null)
        return 0;

      foreach (var x in template.ChildRows)
        _hashSet.Add(x.Cells[Name].Value.ToString());

      return _hashSet.Count;
    }
  }
}