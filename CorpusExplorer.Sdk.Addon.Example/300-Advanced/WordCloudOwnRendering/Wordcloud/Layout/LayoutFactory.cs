#region

using System;
using System.Drawing;

#endregion

namespace CorpusExplorer.Sdk.Addon.Example.WordCloudOwnRendering.Wordcloud.Layout
{
  public static class LayoutFactory
  {
    public static ILayout CrateLayout(LayoutType layoutType, SizeF size)
    {
      switch (layoutType)
      {
        case LayoutType.Typewriter:
          return new TypewriterLayout(size);

        case LayoutType.Spiral:
          return new SpiralLayout(size);

        default:
          throw new ArgumentException(
            $"No constructor specified to create a layout instance for {layoutType}.",
            nameof(layoutType));
      }
    }
  }
}