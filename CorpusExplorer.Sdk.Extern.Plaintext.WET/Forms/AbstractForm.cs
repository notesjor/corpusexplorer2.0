using System;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

namespace CorpusExplorer.Sdk.Extern.Plaintext.WET.Forms
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
      }

      InitializeComponent();
    }

    private void AbstractForm_Load(object sender, EventArgs e)
    {
      try
      {
        var tp = FormElement.TitleBar.TitlePrimitive;
        tp.Font = new Font("Segoe UI", 12);
        tp.Margin = new Padding(0, 5, 0, 0);

        var ip = FormElement.TitleBar.IconPrimitive;
        ip.ImageScaling = ImageScaling.None;
        ip.Size = new Size(24, 24);
        ip.ScaleSize = new Size(24, 24);
      }
      catch
      {
      }
    }
  }
}