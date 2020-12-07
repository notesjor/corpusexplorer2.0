using System;
using System.Windows.Forms;
using CorpusExplorer.Terminal.Automate.Properties;

namespace CorpusExplorer.Terminal.Automate
{
  public partial class ClusterAssistant : AbstractForm
  {
    public ClusterAssistant()
    {
      AutoMax = false;
      InitializeComponent();
    }

    public string Result => autoSplit1.Result;

    private void btn_ok_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(Resources.DialogChangesAcceptedMessage, Resources.DialogChangesAcceptedMessageHead, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      DialogResult = DialogResult.OK;
      Close();
    }

    private void btn_abort_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(Resources.DialogChangesAbortMessage, Resources.DialogChangesAbortMessageHead, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      DialogResult = DialogResult.Abort;
      Close();
    }
  }
}
