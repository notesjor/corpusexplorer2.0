#region

using System.ComponentModel;
using System.Windows.Forms;
using CorpusExplorer.Terminal.WinForm.Properties;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  [ToolboxItem(true)]
  public partial class BigNumber : UserControl
  {
    private string _label;
    private readonly string[] _numberLabels = {"", "Tsd. ", "Mio. ", "Mrd. "};
    private long _value;

    public BigNumber()
    {
      InitializeComponent();
    }

    public bool ValueAutoCut { get; set; } = true;

    public string Label
    {
      get => txt_label.Text;
      set => txt_label.Text = _label = value;
    }

    public long Value
    {
      get => _value;
      set
      {
        _value = value;
        if (!ValueAutoCut)
        {
          txt_label.Text = _value.ToString();
          return;
        }

        double calc = value;

        var i = 0;
        for (; i < _numberLabels.Length; i++)
        {
          if (calc < 1000)
            break;
          calc /= 1000;
        }

        if (i >= _numberLabels.Length)
          i = _numberLabels.Length - 1;

        txt_label.Text = _numberLabels[i] + _label;
        txt_value.Text = string.Format(Resources.Dashboard_NumberFormat, calc);
      }
    }
  }
}