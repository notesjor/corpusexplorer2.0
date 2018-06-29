using System;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;

namespace CorpusExplorer.Terminal.WinForm.Forms.Insight
{
  public partial class ApplicationInsight : AbstractForm
  {
    public ApplicationInsight()
    {
      InitializeComponent();
    }

    private void btn_accepted_Click(object sender, EventArgs e)
    {
      InsightController.SetInsightStatus(true);
      Close();
    }

    private void btn_denied_Click(object sender, EventArgs e)
    {
      InsightController.SetInsightStatus(false);
      Close();
    }
  }
}