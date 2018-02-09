#region

using CorpusExplorer.Sdk.Addon.Example.Helper;
using CorpusExplorer.Sdk.Addon.Example.WordCloudOwnRendering.Wordcloud.Layout;
using CorpusExplorer.Sdk.Addon.Example.WordCloudOwnRendering.Wordcloud.Model;
using CorpusExplorer.Sdk.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

#endregion

namespace CorpusExplorer.Sdk.Addon.Example.WordCloudOwnRendering.Wordcloud
{
  public class CloudControl : Panel
  {
    private Color m_BackColor;
    private LayoutItem m_ItemUderMouse;
    private ILayout m_Layout;
    private LayoutType m_LayoutType;
    private int m_MaxFontSize;
    private int m_MaxWordWeight;
    private int m_MinFontSize;
    private int m_MinWordWeight;
    private Color[] m_Palette;
    private IEnumerable<WordCloudItem> m_Words;

    public CloudControl()
    {
      m_MinWordWeight = 0;
      m_MaxWordWeight = 0;

      MaxFontSize = 68;
      MinFontSize = 6;

      BorderStyle = BorderStyle.FixedSingle;
      ResizeRedraw = true;

      m_Palette = UniversalColor.Palette.ToWinFormColor();
      m_BackColor = Color.White;
      m_LayoutType = LayoutType.Spiral;
    }

    public override Color BackColor
    {
      get { return m_BackColor; }
      set
      {
        if (m_BackColor == value)
          return;
        m_BackColor = value;
        Invalidate();
      }
    }

    public IEnumerable<WordCloudItem> Items
    {
      get { return m_Words; }
      set
      {
        m_Words = value;
        if (value == null)
          return;

        m_MaxWordWeight = m_Words.Max(x => x.Occurrences);
        m_MinWordWeight = m_Words.Min(x => x.Occurrences);

        /*
        var first = this.m_Words.FirstOrDefault();
        if (first != null)
        {
          this.m_MaxWordWeight = first.Occurrences;
          this.m_MinWordWeight = this.m_Words.Last().Occurrences;
        }
        */

        BuildLayout();
        Invalidate();
      }
    }

    public LayoutType LayoutType
    {
      get { return m_LayoutType; }
      set
      {
        if (value == m_LayoutType)
          return;

        m_LayoutType = value;
        BuildLayout();
        Invalidate();
      }
    }

    public int MaxFontSize
    {
      get { return m_MaxFontSize; }
      set
      {
        m_MaxFontSize = value;
        BuildLayout();
        Invalidate();
      }
    }

    public int MinFontSize
    {
      get { return m_MinFontSize; }
      set
      {
        m_MinFontSize = value;
        BuildLayout();
        Invalidate();
      }
    }

    public Color[] Palette
    {
      get { return m_Palette; }
      set
      {
        m_Palette = value;
        BuildLayout();
        Invalidate();
      }
    }

    private void BuildLayout()
    {
      if (m_Words == null)
        return;

      using (var graphics = CreateGraphics())
      {
        IGraphicEngine graphicEngine = new GdiGraphicEngine(
          graphics,
          Font.FontFamily,
          FontStyle.Regular,
          m_Palette,
          MinFontSize,
          MaxFontSize,
          m_MinWordWeight,
          m_MaxWordWeight);
        m_Layout = LayoutFactory.CrateLayout(m_LayoutType, Size);
        m_Layout.Arrange(m_Words, graphicEngine);
      }
    }

    public IEnumerable<LayoutItem> GetItemsInArea(RectangleF area)
    {
      return m_Layout == null ? new LayoutItem[] { } : m_Layout.GetWordsInArea(area);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      LayoutItem nextItemUnderMouse;
      var mousePositionRelativeToControl = PointToClient(new Point(MousePosition.X, MousePosition.Y));
      TryGetItemAtLocation(mousePositionRelativeToControl, out nextItemUnderMouse);
      if (nextItemUnderMouse != m_ItemUderMouse)
      {
        if (nextItemUnderMouse != null)
        {
          var newRectangleToInvalidate = RectangleGrow(nextItemUnderMouse.Rectangle, 6);
          Invalidate(newRectangleToInvalidate);
        }
        if (m_ItemUderMouse != null)
        {
          var prevRectangleToInvalidate = RectangleGrow(m_ItemUderMouse.Rectangle, 6);
          Invalidate(prevRectangleToInvalidate);
        }
        m_ItemUderMouse = nextItemUnderMouse;
      }
      base.OnMouseMove(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      if (m_Words == null)
        return;
      if (m_Layout == null)
        return;

      var wordsToRedraw = m_Layout.GetWordsInArea(e.ClipRectangle);
      using (var graphics = e.Graphics)
      {
        using (
          IGraphicEngine graphicEngine = new GdiGraphicEngine(
            graphics,
            Font.FontFamily,
            FontStyle.Regular,
            m_Palette,
            MinFontSize,
            MaxFontSize,
            m_MinWordWeight,
            m_MaxWordWeight))
        {
          foreach (var currentItem in wordsToRedraw)
            if (m_ItemUderMouse == currentItem)
              graphicEngine.DrawEmphasized(currentItem);
            else
              graphicEngine.Draw(currentItem);
        }
      }
    }

    protected override void OnResize(EventArgs eventargs)
    {
      BuildLayout();
      base.OnResize(eventargs);
    }

    private static Rectangle RectangleGrow(RectangleF original, int growByPixels)
    {
      return new Rectangle(
        (int)(original.X - growByPixels),
        (int)(original.Y - growByPixels),
        (int)(original.Width + growByPixels + 1),
        (int)(original.Height + growByPixels + 1));
    }

    public bool TryGetItemAtLocation(Point location, out LayoutItem foundItem)
    {
      foundItem = null;
      var itemsInArea = GetItemsInArea(new RectangleF(location, new SizeF(0, 0)));
      foreach (var item in itemsInArea)
      {
        foundItem = item;
        return true;
      }
      return false;
    }
  }
}