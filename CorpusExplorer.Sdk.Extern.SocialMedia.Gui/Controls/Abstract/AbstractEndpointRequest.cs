using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CorpusExplorer.Sdk.Extern.SocialMedia.Abstract;
using CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Controls.Delegates;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Controls.Abstract
{
  public partial class AbstractEndpointRequest : AbstractUserControl
  {
    public AbstractEndpointRequest()
    {
      InitializeComponent();
      InitialGuiState();
    }

    public AbstractAuthentication Authentication { get; set; }

    private void btn_start_Click(object sender, EventArgs e)
    {
      backgroundWorker.RunWorkerAsync();

      btn_abort.Visible = progress.Visible = true;
      btn_start.Visible = false;
    }

    private void btn_abort_Click(object sender, EventArgs e)
    {
      backgroundWorker.CancelAsync();
      InitialGuiState();
    }

    private void InitialGuiState()
    {
      btn_abort.Visible = progress.Visible = false;
      btn_start.Visible = true;
    }

    public void PostStatusUpdate(string message, int current, int total)
    {
      if (progress.InvokeRequired)
      {
        MethodInvoker mi = delegate { PostStatusUpdate(message, current, total); };
        progress.Invoke(mi);
      }
      else
      {
        progress.SuspendLayout();
        progress.SuspendUpdate();
        progress.Value1 = 0;
        progress.Maximum = total;
        progress.Value1 = current > total ? total : current;
        progress.Text = message;
        progress.ResumeUpdate();
        progress.ResumeLayout();
      }
    }

    private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      InitialGuiState();
    }

    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      ExecuteBackgroundWorker();
    }

    protected virtual void ExecuteBackgroundWorker()
    {
      OnExecute(null);
    }

    protected void OnExecute(Dictionary<string, object> parameters)
    {
      Execute?.Invoke(Authentication, parameters);
    }

    public event CallEndpointDelegate Execute;
  }
}