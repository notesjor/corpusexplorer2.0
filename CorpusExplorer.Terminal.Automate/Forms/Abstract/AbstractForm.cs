using System;
using System.Windows.Forms;
using Telerik.WinControls;

namespace CorpusExplorer.Terminal.Automate
{
  public partial class AbstractForm : Telerik.WinControls.UI.RadForm
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
      Load += delegate (object sender, EventArgs args)
      {
        if (AutoMax)
          WindowState = FormWindowState.Maximized;
      };
    }

    public bool AutoMax { get; set; } = true;
  }
}
