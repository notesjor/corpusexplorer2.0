using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CorpusExplorer.Terminal.WinForm.Controls.Wpf.Segements
{
  /// <summary>
  ///   Interaktionslogik für SegmentView.xaml
  /// </summary>
  public partial class SegmentView
  {
    private readonly List<Rectangle> _rectangles = new List<Rectangle>();

    public SegmentView() { InitializeComponent(); }

    private void SetSegementMax(int max)
    {
      wrapPanel.Children.Clear();
      _rectangles.Clear();

      for (var i = 0; i < max; i++)
      {
        var rect = new Rectangle
        {
          Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0)),
          Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255)),
          StrokeThickness = 2,
          Height = 20,
          Width = 20,
          Margin = new Thickness(0, 0, 5, 5)
        };
        _rectangles.Add(rect);
        wrapPanel.Children.Add(rect);
      }
    }

    public void SetSegements(double[] segements)
    {
      SetSegementMax(segements.Length);

      var max = segements.Max();

      for (var i = 0; i < segements.Length; i++)
      {
        _rectangles[i].ToolTip = Math.Round(segements[i], 5);
        var val = segements[i]/max*255;
        var v = val > 255 ? (byte) 255 : val < 0 ? (byte) 0 : (byte) val;

        _rectangles[i].Fill = new SolidColorBrush(Color.FromRgb(0, v, 0));
      }
    }
  }
}