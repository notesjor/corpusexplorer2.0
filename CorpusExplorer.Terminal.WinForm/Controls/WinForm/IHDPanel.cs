#region

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  /// <summary>
  ///   The ihd panel.
  /// </summary>
  [ToolboxItem(true)]
  public partial class IHDPanel : UserControl
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="IHDPanel" /> class.
    /// </summary>
    public IHDPanel()
    {
      ThemeResolutionService.ApplicationThemeName = "TelerikMetroTouch";
      InitializeComponent();
    }

    /// <summary>
    ///   Gets or sets the ihd deescribtion.
    /// </summary>
    public string IHDDeescribtion { get { return radLabel2.Text; } set { radLabel2.Text = value; } }

    /// <summary>
    ///   Gets or sets the ihd header.
    /// </summary>
    public string IHDHeader { get { return radLabel1.Text; } set { radLabel1.Text = value; } }

    /// <summary>
    ///   Gets or sets the ihd image.
    /// </summary>
    public Image IHDImage { get { return pictureBox1.Image; } set { pictureBox1.Image = value; } }
  }
}