#region

using System;
using System.ComponentModel;
using System.Drawing;
using CorpusExplorer.Terminal.WinForm.Helper;
using CorpusExplorer.Terminal.WinForm.Properties;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  /// <summary>
  ///   The info button.
  /// </summary>
  [ToolboxItem(true)]
  public class InfoButton : RadButton
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="InfoButton" /> class.
    /// </summary>
    public InfoButton()
    {
      MinimumSize = MaximumSize = Size = new Size(33, 33);
      Text = string.Empty;
      Image = Resources.info;

      Click += OnClick;
    }

    /// <summary>
    ///   Gets or sets the info describtion.
    /// </summary>
    public string InfoDescribtion { get; set; }

    /// <summary>
    ///   Gets or sets the info header.
    /// </summary>
    public string InfoHeader { get; set; }

    /// <summary>
    ///   Gets or sets the info image.
    /// </summary>
    public Image InfoImage { get; set; }

    /// <summary>
    ///   The on click.
    /// </summary>
    /// <param name="sender">
    ///   The sender.
    /// </param>
    /// <param name="eventArgs">
    ///   The event args.
    /// </param>
    private void OnClick(object sender, EventArgs eventArgs)
    {
      PushMessageHelper.Show(InfoHeader, InfoImage, InfoDescribtion, Location);
    }
  }
}