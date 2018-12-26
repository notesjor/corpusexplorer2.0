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
