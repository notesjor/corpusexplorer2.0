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
  public partial class HeadPanel : UserControl
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="HeadPanel" /> class.
    /// </summary>
    public HeadPanel()
    {
      ThemeResolutionService.ApplicationThemeName = "TelerikMetroTouch";
      InitializeComponent();
    }

    /// <summary>
    ///   Gets or sets the ihd deescribtion.
    /// </summary>
    public string HeadPanelDescription
    {
      get => radLabel2.Text;
      set => radLabel2.Text = value;
    }

    /// <summary>
    ///   Gets or sets the ihd header.
    /// </summary>
    public string HeadPanelTitle
    {
      get => radLabel1.Text;
      set => radLabel1.Text = value;
    }

    /// <summary>
    ///   Gets or sets the ihd image.
    /// </summary>
    public Image HeadPanelImage
    {
      get => pictureBox1.Image;
      set => pictureBox1.Image = value;
    }
  }
}