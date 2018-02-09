#region

using System;
using System.Windows.Forms;
using CorpusExplorer.Installer.Sdk.Properties;

#endregion

namespace CorpusExplorer.Installer.Sdk.View
{
  internal sealed partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
      DialogResult = DialogResult.None;
    }

    private static DialogResult AskAbortInstallation()
    {
      return MessageBox.Show(
               Resources.MainForm_AskAbortInstallation,
               Resources.MainForm_AskAbortInstallationHeader,
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes
               ? DialogResult.Abort
               : DialogResult.None;
    }

    private void btn_abort_Click(object sender, EventArgs e)
    {
      DialogResult = AskAbortInstallation();
      if (DialogResult == DialogResult.None)
        return;
      Close();
    }

    private void btn_install_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      Close();
    }

    private void chk_accept_CheckedChanged(object sender, EventArgs e) { btn_install.Enabled = chk_accept.Checked; }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (DialogResult != DialogResult.None)
        return;

      DialogResult = AskAbortInstallation();
      if (DialogResult == DialogResult.None)
        e.Cancel = true;
    }
  }
}