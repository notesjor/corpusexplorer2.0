using System.Collections.Generic;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  public class GridViewHashSetSummaryItem : GridViewSummaryItem
  {
    private readonly HashSet<string> _hashSet;

    public GridViewHashSetSummaryItem()
    {
      _hashSet = new HashSet<string>();
    }

    public override object Evaluate(IHierarchicalRow row)
    {
      try
      {
        var template = row as MasterGridViewTemplate;
        if (template == null)
          return 0;

        foreach (var x in template.ChildRows)
          if (x.Cells[Name].Value != null)
            _hashSet.Add(x.Cells[Name].Value.ToString());

        return _hashSet.Count;
      }
      catch
      {
        return 0;
      }
    }
  }
}