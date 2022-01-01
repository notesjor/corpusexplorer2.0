using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Helper;
using CorpusExplorer.Terminal.WinForm.Forms.Colorizer;
using CorpusExplorer.Terminal.WinForm.Helper;
using Telerik.Windows.Controls.TreeMap;

namespace CorpusExplorer.Terminal.WinForm.Controls.Wpf.Colorizer
{
  /// <summary>
  ///   Interaktionslogik für Colorizer.xaml
  /// </summary>
  public partial class Colorizer : UserControl
  {
    private LinearGradientBrush _colors;
    private bool _hideButton;

    public Colorizer()
    {
      XamlHighDpiExceptionHelper.Ensure(InitializeComponent);

      Colors = new LinearGradientBrush(new GradientStopCollection(
                                                                  new[]
                                                                  {
                                                                    new GradientStop(Color.FromArgb(255, 255, 0, 0), 0),
                                                                    new GradientStop(Color.FromArgb(255, 255, 119, 0),
                                                                                     0.17),
                                                                    new GradientStop(Color.FromArgb(255, 255, 255, 0),
                                                                                     0.33),
                                                                    new GradientStop(Color.FromArgb(255, 0, 255, 0),
                                                                                     0.5),
                                                                    new GradientStop(Color.FromArgb(255, 0, 255, 255),
                                                                                     0.67),
                                                                    new GradientStop(Color.FromArgb(255, 0, 0, 255),
                                                                                     0.83),
                                                                    new GradientStop(Color.FromArgb(255, 255, 0, 255),
                                                                                     1)
                                                                  }
                                                                 ));

      btn_img.Source = Properties.Resources.color_fill2.ConvertToImageSource();
    }

    public LinearGradientBrush Colors
    {
      get => _colors;
      set
      {
        _colors = value;
        preview.Fill = value;
        ColorsChanged?.Invoke(null, null);
      }
    }

    public bool HideButton
    {
      get => _hideButton;
      set
      {
        _hideButton = value;
        btn_column.Width = value ? new GridLength(0) : new GridLength(45);
      }
    }

    public event EventHandler ColorsChanged;

    public ValueGradientColorizer GetValueGradientColorizer(int min = 0, int max = 10000)
    {
      return new ValueGradientColorizer
      {
        RangeMinimum = min,
        RangeMaximum = max,
        GradientStops = InvertBrush(Colors.Clone()).GradientStops
      };
    }

    public LinearGradientBrush InvertBrush(LinearGradientBrush brush)
    {
      var stops = new List<double>();
      foreach (var stop in brush.GradientStops)
        stops.Add(stop.Offset);
      for (var i = 0; i < brush.GradientStops.Count; i++)
        brush.GradientStops[i].Offset = stops[stops.Count - 1 - i];
      return brush;
    }

    private void btn_Click(object sender, RoutedEventArgs e)
    {
      var form = new ColorizerForm();
      form.ShowDialog();
      Colors = form.Result;
    }
  }
}