#region

using Telerik.WinControls;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Tool4.DocPlusEditor.Forms.Abstract
{
  public partial class AbstractForm : RadForm
  {
    // ReSharper disable once MemberCanBeProtected.Global
    public AbstractForm()
    {
      ThemeResolutionService.ApplicationThemeName = "TelerikMetroTouch";
      InitializeComponent();
    }
  }
}