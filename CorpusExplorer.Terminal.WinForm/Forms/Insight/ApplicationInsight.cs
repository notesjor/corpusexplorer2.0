using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
      InsightController.NeverAskAgain();
      Close();
    }

    private void btn_denied_Click(object sender, EventArgs e)
    {
      InsightController.SetInsightStatus(false);
      InsightController.NeverAskAgain();
      Close();
    }
  }
}
