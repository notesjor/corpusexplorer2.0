using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.ViewModel.Abstract
{
  public abstract class AbstractCompareViewModel : AbstractViewModel
  {
    public Dictionary<Selection, string> SelectionsAvailable
    {
      get { return Selection.Project.OtherSelections.ToDictionary(x => x.Key, x => x.Value); }
    }

    public Selection SelectionToCompare { get; set; }

    protected override bool Validate() { return SelectionToCompare != null; }
  }
}