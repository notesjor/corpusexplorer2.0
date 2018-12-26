#region

using System.Drawing;
using CorpusExplorer.Terminal.WinForm.Properties;
using Telerik.WinControls.UI;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Helper
{
  /// <summary>
  ///   The push ui message.
  /// </summary>
  public static class PushMessageHelper
  {
    /// <summary>
    ///   The show.
    /// </summary>
    /// <param name="header">
    ///   The header.
    /// </param>
    /// <param name="image">
    ///   The image.
    /// </param>
    /// <param name="description">
    ///   The description.
    /// </param>
    /// <param name="location">
    ///   The location.
    /// </param>
    public static void Show(string header, Image image, string description, Point location)
    {
      var alert = new RadDesktopAlert
      {
        AutoClose = true,
        AutoCloseDelay = 10,
        CanMove = true,
        CaptionText = header,
        ContentImage = image ?? Resources.info,
        ContentText = description,
        FadeAnimationType = FadeAnimationType.FadeIn,
        ScreenPosition = AlertScreenPosition.Manual
      };
      alert.Popup.Location = new Point(location.X + 16, location.Y + 16);
      alert.ButtonItems.Clear();
    }
  }
}