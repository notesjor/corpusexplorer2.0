#region

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.Wpf.Tagger
{
  /// <summary>
  ///   Class <see cref="TaggerItem" />
  /// </summary>
  public class TaggerItem : WrapPanel
  {
    /// <summary>
    ///   The <see cref="TaggerItem._call" />
    /// </summary>
    private readonly SelectedTaggerItemChange _call;

    private readonly Dictionary<Color, StackPanel> _colorAssoziation = new Dictionary<Color, StackPanel>();

    /// <summary>
    ///   The <see cref="TaggerItem._selected" />
    /// </summary>
    private bool _selected;

    /// <summary>
    ///   Initializes a new instance of the <see cref="TaggerItem" /> class.
    /// </summary>
    /// <param name="text">
    ///   The text.
    /// </param>
    /// <param name="satzIdx">
    ///   The satz idx.
    /// </param>
    /// <param name="wortIdx">
    ///   The wort idx.
    /// </param>
    /// <param name="call">
    ///   The call.
    /// </param>
    public TaggerItem(string text, int satzIdx, int wortIdx, SelectedTaggerItemChange call)
    {
      SatzIdx = satzIdx;
      WortIdx = wortIdx;
      Orientation = Orientation.Vertical;

      Children.Add(
        new Label
        {
          Content = text,
          Padding = new Thickness(0, 0, 3, 0),
          FontSize = 18
        });

      Margin = new Thickness(0);

      MouseLeftButtonUp += (sender, args) =>
      {
        _selected = !_selected;

        call?.Invoke(SatzIdx, WortIdx, _selected);
      };

      Margin = new Thickness(0, 0, 0, 5);
    }

    /// <summary>
    ///   Gets or sets the satz idx.
    /// </summary>
    /// <value>
    ///   The satz idx.
    /// </value>
    public int SatzIdx { get; set; }

    /// <summary>
    ///   Gets or sets the wort idx.
    /// </summary>
    /// <value>
    ///   The wort idx.
    /// </value>
    public int WortIdx { get; set; }

    /// <summary>
    ///   The add.
    /// </summary>
    /// <param name="color">
    ///   The color.
    /// </param>
    public void Add(Color color, string label)
    {
      if (_colorAssoziation.ContainsKey(color))
        return;

      var rect = new StackPanel { Height = 13, Width = Width };
      var boar = new Border {BorderThickness = new Thickness(0, 2, 0, 0), BorderBrush = new SolidColorBrush(color)};
      rect.Children.Add(boar);
      rect.Children.Add(
        new TextBlock
        {     
          Foreground = new SolidColorBrush(color),
          Text = label,
          FontSize = 9,
          VerticalAlignment = VerticalAlignment.Center
        });
      Children.Add(rect);
      _colorAssoziation.Add(color, rect);
    }

    public void Remove(Color color)
    {
      if (!_colorAssoziation.ContainsKey(color))
        return;
      var rect = _colorAssoziation[color];
      Children.Remove(rect);
      _colorAssoziation.Remove(color);
    }
  }
}