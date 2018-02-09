#region

using System.Drawing;
using CorpusExplorer.Sdk.Addon.Example.WordCloudOwnRendering.Wordcloud.Model;

#endregion

namespace CorpusExplorer.Sdk.Addon.Example.WordCloudOwnRendering.Wordcloud.Layout
{
  public class LayoutItem
  {
    public LayoutItem(RectangleF rectangle, WordCloudItem word)
    {
      Rectangle = rectangle;
      Word = word;
    }

    public RectangleF Rectangle { get; }
    public WordCloudItem Word { get; }

    public LayoutItem Clone() { return new LayoutItem(Rectangle, Word); }
  }
}