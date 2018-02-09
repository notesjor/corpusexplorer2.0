#region

using System;
using System.Drawing;

#endregion

namespace CorpusExplorer.Sdk.Addon.Example.WordCloudOwnRendering.Wordcloud.Layout
{
  public interface IGraphicEngine : IDisposable
  {
    void Draw(LayoutItem layoutItem);
    void DrawEmphasized(LayoutItem layoutItem);
    SizeF Measure(string text, int weight);
  }
}