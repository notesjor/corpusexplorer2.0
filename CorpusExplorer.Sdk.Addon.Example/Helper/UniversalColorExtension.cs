using System.Drawing;
using System.Linq;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Addon.Example.Helper
{
  public static class UniversalColorExtension
  {
    public static Color ToWinFormColor(this UniversalColor color) { return Color.FromArgb(color.R, color.G, color.B); }

    public static Color[] ToWinFormColor(this UniversalColor[] colors)
    {
      return colors.Select(color => color.ToWinFormColor()).ToArray();
    }
  }
}