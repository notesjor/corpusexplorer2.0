#region usings

using System.Collections.Generic;
using System.Windows.Media;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Controls.Wpf.SingleSentence.Model
{
  public class SentenceViewItem
  {
    public SentenceViewItem(string label)
    {
      Label = label;
      Items = new List<SentenceViewItem>();
      BackgroundColor = new SolidColorBrush(Color.FromRgb(255, 255, 255));
      ForegroundColor = new SolidColorBrush(Color.FromRgb(0, 0, 0));
    }

    public Brush BackgroundColor { get; set; }
    public Brush ForegroundColor { get; set; }
    public List<SentenceViewItem> Items { get; set; }
    public string Label { get; set; }
  }
}