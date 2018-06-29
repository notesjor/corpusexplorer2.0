using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Model;
using Telerik.WinControls;
using Telerik.WinControls.Layouts;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  public class SnapshotDropdown : RadDropDownList
  {
    private readonly RadTreeView radTreeView1 = new RadTreeView
    {
      Size = new Size(150, 250),
      Location = new Point(0, 0)
    };
    private readonly RadHostItem _hosted;
    private Selection _current;

    public SnapshotDropdown()
    {
      NullText = "Bitte auswählen...";
      _hosted = new RadHostItem(radTreeView1);
      PopupOpened += RadDropDownList1_PopupOpened;      
      radTreeView1.SelectedNodeChanged += RadTreeView1OnSelectedNodeChanged;
    }

    protected override void OnLoad(Size desiredSize)
    {
      base.OnLoad(desiredSize);
      RefreshSelectionTree();
    }

    public void RefreshSelectionTree()
    {
      radTreeView1.Nodes.Clear();

      var root = new RadTreeNode();
      var proj = CorpusExplorerEcosystem.InitializeMinimal();
      _current = proj.CurrentSelection;

      foreach (var selection in proj.Selections)
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
      CloseDropDown();
      ResultSelection = radTreeView1.SelectedNodes[0].Tag as Selection;
      Text = ResultSelection?.Displayname;
    }

    public Selection ResultSelection { get; private set; }

    private void RadDropDownList1_PopupOpened(object sender, EventArgs e)
    {
      if (!(Popup is DropDownPopupForm form))
        return;
      if (form.SizingGripDockLayout.Children.Contains(ListElement))
        form.SizingGripDockLayout.Children.Remove(ListElement);
      if (!form.SizingGripDockLayout.Children.Contains(_hosted))
        form.SizingGripDockLayout.Children.Add(_hosted);
    }
  }
}
