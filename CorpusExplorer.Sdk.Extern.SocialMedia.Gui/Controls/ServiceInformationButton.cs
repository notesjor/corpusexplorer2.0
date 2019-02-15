using System;
using System.ComponentModel;
using System.Drawing;
using CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Controls.Abstract;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Controls
{
  [ToolboxItem(true)]
  public partial class ServiceInformationButton : AbstractUserControl
  {
    public ServiceInformationButton()
    {
      InitializeComponent();
    }

    public Image Image
    {
      get => pictureBox1.Image;
      set => pictureBox1.Image = value;
    }

    public string Label
    {
      get => radLabel1.Text;
      set => radLabel1.Text = value;
    }

    public event EventHandler OnClick;

    private void ControlClick(object sender, EventArgs e)
    {
      OnClick?.Invoke(sender, e);
    }
  }
}