#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Terminal.WinForm.Properties;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  [ToolboxItem(true)]
  public class SnapshotButton : RadDropDownButton
  {
    private Project _project;

    public SnapshotButton()
    {
      Size = new Size(53, 30);
      Text = @" ";
      Image = Resources.camera1;
    }

    public Project Project
    {
      get => _project;
      set
      {
        _project = value;
        if (value == null)
          return;
        Items.Clear();

        Items.Add(BuildMenuItem(Project.CurrentSelection));
        Items.Add(new RadMenuSeparatorItem());
        var list = new List<Selection>(Project.Selections);
        list.Remove(Project.CurrentSelection);
        foreach (var selection in list)
          Items.Add(BuildMenuItem(selection));
        /* ToDo
        if (list.Count > 0) Items.Add(new RadMenuSeparatorItem());
        Items.Add(BuildMenuItem(null));
        */
      }
    }

    public Selection Selection { get; private set; }

    private RadMenuItem BuildMenuItem(Selection selection)
    {
      var res = new RadMenuItem(selection == null ? Resources.Snapshot_CreateNew : selection.Displayname)
      {
        Tag = selection
      };
      res.Click += MenuItemClick;
      return res;
    }

    private void MenuItemClick(object sender, EventArgs eventArgs)
    {
      var rmi = sender as RadMenuItem;
      if (rmi == null)
        return;

      if (rmi.Tag == null)
      {
        // ToDo: Schnappschuss erstellen
      }
      else
      {
        var res = rmi.Tag as Selection;
        if (res == null)
          return;
        Selection = res;
      }
    }
  }
}