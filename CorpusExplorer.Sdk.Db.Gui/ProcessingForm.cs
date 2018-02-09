using System;

namespace CorpusExplorer.Sdk.Db.Gui
{
  public partial class ProcessingForm : AbstractForm
  {
    public ProcessingForm()
    {
      InitializeComponent();
      Load += (sender, args) =>
      {
        radWaitingBar1.StartWaiting();
        timer1.Start();
      };
    }

    public string Message { set { radLabel1.Text = value ?? "Kommuniziere mit Datenbank"; } }

    private void timer1_Tick(object sender, EventArgs e)
    {
      Message = Processing.Message;
      if (!Processing.Show)
        Close();
    }
  }
}