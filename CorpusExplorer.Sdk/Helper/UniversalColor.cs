using System;

namespace CorpusExplorer.Sdk.Helper
{
  [Serializable]
  public sealed class UniversalColor
  {
    private UniversalColor() { }

    public UniversalColor(byte r, byte g, byte b)
    {
      R = r;
      G = g;
      B = b;
    }

    public UniversalColor(byte grey)
    {
      R = grey;
      G = grey;
      B = grey;
    }

    public byte B { get; set; }
    public byte G { get; set; }

    public static UniversalColor[] Palette { get; } =
    {
      new UniversalColor(0, 201, 255),
      new UniversalColor(255, 204, 0),
      new UniversalColor(0, 238, 153),
      new UniversalColor(255, 153, 0),
      new UniversalColor(255, 204, 101),
      new UniversalColor(255, 101, 101),
      new UniversalColor(255, 255, 0),
      new UniversalColor(221, 51, 85),
      new UniversalColor(10, 95, 254),
      new UniversalColor(96, 242, 88),
      new UniversalColor(241, 74, 91),
      new UniversalColor(74, 149, 241),
      new UniversalColor(241, 230, 74),
      new UniversalColor(241, 74, 146),
      new UniversalColor(241, 233, 74),
      new UniversalColor(202, 241, 74),
      new UniversalColor(74, 241, 121),
      new UniversalColor(241, 222, 74),
      new UniversalColor(241, 74, 155),
      new UniversalColor(74, 96, 241),
      new UniversalColor(241, 225, 74),
      new UniversalColor(88, 214, 242),
      new UniversalColor(242, 88, 96),
      new UniversalColor(214, 242, 88),
      new UniversalColor(242, 88, 116),
      new UniversalColor(239, 35, 73),
      new UniversalColor(68, 187, 68),
      new UniversalColor(255, 221, 51),
      new UniversalColor(238, 68, 85),
      new UniversalColor(0, 119, 221),
      new UniversalColor(17, 187, 51),
      new UniversalColor(255, 238, 68),
      new UniversalColor(238, 51, 68),
      new UniversalColor(135, 212, 246),
      new UniversalColor(97, 134, 244),
      new UniversalColor(239, 36, 73),
      new UniversalColor(150, 201, 255),
      new UniversalColor(255, 204, 150),
      new UniversalColor(150, 238, 153)
    };

    public byte R { get; set; }
  }
}