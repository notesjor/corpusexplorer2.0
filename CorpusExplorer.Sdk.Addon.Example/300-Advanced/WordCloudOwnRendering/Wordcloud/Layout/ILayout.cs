#region

using System.Collections.Generic;
using System.Drawing;
using CorpusExplorer.Sdk.Addon.Example.WordCloudOwnRendering.Wordcloud.Model;

#endregion

namespace CorpusExplorer.Sdk.Addon.Example.WordCloudOwnRendering.Wordcloud.Layout
{
  public interface ILayout
  {
    void Arrange(IEnumerable<WordCloudItem> words, IGraphicEngine graphicEngine);
    IEnumerable<LayoutItem> GetWordsInArea(RectangleF area);
  }
}