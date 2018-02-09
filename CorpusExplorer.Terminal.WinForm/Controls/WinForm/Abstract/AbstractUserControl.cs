#region

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Abstract
{
  /// <summary>
  ///   The abstract user control.
  /// </summary>
  [ToolboxItem(false)]
  public partial class AbstractUserControl : UserControl
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractUserControl" /> class.
    /// </summary>
    public AbstractUserControl()
    {
      ThemeResolutionService.ApplicationThemeName = "TelerikMetroTouch";
      InitializeComponent();
      Font = new Font("Segoe UI", 11);
    }
  }
}