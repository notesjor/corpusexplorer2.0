#region

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#endregion

namespace CorpusExplorer.Sdk.Addon.Example.WordCloudOwnRendering.Wordcloud.Layout
{
  public class GdiGraphicEngine : IGraphicEngine
  {
    private readonly Graphics m_Graphics;
    private readonly int m_MaxWordWeight;
    private readonly int m_MinWordWeight;
    private Font m_LastUsedFont;

    public GdiGraphicEngine(
      Graphics graphics,
      FontFamily fontFamily,
      FontStyle fontStyle,
      Color[] palette,
      float minFontSize,
      float maxFontSize,
      int minWordWeight,
      int maxWordWeight)
    {
      m_MinWordWeight = minWordWeight;
      m_MaxWordWeight = maxWordWeight;
      m_Graphics = graphics;
      FontFamily = fontFamily;
      FontStyle = fontStyle;
      Palette = palette;
      MinFontSize = minFontSize;
      MaxFontSize = maxFontSize;
      m_LastUsedFont = new Font(FontFamily, maxFontSize, FontStyle);
      m_Graphics.SmoothingMode = SmoothingMode.AntiAlias;
    }

    public FontFamily FontFamily { get; set; }
    public FontStyle FontStyle { get; set; }
    public float MaxFontSize { get; set; }
    public float MinFontSize { get; set; }
    public Color[] Palette { get; }

    public void Dispose()
    {
      m_Graphics.Dispose();
    }

    public void Draw(LayoutItem layoutItem)
    {
      var font = GetFont(layoutItem.Word.Occurrences);
      var color = GetPresudoRandomColorFromPalette(layoutItem);
      //m_Graphics.DrawString(layoutItem.Word, font, brush, layoutItem.Rectangle);
      var point = new Point((int) layoutItem.Rectangle.X, (int) layoutItem.Rectangle.Y);
      TextRenderer.DrawText(m_Graphics, layoutItem.Word.Label, font, point, color);
    }

    public void DrawEmphasized(LayoutItem layoutItem)
    {
      var font = GetFont(layoutItem.Word.Occurrences);
      var color = GetPresudoRandomColorFromPalette(layoutItem);
      //m_Graphics.DrawString(layoutItem.Word, font, brush, layoutItem.Rectangle);
      var point = new Point((int) layoutItem.Rectangle.X, (int) layoutItem.Rectangle.Y);
      TextRenderer.DrawText(m_Graphics, layoutItem.Word.Label, font, point, Color.LightGray);
      var offset = (int) (5 * font.Size / MaxFontSize) + 1;
      point.Offset(-offset, -offset);
      TextRenderer.DrawText(m_Graphics, layoutItem.Word.Label, font, point, color);
    }

    public SizeF Measure(string text, int weight)
    {
      var font = GetFont(weight);
      //return m_Graphics.MeasureString(text, font);
      return TextRenderer.MeasureText(m_Graphics, text, font);
    }

    private Font GetFont(int weight)
    {
      var fontSize = (float) (weight - m_MinWordWeight) / (m_MaxWordWeight - m_MinWordWeight)
                     * (MaxFontSize - MinFontSize) + MinFontSize;
      if (Math.Abs(m_LastUsedFont.Size - fontSize) > 0)
        m_LastUsedFont = new Font(FontFamily, fontSize, FontStyle);
      return m_LastUsedFont;
    }

    private Color GetPresudoRandomColorFromPalette(LayoutItem layoutItem)
    {
      var color = Palette[layoutItem.Word.Occurrences * layoutItem.Word.Label.Length % Palette.Length];
      return color;
    }
  }
}