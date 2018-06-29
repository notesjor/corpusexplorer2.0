using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.Forms.PosFilter
{
  public partial class PosFilter : AbstractDialog
  {
    private readonly PosTagFilterViewModel _vm;

    public PosFilter(Selection selection)
    {
      InitializeComponent();

      _vm = new PosTagFilterViewModel {Selection = selection};
      _vm.Analyse();

      radCheckedListBox1.SuspendLayout();
      foreach (var x in _vm.AvailableTags.OrderBy(y => y))
        radCheckedListBox1.Items.Add(new ListViewDataItem(x) {Tag = x});
      radCheckedListBox1.ResumeLayout();

      ButtonOkClick += PosFilter_ButtonOkClick;
    }

    public HashSet<string> Result { get; private set; }

    private void PosFilter_ButtonOkClick(object sender, EventArgs e)
    {
      var list = new List<string>();
      foreach (var x in radCheckedListBox1.Items)
        if (x.CheckState == ToggleState.On)
          list.Add((string) x.Tag);

      if (list.Count == 0 || list.Count == radCheckedListBox1.Items.Count)
        Result = null;

      Result = _vm.GetValidCases(list);
    }
  }
}