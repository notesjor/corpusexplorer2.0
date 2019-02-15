using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Forms.Abstract
{
  public partial class AbstractForm : RadForm
  {
    public AbstractForm()
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