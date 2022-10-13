using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls;

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Abstract
{
  public partial class AbstractUserControl : UserControl
  {
    private Telerik.WinControls.Themes.TelerikMetroTouchTheme _telerikMetroTouchTheme1 = new Telerik.WinControls.Themes.TelerikMetroTouchTheme();

    [ToolboxItem(false)]
    public AbstractUserControl()
    {
      try
      {
        ThemeResolutionService.EnsureThemeRegistered(_telerikMetroTouchTheme1.ThemeName);
        ThemeResolutionService.ApplicationThemeName = _telerikMetroTouchTheme1.ThemeName;
      }
      catch
      {
        // ignore
      }

      InitializeComponent();
      Load += AbstractUserControl_Load;
    }

    private void AbstractUserControl_Load(object sender, System.EventArgs e)
    {
      foreach(var control in this.Controls)
        if (control is RadControl rc)
          rc.SetRadAutoScale(false);
    }
  }
}
