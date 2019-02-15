#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Abstract;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  [ToolboxItem(true)]
  public partial class RadButtonWithCheckmark : AbstractUserControl
  {
    public RadButtonWithCheckmark()
    {
      InitializeComponent();
    }

    public Image Image
    {
      get => radButton1.Image;
      set
      {
        if (radButton1.InvokeRequired)
          radButton1.Invoke((MethodInvoker) delegate { radButton1.Image = value; });
        else
          radButton1.Image = value;
      }
    }

    public Image ImageCheckmark
    {
      get => pictureBox1.Image;
      set
      {
        if (pictureBox1.InvokeRequired)
          pictureBox1.Invoke((MethodInvoker) delegate { pictureBox1.Image = value; });
        else
          pictureBox1.Image = value;
      }
    }

    public string Label
    {
      get => radButton1.Text;
      set
      {
        if (radButton1.InvokeRequired)
          radButton1.Invoke((MethodInvoker) delegate { radButton1.Text = value; });
        else
          radButton1.Text = value;
      }
    }

    public bool ShowCheckmark
    {
      get => pictureBox1.Visible;
      set
      {
        if (pictureBox1.InvokeRequired)
          pictureBox1.Invoke((MethodInvoker) delegate { pictureBox1.Visible = value; });
        else
          pictureBox1.Visible = value;
      }
    }

    private void ButtonClick(object sender, EventArgs e)
    {
      OnClick(e);
    }
  }
}