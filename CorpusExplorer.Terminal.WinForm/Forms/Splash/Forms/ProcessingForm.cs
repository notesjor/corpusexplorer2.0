using System;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using CorpusExplorer.Terminal.WinForm.Properties;

namespace CorpusExplorer.Terminal.WinForm.Forms.Splash.Forms
{
  public partial class ProcessingForm : AbstractForm
  {
    public ProcessingForm()
      : base(null)
    {
      InitializeComponent();
      Load += (sender, args) =>
      {
        radWaitingBar1.StartWaiting();
        timer1.Start();
      };
    }

    public string Message { set { radLabel1.Text = value ?? Resources.GutDingWillWeileHaben; } }

    private void timer1_Tick(object sender, EventArgs e)
    {
      Message = Processing.Message;
      if (!Processing.Show)
        Close();
    }
  }
}