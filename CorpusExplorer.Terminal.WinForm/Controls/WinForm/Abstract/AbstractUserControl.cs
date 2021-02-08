using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Abstract
{
  public partial class AbstractUserControl : UserControl
  {
    [ToolboxItem(false)]
    public AbstractUserControl()
    {
      try
      {
        ThemeResolutionService.ApplicationThemeName = "TelerikMetroTouch";
      }
      catch
      {
        // ignore
      }

      InitializeComponent();
    }
  }
}
