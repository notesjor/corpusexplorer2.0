#region

using System.ComponentModel;
using System.Windows.Forms;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  [ToolboxItem(true)]
  public partial class BigNumber : UserControl
  {
    public BigNumber() { InitializeComponent(); }

    public string Label { get { return txt_label.Text; } set { txt_label.Text = value; } }

    public string Value { get { return txt_value.Text; } set { txt_value.Text = value; } }
  }
}