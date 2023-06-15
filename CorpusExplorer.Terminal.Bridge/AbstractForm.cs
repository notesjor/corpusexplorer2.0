using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Terminal.Bridge
{
  public partial class AbstractForm : RadForm
  {
    private TelerikMetroTheme _theme = new TelerikMetroTheme();

    public AbstractForm()
    {
      try
      {
        ThemeResolutionService.EnsureThemeRegistered(_theme.ThemeName);
        ThemeResolutionService.ApplicationThemeName = _theme.ThemeName;
      }
      catch
      {
        // ignore
      }

      InitializeComponent();
    }
  }
}
