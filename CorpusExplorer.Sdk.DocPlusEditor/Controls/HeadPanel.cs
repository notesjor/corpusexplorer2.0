#region

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;

#endregion

namespace CorpusExplorer.Tool4.DocPlusEditor.Controls
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
      // ReSharper disable once UnusedMember.Global
      get => radLabel2.Text;
      set => radLabel2.Text = value;
    }

    /// <summary>
    ///   Gets or sets the ihd image.
    /// </summary>
    public Image HeadPanelImage
    {
      // ReSharper disable once UnusedMember.Global
      get => pictureBox1.Image;
      set => pictureBox1.Image = value;
    }

    /// <summary>
    ///   Gets or sets the ihd header.
    /// </summary>
    public string HeadPanelTitle
    {
      // ReSharper disable once UnusedMember.Global
      get => radLabel1.Text;
      set => radLabel1.Text = value;
    }
  }
}