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

    public string HeaderDescribtion
    {
      get => lbl_describtion.Text;
      set => lbl_describtion.Text = value;
    }

    public string HeaderHead
    {
      get => lbl_head.Text;
      set => lbl_head.Text = value;
    }
  }
}