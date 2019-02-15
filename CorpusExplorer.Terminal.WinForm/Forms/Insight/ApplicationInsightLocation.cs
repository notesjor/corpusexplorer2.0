using System;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;

namespace CorpusExplorer.Terminal.WinForm.Forms.Insight
{
  public partial class ApplicationInsightLocation : AbstractForm
  {
    public ApplicationInsightLocation()
    {
      InitializeComponent();
    }

    private void btn_accepted_Click(object sender, EventArgs e)
    {
      Close();
    }
  }
}