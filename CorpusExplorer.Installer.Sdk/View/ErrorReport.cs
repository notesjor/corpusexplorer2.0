using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Diagnostic;

namespace CorpusExplorer.Installer.Sdk.View
{
  public partial class ErrorReport : Form
  {
    public ErrorReport() { InitializeComponent(); }

    private void btn_abort_Click(object sender, EventArgs e) { Close(); }

    private void button1_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog {CheckPathExists = true, Filter = "LOG (*.log)|*.log"};
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      InMemoryErrorConsole.Save(sfd.FileName);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      File.Delete(
        Path.Combine(
          Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"CorpusExplorer\App"),
          "update.info"));
    }

    private void ErrorReport_Load(object sender, EventArgs e)
    {
      foreach (var err in InMemoryErrorConsole.Errors)
      {
        var master = treeView1.Nodes.Add($"{err.Key.ToString("yyyy-MM-dd HH:mm:ss")} - {err.Value.Message}");
        master.Nodes.Add(err.Value.StackTrace);
      }
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start("mailto:support@corpusexplorer.de");
    }
  }
}