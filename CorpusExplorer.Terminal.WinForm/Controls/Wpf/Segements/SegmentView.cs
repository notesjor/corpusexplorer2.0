using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using CorpusExplorer.Terminal.WinForm.Helper;
using Telerik.Windows.Controls.TreeMap;

namespace CorpusExplorer.Terminal.WinForm.Controls.Wpf.Segements
{
  /// <summary>
  ///   Interaktionslogik für SegmentView.xaml
  /// </summary>
  public partial class SegmentView
  {
    private readonly List<Rectangle> _rectangles = new List<Rectangle>();
    private Colorizer.Colorizer _colorizer;
    private ValueGradientColorizer _brush;

    public SegmentView()
    {
      InitializeComponent();
    }

    public void SetSegements(double[] segements)
    {
      SetSegementMax(segements.Length);

      var max = segements.Max();

      for (var i = 0; i < segements.Length; i++)
      {
        _rectangles[i].ToolTip = Math.Round(segements[i], 5);
        var val = segements[i] / max;
        var v = val > 1 ? 1 : val < 0 ? 0 : val;

        _rectangles[i].Fill = new SolidColorBrush(ColorGradientPickHelper.GetColor(_brush, v));
        _rectangles[i].Tag = v;
      }
    }

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

    public void SetColorizer(Colorizer.Colorizer colorizer)
    {
      _colorizer = colorizer;
      _brush = _colorizer.GetValueGradientColorizer(0, 1);
      Recolor();
    }

    private void Recolor()
    {
      if (_rectangles == null)
        return;

      foreach(var r in _rectangles)
        if(r.Tag != null && r.Tag is double v)
          r.Fill = new SolidColorBrush(ColorGradientPickHelper.GetColor(_brush, v));
    }
  }
}