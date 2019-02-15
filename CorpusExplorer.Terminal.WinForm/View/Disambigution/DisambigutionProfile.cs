using CorpusExplorer.Terminal.WinForm.Properties;

#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CorpusExplorer.Sdk.ViewModel;
using CorpusExplorer.Terminal.WinForm.Forms.Splash;
using CorpusExplorer.Terminal.WinForm.Helper.UiFramework;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.View.Disambigution
{
  public partial class DisambigutionProfile : AbstractView
  {
    private readonly Color[] _colors =
    {
      Color.FromArgb(0, 102, 255),
      Color.FromArgb(0, 238, 204),
      Color.FromArgb(85, 255, 0),
      Color.FromArgb(255, 204, 0),
      Color.FromArgb(255, 104, 0),
      Color.FromArgb(255, 0, 0)
    };

    private readonly RadListView[] _lists;

    public DisambigutionProfile()
    {
      InitializeComponent();

      _lists = new[]
      {
        list_00,
        list_01,
        list_10,
        list_20,
        list_11,
        list_02,
        list_03,
        list_12,
        list_21,
        list_30,
        list_31,
        list_22,
        list_13,
        list_23,
        list_32,
        list_33
      };
    }

    private void Analyse()
    {
      var vm = GetViewModel<DisambiguationViewModel>();
      vm.LayerDisplayname = wordBag1.ResultSelectedLayerDisplayname;
      vm.LayerQuery = wordBag1.ResultQueries.First();
      vm.Execute();

      for (var i = 0; i < 16; i++)
        SetListView(_lists[i]);

      var cluster = vm.GetClusterLevel(4);

      if (cluster == null)
        return;

      var max = _lists.Length > cluster.Length ? cluster.Length : _lists.Length;

      for (var i = 0; i < max; i++)
        SetListView(_lists[i], cluster[i].LabelItems);

      SetListView(list_33, vm.RootClusterLabels);
    }

    private void list_CheckedChanged(object sender, ListViewItemEventArgs e)
    {
      var hashset = new HashSet<string>();

      foreach (
        var item in from list in _lists from item in list.Items where item.CheckState == ToggleState.On select item)
        hashset.Add(item.Text);

      var sortList = new List<KeyValuePair<RadListView, int>>();

      // Listen zurücksetzen und gleichzeit zählen für sortList
      foreach (var list in _lists)
      {
        foreach (var item in list.Items)
          item.BackColor = Color.White;

        sortList.Add(new KeyValuePair<RadListView, int>(list, list.Items.Count(item => hashset.Contains(item.Text))));
      }

      var sortedList = sortList.OrderBy(x => x.Value).ToArray();
      var cindex = 0; // Farbindex

      for (var i = 0; i < sortedList.Length; i++)
      {
        if (i     > 0 &&
            i % 3 == 0)
          cindex++;

        foreach (var item in sortedList[i].Key.Items)
          item.BackColor = _colors[cindex];
      }
    }

    private void SetListView(RadListView list, IEnumerable<string> items = null)
    {
      list.Items.Clear();
      if (items == null)
        return;

      foreach (var label in items)
        list.Items.Add(new ListViewDataItem(label));
    }

    private void wordBag1_ExecuteButtonClicked(object sender, EventArgs e)
    {
      Processing.Invoke(Resources.DisambiguierungLäuft, Analyse);
    }
  }
}