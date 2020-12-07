using System.Windows.Forms;
using Telerik.WinControls;

namespace CorpusExplorer.Terminal.Automate.Controls.Abstract
{
  public partial class AbstractControl : UserControl
  {
    public AbstractControl()
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
