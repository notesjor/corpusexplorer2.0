using System.ComponentModel;
using System.Windows.Forms;
using CorpusExplorer.Terminal.Automate.Controls.Abstract;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.Automate.Controls
{
  [ToolboxItem(true)]
  public partial class Info : AbstractControl
  {
    private RadOffice2007ScreenTipElement _screenTip;

    public Info()
    {
      InitializeComponent();
      radPanel1.ScreenTipNeeded += ScreenTipNeeded;
    }

    public string DisplayText { get; set; }

    private void ScreenTipNeeded(object sender, ScreenTipNeededEventArgs e)
    {
      if (_screenTip == null)
      {
        _screenTip = new Telerik.WinControls.UI.RadOffice2007ScreenTipElement();
      }
      
      _screenTip.CaptionLabel.Text = "Hinweis";
      _screenTip.MainTextLabel.Text = DisplayText;
      e.Item.ScreenTip = _screenTip;
    }
  }
}
