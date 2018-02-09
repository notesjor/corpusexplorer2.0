#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Snapshot
{
  [ToolboxItem(false)]
  public partial class FullCorpusSnapshotControl : AbstractSnapshotControl
  {
    private IEnumerable<KeyValuePair<Guid, string>> _corpora;
    private Guid _guid;

    public FullCorpusSnapshotControl(Selection selection, FilterQueryCorpusComplete query)
      : base(selection)
    {
      InitializeComponent();
      SetComboBoxes();

      _guid = Guid.NewGuid();

      if (query != null)
        LoadQuery(query);
    }

    public override AbstractFilterQuery Query
    {
      get
      {
        var guids =
          from RadCheckedListDataItem item in radCheckedDropDownList1.Items where item.Checked select (Guid) item.Tag;
        return new FilterQueryCorpusComplete {Inverse = false, SelectedCorpora = guids, Guid = _guid};
      }
    }

    private void LoadQuery(FilterQueryCorpusComplete query)
    {
      if ((query.SelectedCorpora == null) ||
          !query.SelectedCorpora.Any())
        return;

      var hs = new HashSet<Guid>(query.SelectedCorpora);

      foreach (var item in radCheckedDropDownList1.Items.OfType<RadCheckedListDataItem>())
        item.Checked = hs.Contains((Guid) item.Tag);

      _guid = query.Guid;
    }

    private void SetComboBoxes()
    {
      _corpora = Selection.CorporaGuidsAndDisplaynames;
      radCheckedDropDownList1.Items.Clear();

      foreach (var c in _corpora)
        radCheckedDropDownList1.Items.Add(new RadCheckedListDataItem(c.Value) {Tag = c.Key});
    }
  }
}