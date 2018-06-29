using System.Windows.Media;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Terminal.WinForm.Controls.Wpf.Helper
{
  public static class UniversalColorExtension
  {
    public static Color ToWpfColor(this UniversalColor color)
    {
      return Color.FromRgb(color.R, color.G, color.B);
    }
  }
}