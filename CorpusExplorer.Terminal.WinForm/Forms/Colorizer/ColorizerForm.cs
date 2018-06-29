using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;
using CorpusExplorer.Terminal.WinForm.Helper;
using Telerik.WinControls.UI;
using PositionChangedEventArgs = Telerik.WinControls.UI.Data.PositionChangedEventArgs;

namespace CorpusExplorer.Terminal.WinForm.Forms.Colorizer
{
  public partial class ColorizerForm : AbstractDialog
  {
    private readonly Dictionary<LinearGradientBrush, string> _brushes
      = new Dictionary<LinearGradientBrush, string>
      {
        {
          new LinearGradientBrush(
            new GradientStopCollection(
              new[]
              {
                new GradientStop(Color.FromArgb(255, 255, 0, 0), 0),
                new GradientStop(Color.FromArgb(255, 255, 119, 0), 0.17),
                new GradientStop(Color.FromArgb(255, 255, 255, 0), 0.33),
                new GradientStop(Color.FromArgb(255, 0, 255, 0), 0.5),
                new GradientStop(Color.FromArgb(255, 0, 255, 255), 0.67),
                new GradientStop(Color.FromArgb(255, 0, 0, 255), 0.83),
                new GradientStop(Color.FromArgb(255, 255, 0, 255), 1)
              }
            )),
          "Spektralfarben"
        },
        {
          new LinearGradientBrush(
            new GradientStopCollection(
              new[]
              {
                new GradientStop(Color.FromArgb(255, 0, 0, 0), 0),
                new GradientStop(Color.FromArgb(255, 245, 245, 245), 1)
              }
            )),
          "Grauverlauf"
        },
        {
          new LinearGradientBrush(
            new GradientStopCollection(
              new[]
              {
                new GradientStop(Color.FromArgb(255, 255, 119, 0), 0.1),
                new GradientStop(Color.FromArgb(255, 204, 170, 0), 0.4),
                new GradientStop(Color.FromArgb(255, 245, 245, 245), 0.5),
                new GradientStop(Color.FromArgb(255, 136, 136, 255), 0.6),
                new GradientStop(Color.FromArgb(255, 0, 0, 255), 0.9)
              }
            )),
          "Orange / Blau"
        },
        {
          new LinearGradientBrush(
            new GradientStopCollection(
              new[]
              {
                new GradientStop(Color.FromArgb(255, 255, 0, 0), 0.1),
                new GradientStop(Color.FromArgb(255, 255, 136, 136), 0.4),
                new GradientStop(Color.FromArgb(255, 245, 245, 245), 0.5),
                new GradientStop(Color.FromArgb(255, 136, 136, 255), 0.6),
                new GradientStop(Color.FromArgb(255, 0, 0, 255), 0.9)
              }
            )),
          "Rot / Blau"
        },
        {
          new LinearGradientBrush(
            new GradientStopCollection(
              new[]
              {
                new GradientStop(Color.FromArgb(255, 255, 0, 0), 0.1),
                new GradientStop(Color.FromArgb(255, 255, 136, 136), 0.4),
                new GradientStop(Color.FromArgb(255, 245, 245, 245), 0.5),
                new GradientStop(Color.FromArgb(255, 136, 136, 136), 0.6),
                new GradientStop(Color.FromArgb(255, 0, 0, 0), 0.9)
              }
            )),
          "Rot / Schwarz"
        },
        {
          new LinearGradientBrush(
            new GradientStopCollection(
              new[]
              {
                new GradientStop(Color.FromArgb(255, 255, 0, 0), 0.1),
                new GradientStop(Color.FromArgb(255, 255, 136, 136), 0.4),
                new GradientStop(Color.FromArgb(255, 245, 245, 245), 0.5),
                new GradientStop(Color.FromArgb(255, 136, 255, 136), 0.6),
                new GradientStop(Color.FromArgb(255, 0, 255, 0), 0.9)
              }
            )),
          "Rot / Grün"
        }
      };

    private readonly Controls.Wpf.Colorizer.Colorizer _colorizer;

    private readonly bool _init;

    public ColorizerForm()
    {
      InitializeComponent();
      DictionaryBindingHelper.BindDictionary(_brushes, radDropDownList1);
      _colorizer = new Controls.Wpf.Colorizer.Colorizer
      {
        HideButton = true,
        HorizontalAlignment = HorizontalAlignment.Stretch,
        VerticalAlignment = VerticalAlignment.Stretch
      };
      elementHost1.Child = _colorizer;
      _init = true;
      radDropDownList1.SelectedIndex = 0;
    }

    public LinearGradientBrush Result { get; set; }

    private void radCheckBox1_ToggleStateChanged(object sender, StateChangedEventArgs args)
    {
      RefreshColor();
    }

    private void radDropDownList1_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      RefreshColor();
    }

    private void RefreshColor()
    {
      if (!_init)
        return;

      var brush = (radDropDownList1.SelectedValue as LinearGradientBrush)?.Clone();
      if (brush == null)
        return;

      if (radCheckBox1.Checked)
        brush = _colorizer.InvertBrush(brush);

      Result = brush;
      _colorizer.Colors = brush;
    }
  }
}