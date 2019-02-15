#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using CorpusExplorer.Terminal.WinForm.Properties;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Forms.Error
{
  public partial class ErrorConsole : AbstractDialog
  {
    public ErrorConsole()
    {
      InitializeComponent();
      DisplayAbort = false;
      Load += OnLoad;
      radTreeView1.NodeMouseClick += radTreeView1_NodeMouseClick;
    }

    private void btn_clear_Click(object sender, EventArgs e)
    {
      if (
        MessageBox.Show(
                        "Möchten Sie den Fehlerspeicher wirklich löschen?",
                        "Fehlerspeicher löschen?",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No)
        return;

      InMemoryErrorConsole.Clear();
      Close();
    }

    private void btn_save_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog {CheckPathExists = true, Filter = Resources.FileExtension_LOG};
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      InMemoryErrorConsole.Save(sfd.FileName);
    }

    private void OnLoad(object sender, EventArgs eventArgs)
    {
      var errors = InMemoryErrorConsole.Errors.ToArray();

      var res = new List<RadTreeNode>();

      foreach (var error in errors)
      {
        var date = new RadTreeNode(error.Key.ToString("s"));
        var message = new RadTreeNode(error.Value.Message);
        var stack = new RadTreeNode(error.Value.StackTrace) {Tag = error.Value.StackTrace};

        message.Nodes.Add(stack);
        date.Nodes.Add(message);
        res.Add(date);
      }

      radTreeView1.Nodes.AddRange(res);
      radTreeView1.ExpandAll();
    }

    private void radTreeView1_NodeMouseClick(object sender, RadTreeViewEventArgs e)
    {
      if (string.IsNullOrEmpty(e.Node?.Tag?.ToString()))
        return;
      MessageBox.Show(e.Node.Tag.ToString());
    }
  }
}