#region

using System.Drawing;

#endregion

namespace CorpusExplorer.Sdk.Addon.Example.WordCloudOwnRendering.Wordcloud.Layout
{
  public class TypewriterLayout : BaseLayout
  {
    private PointF m_Carret;
    private float m_LineHeight;

    public TypewriterLayout(SizeF size)
      : base(size) { m_Carret = new PointF(size.Width, 0); }

    private bool HorizontalOverflow(RectangleF rectangle) { return rectangle.Right > Surface.Right; }

    private RectangleF LineFeed(RectangleF rectangle)
    {
      var result = new RectangleF(new PointF(0, m_Carret.Y + m_LineHeight), rectangle.Size);
      m_LineHeight = rectangle.Height;
      return result;
    }

    public override bool TryFindFreeRectangle(SizeF size, out RectangleF foundRectangle)
    {
      foundRectangle = new RectangleF(m_Carret, size);
      if (HorizontalOverflow(foundRectangle))
      {
        foundRectangle = LineFeed(foundRectangle);
        if (!IsInsideSurface(foundRectangle))
          return false;
      }
      m_Carret = new PointF(foundRectangle.Right, foundRectangle.Y);

      return true;
    }
  }
}