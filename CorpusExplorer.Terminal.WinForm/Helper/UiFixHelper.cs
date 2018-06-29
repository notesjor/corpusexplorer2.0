#region

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;
using Color = System.Drawing.Color;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Helper
{
  public static class UiFixHelper
  {
    public static void AddFix(RadCommandBar bar)
    {
      foreach (var strip in bar.Rows.SelectMany(row => row.Strips))
        strip.OverflowButton.Visibility = ElementVisibility.Collapsed;
    }

    /// <summary>
    ///   The make rad panorama beautifull.
    /// </summary>
    /// <param name="radPanorama">
    ///   The rad panorama.
    /// </param>
    public static void AddFix(RadPanorama radPanorama)
    {
      foreach (var tile in radPanorama.Items.OfType<RadTileElement>())
      {
        tile.Font = new Font("Segoe UI Light", 11);
        tile.TextAlignment = ContentAlignment.BottomCenter;
        tile.BackColor = Color.White;
        tile.BorderColor = Color.DarkSeaGreen;
        tile.ForeColor = Color.Black;
        tile.TextWrap = true;
      }
    }

    public static void AddFix(RadDropDownList control)
    {
      control.PopupOpened += PopupOpened;
    }

    public static ImageSource ConvertToImageSource(this Bitmap bitmap)
    {
      var res = new BitmapImage();
      using (var ms = new MemoryStream())
      {
        bitmap.Save(ms, ImageFormat.Png);

        res.BeginInit();
        res.StreamSource = new MemoryStream(ms.ToArray());
        res.EndInit();
      }

      return res;
    }

    private static void PopupOpened(object sender, EventArgs e)
    {
      var control = sender as RadDropDownList;
      if (control == null)
        return;

      var container = (DefaultListControlStackContainer) control.DropDownListElement.ListElement.Children[0];
      var widest = 0;
      foreach (var child in container.Children)
      {
        var item = child as RadListVisualItem;
        if (item == null)
          continue;
        var tParams = new TextParams {text = item.Text};
        if (item.GetTextSize(tParams).Width > widest)
          widest = item.GetTextSize(tParams).ToSize().Width;
      }

      control.Popup.MinimumSize = new Size(widest, control.Items.Count * 16 + 2);
    }
  }
}