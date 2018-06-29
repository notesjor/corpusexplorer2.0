#region

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  /// <summary>
  ///   The help panel.
  /// </summary>
  [ToolboxItem(true)]
  public partial class HelpPanel : UserControl
  {
    /// <summary>
    ///   Initialisiert eine neue Instanz der <see cref="HelpPanel" /> Klasse.
    /// </summary>
    public HelpPanel()
    {
      InitializeComponent();
    }

    /// <summary>
    ///   Gets or sets the help handbook text.
    /// </summary>
    public string HelpHandbookText
    {
      get => btn_handbook.Text;
      set => btn_handbook.Text = value;
    }

    /// <summary>
    ///   Gets or sets the help handbook url.
    /// </summary>
    public string HelpHandbookUrl { get; set; }

    /// <summary>
    ///   Gets or sets the help handsonlab text.
    /// </summary>
    public string HelpHandsonlabText
    {
      get => btn_handson.Text;
      set => btn_handson.Text = value;
    }

    /// <summary>
    ///   Gets or sets the help handsonlab url.
    /// </summary>
    public string HelpHandsonlabUrl { get; set; }

    public string HelpLabelDescribtion
    {
      get => header1.HeaderDescribtion;
      set => header1.HeaderDescribtion = value;
    }

    public string HelpLabelHeader
    {
      get => header1.HeaderHead;
      set => header1.HeaderHead = value;
    }

    /// <summary>
    ///   Gets or sets the help online text.
    /// </summary>
    public string HelpOnlineText
    {
      get => btn_online.Text;
      set => btn_online.Text = value;
    }

    /// <summary>
    ///   Gets or sets the help online url.
    /// </summary>
    public string HelpOnlineUrl { get; set; }

    /// <summary>
    ///   Gets or sets the help video text.
    /// </summary>
    public string HelpVideoText
    {
      get => btn_video.Text;
      set => btn_video.Text = value;
    }

    /// <summary>
    ///   Gets or sets the help video url.
    /// </summary>
    public string HelpVideoUrl { get; set; }

    /// <summary>
    ///   The btn_handbook_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void btn_handbook_Click(object sender, EventArgs e)
    {
      Start(HelpHandbookUrl);
    }

    /// <summary>
    ///   The btn_handson_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void btn_handson_Click(object sender, EventArgs e)
    {
      Start(HelpHandsonlabUrl);
    }

    /// <summary>
    ///   The btn_online_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void btn_online_Click(object sender, EventArgs e)
    {
      Start(HelpOnlineUrl);
    }

    /// <summary>
    ///   The btn_video_ click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="e">
    ///   The e.
    /// </param>
    private void btn_video_Click(object sender, EventArgs e)
    {
      Start(HelpVideoUrl);
    }

    /// <summary>
    ///   The start.
    /// </summary>
    /// <param name="url">
    ///   The url.
    /// </param>
    private void Start(string url)
    {
      try
      {
        Process.Start(url);
      }
      catch
      {
        // ignore
      }
    }
  }
}