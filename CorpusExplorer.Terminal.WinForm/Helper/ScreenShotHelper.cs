using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace CorpusExplorer.Terminal.WinForm.Helper
{
  public static class ScreenShotHelper
  {
    public static void ControlToImage(Control control, string path, ImageFormat format)
    {
      var bitmap = new Bitmap(control.Width, control.Height);
      control.DrawToBitmap(bitmap, new Rectangle(new Point(0, 0), control.Size));
      bitmap.Save(path, format);
    }
  }
}