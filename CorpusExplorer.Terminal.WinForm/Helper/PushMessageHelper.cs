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
    /// <param name="describtion">
    ///   The describtion.
    /// </param>
    /// <param name="location">
    ///   The location.
    /// </param>
    public static void Show(string header, Image image, string describtion, Point location)
    {
      var alert = new RadDesktopAlert
      {
        AutoClose = true,
        AutoCloseDelay = 10,
        CanMove = true,
        CaptionText = header,
        ContentImage = image ?? Resources.info,
        ContentText = describtion,
        FadeAnimationType = FadeAnimationType.FadeIn,
        ScreenPosition = AlertScreenPosition.Manual
      };
      alert.Popup.Location = new Point(location.X + 16, location.Y + 16);
      alert.ButtonItems.Clear();
    }
  }
}