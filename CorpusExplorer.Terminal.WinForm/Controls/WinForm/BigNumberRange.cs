#region

using System.ComponentModel;
using System.Windows.Forms;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  [ToolboxItem(true)]
  public partial class BigNumberRange : UserControl
  {
    public BigNumberRange()
    {
      InitializeComponent();
    }

    public string Dispersion
    {
      get => txt_dispersion.Text;
      set => txt_dispersion.Text = value;
    }

    public string HighValue
    {
      get => txt_highvalue.Text;
      set => txt_highvalue.Text = value;
    }

    public string Label
    {
      get => txt_label.Text;
      set => txt_label.Text = value;
    }

    public string LowValue
    {
      get => txt_lowvalue.Text;
      set => txt_lowvalue.Text = value;
    }

    public string Value
    {
      get => txt_value.Text;
      set => txt_value.Text = value;
    }
  }
}