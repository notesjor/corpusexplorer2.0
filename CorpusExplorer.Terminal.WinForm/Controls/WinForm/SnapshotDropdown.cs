using System;
using System.ComponentModel;
using System.Drawing;
using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Model;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  public class SnapshotDropdown : RadDropDownList
  {
    private readonly RadHostItem _hosted;

    private readonly RadTreeView radTreeView1 = new RadTreeView
    {
      Size = new Size(150, 250),
      Location = new Point(0, 0)
    };

    private Selection _current;

    public SnapshotDropdown()
    {
      NullText = "Bitte auswählen...";
      _hosted = new RadHostItem(radTreeView1);
      PopupOpened += RadDropDownList1_PopupOpened;
      radTreeView1.SelectedNodeChanged += RadTreeView1OnSelectedNodeChanged;
    }

    public Selection ResultSelection { get; private set; }

    protected override void OnLoad(Size desiredSize)
    {
      base.OnLoad(desiredSize);
      RefreshSelectionTree();
    }

    public void RefreshSelectionTree()
    {
      radTreeView1.Nodes.Clear();

      var root = new RadTreeNode();
      _current = CorpusExplorerEcosystem.CurrentProject.CurrentSelection;

      foreach (var selection in CorpusExplorerEcosystem.CurrentProject.Selections)
        BuildTree(selection, root);

      radTreeView1.Nodes.AddRange(root.Nodes);
    }

    private void BuildTree(Selection selection, RadTreeNode root)
    {
      if (selection == null || root == null)
        return;

      if (selection.Guid == _current.Guid)
      {
        if (selection.SubSelections == null)
          return;

        foreach (var sub in selection.SubSelections)
          BuildTree(sub, root);
      }
      else
      {
        var node = root.Nodes.Add(selection.Displayname);
        node.Tag = selection;

        if (selection.SubSelections == null)
          return;

        foreach (var sub in selection.SubSelections)
          BuildTree(sub, node);
      }
    }

    private void RadTreeView1OnSelectedNodeChanged(object sender, RadTreeViewEventArgs e)
    {
      try
      {
        CloseDropDown();
        ResultSelection = radTreeView1.SelectedNodes[0]?.Tag as Selection;
        Text = ResultSelection?.Displayname;
      }
      catch
      {
        // ignore
      }
    }

    private void RadDropDownList1_PopupOpened(object sender, EventArgs e)
    {
      if (!(Popup is DropDownPopupForm form))
        return;
      if (form.SizingGripDockLayout.Children.Contains(ListElement))
        form.SizingGripDockLayout.Children.Remove(ListElement);
      if (!form.SizingGripDockLayout.Children.Contains(_hosted))
        form.SizingGripDockLayout.Children.Add(_hosted);
    }

    private void InitializeComponent()
    {
      ((ISupportInitialize) this).BeginInit();
      SuspendLayout();
      ((ISupportInitialize) this).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }
  }
}