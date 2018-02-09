using System.Drawing;
using System.Linq;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Terminal.WinForm.Helper
{
  public static class UniversalColorExtension
  {
    public static Color ToWinFormColor(this UniversalColor color) { return Color.FromArgb(color.R, color.G, color.B); }

    public static Color[] ToWinFormColor(this UniversalColor[] colors)
    {
      return colors.Select(color => color.ToWinFormColor()).ToArray();
    }

    public static System.Windows.Media.Color ToWpfColor(this UniversalColor color) { return System.Windows.Media.Color.FromRgb(color.R, color.G, color.B); }

    public static System.Windows.Media.Color[] ToWpfColor(this UniversalColor[] colors)
    {
      return colors.Select(color => color.ToWpfColor()).ToArray();
    }
  }
}