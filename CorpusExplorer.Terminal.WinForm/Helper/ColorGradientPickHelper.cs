using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Telerik.Windows.Controls.TreeMap;

namespace CorpusExplorer.Terminal.WinForm.Helper
{
  public static class ColorGradientPickHelper
  {
    public static Color GetColor(ValueGradientColorizer lgb, double offset)
    {
      var stops = lgb.GradientStops.OrderBy(x => x.Offset).ToArray();
      GradientStop l = stops[0], r = null;
      foreach (var stop in stops)
      {
        if (stop.Offset >= offset)
        {
          r = stop;
          break;
        }

        l = stop;
      }

      if (r == null)
        return l.Color;

      offset = (offset - l.Offset) / (r.Offset - l.Offset);
      if(double.IsNaN(offset) || double.IsInfinity(offset))
        return l.Color;

      var R = (byte)((r.Color.R - l.Color.R)*offset + l.Color.R);
      var G = (byte)((r.Color.G - l.Color.G)*offset + l.Color.G);
      var B = (byte)((r.Color.B - l.Color.B)*offset + l.Color.B);
      return Color.FromArgb(255, R, G, B);
    }
  }
}
