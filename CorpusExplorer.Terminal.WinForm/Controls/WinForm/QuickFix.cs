#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CorpusExplorer.Terminal.WinForm.Helper;
using Telerik.WinControls;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  /// <summary>
  ///   The quick fix.
  /// </summary>
  [ToolboxItem(true)]
  public partial class QuickFix : UserControl
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="QuickFix" /> class.
    /// </summary>
    public QuickFix()
    {
      ThemeResolutionService.ApplicationThemeName = "TelerikMetroTouch";
      InitializeComponent();
    }

    /// <summary>
    ///   Gets or sets a value indicating whether quick fix checked.
    /// </summary>
    public bool QuickFixChecked { get { return radCheckBox1.Checked; } set { radCheckBox1.Checked = value; } }

    /// <summary>
    ///   Gets or sets the quick fix info describtion.
    /// </summary>
    public string QuickFixInfoDescribtion { get; set; }

    /// <summary>
    ///   Gets or sets the quick fix info header.
    /// </summary>
    public string QuickFixInfoHeader { get; set; }

    /// <summary>
    ///   Gets or sets the quick fix info image.
    /// </summary>
    public Image QuickFixInfoImage { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether quick fix show fix.
    /// </summary>
    public bool QuickFixShowFix { get { return btn_fix.Visible; } set { btn_fix.Visible = value; } }

    /// <summary>
    ///   Gets or sets a value indicating whether quick fix show info.
    /// </summary>
    public bool QuickFixShowInfo { get { return btn_info.Visible; } set { btn_info.Visible = value; } }

    /// <summary>
    ///   Gets or sets a value indicating whether quick fix show refresh.
    /// </summary>
    public bool QuickFixShowRefresh { get { return btn_refresh.Visible; } set { btn_refresh.Visible = value; } }

    /// <summary>
    ///   Gets or sets the quick fix text.
    /// </summary>
    public string QuickFixText { get { return radCheckBox1.Text; } set { radCheckBox1.Text = value; } }

    /// <summary>
    ///   The btn_fix_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void btn_fix_Click(object sender, EventArgs e)
    {
      QuickFixExecute?.Invoke(sender, e);
    }

    /// <summary>
    ///   The btn_info_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void btn_info_Click(object sender, EventArgs e)
    {
      PushMessageHelper.Show(QuickFixInfoHeader, QuickFixInfoImage, QuickFixInfoDescribtion, btn_info.Location);
    }

    /// <summary>
    ///   The btn_refresh_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void btn_refresh_Click(object sender, EventArgs e)
    {
      QucikFixRefresh?.Invoke(sender, e);
    }

    /// <summary>
    ///   The qucik fix refresh.
    /// </summary>
    public event EventHandler QucikFixRefresh;

    /// <summary>
    ///   The quick fix execute.
    /// </summary>
    public event EventHandler QuickFixExecute;
  }
}