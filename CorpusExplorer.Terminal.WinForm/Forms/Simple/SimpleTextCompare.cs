using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using Telerik.WinControls.UI;
using PositionChangedEventArgs = Telerik.WinControls.UI.Data.PositionChangedEventArgs;

namespace CorpusExplorer.Terminal.WinForm.Forms.Simple
{
  public partial class SimpleTextCompare : AbstractDialog
  {
    private readonly DiffViewModel _diff;
    private readonly bool _init;

    public SimpleTextCompare(DiffViewModel diff, IEnumerable<Guid> docsA, IEnumerable<Guid> docsB)
    {
      _diff = diff;
      InitializeComponent();

      var meta = diff.DocumentGuidsAndDisplaynames.ToDictionary(x => x.Key, x => x.Value);

      var listA = docsA.ToDictionary(d => d, d => meta[d]);
      var listB = docsB.ToDictionary(d => d, d => meta[d]);

      BindDiffList(commandBarDropDownList1, listA, listB);
      BindDiffList(commandBarDropDownList2, listB, listA);

      _init = true;
    }

    private void BindDiffList(
      CommandBarDropDownList combo,
      Dictionary<Guid, string> first,
      Dictionary<Guid, string> second)
    {
      foreach (var x in first)
        combo.Items.Add(new RadListDataItem(x.Value, x.Key));

      combo.Items.Add(new RadListDataItem("----- <<< ! >>> -----"));

      foreach (var x in second)
        combo.Items.Add(new RadListDataItem(x.Value, x.Key));
    }

    private void commandBarDropDownList1_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      RefreshCompare();
    }

    private void commandBarDropDownList2_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      RefreshCompare();
    }

    private void RefreshCompare()
    {
      if (!_init                                      ||
          commandBarDropDownList1.SelectedIndex == -1 ||
          commandBarDropDownList2.SelectedIndex == -1)
        return;

      _diff.DocumentAGuid = (Guid) commandBarDropDownList1.SelectedItem.Value;
      _diff.DocumentBGuid = (Guid) commandBarDropDownList2.SelectedItem.Value;
      if (_diff.DocumentAGuid == Guid.Empty ||
          _diff.DocumentBGuid == Guid.Empty)
        return;

      _diff.Execute();

      webHtml5Visualisation1.MainpageUrl = Configuration.GetDependencyPath("d3Templates/diff.html");
      webHtml5Visualisation1.TemplateVars = new Dictionary<string, string>
      {
        {"#DIFFS", _diff.HtmlOutput}
      };
      webHtml5Visualisation1.GoToMainpage();
    }
  }
}