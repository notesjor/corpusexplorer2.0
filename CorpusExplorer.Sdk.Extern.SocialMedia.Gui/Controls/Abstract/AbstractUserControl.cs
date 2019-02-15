using System.Windows.Forms;
using Telerik.WinControls;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Controls.Abstract
{
  public partial class AbstractUserControl : UserControl
  {
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