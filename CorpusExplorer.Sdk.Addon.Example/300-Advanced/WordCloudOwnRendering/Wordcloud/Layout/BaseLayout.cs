#region

using System;
using System.Collections.Generic;
using System.Drawing;
using CorpusExplorer.Sdk.Addon.Example.WordCloudOwnRendering.Wordcloud.Model;

#endregion

namespace CorpusExplorer.Sdk.Addon.Example.WordCloudOwnRendering.Wordcloud.Layout
{
  public abstract class BaseLayout : ILayout
  {
    protected BaseLayout(SizeF size)
    {
      Surface = new RectangleF(new PointF(0, 0), size);
      QuadTree = new QuadTree<LayoutItem>(Surface);
      Center = new PointF(Surface.X + size.Width / 2, Surface.Y + size.Height / 2);
    }

    protected PointF Center { get; set; }
    protected QuadTree<LayoutItem> QuadTree { get; set; }
    protected RectangleF Surface { get; set; }

    public void Arrange(IEnumerable<WordCloudItem> words, IGraphicEngine graphicEngine)
    {
      if (words == null)
        throw new ArgumentNullException(nameof(words));

      foreach (var word in words)
      {
        var size = graphicEngine.Measure(word.Label, word.Occurrences);
        if (!TryFindFreeRectangle(size, out var freeRectangle))
          return;
        var item = new LayoutItem(freeRectangle, word);
        QuadTree.Insert(item);
      }
    }

    public IEnumerable<LayoutItem> GetWordsInArea(RectangleF area)
    {
      return QuadTree.Query(area);
    }

    public abstract bool TryFindFreeRectangle(SizeF size, out RectangleF foundRectangle);

    protected bool IsInsideSurface(RectangleF targetRectangle)
    {
      return IsInside(Surface, targetRectangle);
    }

    private static bool IsInside(RectangleF outer, RectangleF inner)
    {
      return inner.X >= outer.X && inner.Y >= outer.Y && inner.Bottom <= outer.Bottom
             && inner.Right <= outer.Right;
    }
  }
}