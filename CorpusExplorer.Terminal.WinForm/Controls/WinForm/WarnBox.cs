using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Abstract;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  [ToolboxItem(true)]
  public partial class WarnBox : AbstractUserControl
  {
    public WarnBox()
    {
      InitializeComponent();
    }

    public void Display(string message)
    {
      if (string.IsNullOrWhiteSpace(message))
        Visible = false;
      else
      {
        error_lbl_message.Text = message;
        Visible = true;
      }
    }
  }
}
