#region

using System.ComponentModel;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm.Abstract;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  [ToolboxItem(true)]
  public partial class Header : AbstractUserControl
  {
    public Header()
    {
      InitializeComponent();
    }

    public string HeaderDescription
    {
      get => lbl_description.Text;
      set => lbl_description.Text = value;
    }

    public string HeaderHead
    {
      get => lbl_head.Text;
      set => lbl_head.Text = value;
    }
  }
}