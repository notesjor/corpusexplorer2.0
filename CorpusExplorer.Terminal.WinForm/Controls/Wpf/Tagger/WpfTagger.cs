using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using CorpusExplorer.Terminal.WinForm.Controls.Wpf.Helper;

namespace CorpusExplorer.Terminal.WinForm.Controls.Wpf.Tagger
{
  /// <summary>
  ///   Interaktionslogik für WpfTagger.xaml
  /// </summary>
  public partial class WpfTagger : UserControl
  {
    /// <summary>
    ///   The _items
    /// </summary>
    private TaggerItem[][] _items;

    private IEnumerable<IEnumerable<string>> _text;

    /// <summary>
    ///   Initializes a new instance of the <see cref="Tagger" /> class.
    /// </summary>
    public WpfTagger()
    {
      XamlHighDpiExceptionHelper.Ensure(InitializeComponent);
    }

    public IEnumerable<IEnumerable<string>> Text
    {
      set
      {
        _text = value;

        _items =
          value.Select((satz, i) => satz.Select((wort, j) => new TaggerItem(wort, i, j, TaggerItemSelected)))
               .Select(slis => slis.ToArray())
               .ToArray();

        container.ItemsSource = null;
        container.ItemsSource = _items.SelectMany(s => s).ToArray();
      }
    }

    public void ClearLayout()
    {
      Text = _text;
    }

    public void RemoveItemColor(Color color)
    {
      foreach (var word in _items.SelectMany(sentence => sentence))
        word.Remove(color);
    }

    /// <summary>
    ///   Sets the color of the item.
    /// </summary>
    /// <param name="data">
    ///   The daten.
    /// </param>
    /// <param name="color">
    ///   The color.
    /// </param>
    public void SetItemColor(IEnumerable<IEnumerable<bool>> data, Color color, string label)
    {
      var daten = data.Select(d => d.ToArray()).ToArray();

      for (var i = 0; i < _items.Length; i++)
      for (var j = 0; j < _items[i].Length; j++)
        _items[i][j].Add(daten[i][j] ? color : Color.FromArgb(255, 255, 255, 255), label);
    }

    public void SetItemColor(int sentenceIndex, Color color, string label)
    {
      for (var i = 0; i < _items.Length; i++)
      for (var j = 0; j < _items[i].Length; j++)
        _items[i][j].Add(i == sentenceIndex ? color : Color.FromArgb(255, 255, 255, 255), label);
    }

    /// <summary>
    ///   Occurs when [tagger item selected].
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly")]
    public event SelectedTaggerItemChange TaggerItemSelected;
  }
}