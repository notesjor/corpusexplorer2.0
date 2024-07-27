#region

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;

#endregion

namespace CorpusExplorer.Tool4.DocPlusEditor.Controls.Abstract
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
    // ReSharper disable once MemberCanBeProtected.Global
    public AbstractUserControl()
    {
      ThemeResolutionService.ApplicationThemeName = "TelerikMetroTouch";
      InitializeComponent();
      // ReSharper disable once VirtualMemberCallInConstructor
      Font = new Font("Segoe UI", 11);
    }
  }
}