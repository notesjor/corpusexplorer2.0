using System.Linq;
using System.Windows.Media;

namespace CorpusExplorer.Terminal.WinForm.Helper
{
  public static class ColorGenerator
  {
    private static GradientStopCollection _collection;
    private static LinearGradientBrush _specturm;

    public static LinearGradientBrush Spectrum
    {
      get
      {
        EnsureInitialisation();
        return _specturm;
      }
    }

    public static Color GetColor(double offset)
    {
      EnsureInitialisation();

      var before = _collection.FirstOrDefault(w => w.Offset == _collection.Min(m => m.Offset));
      var after = _collection.FirstOrDefault(w => w.Offset  == _collection.Max(m => m.Offset));

      foreach (var gs in _collection)
      {
        if (gs.Offset < offset && gs.Offset > before.Offset)
          before = gs;
        if (gs.Offset > offset && gs.Offset < after.Offset)
          after = gs;
      }

      return new Color
      {
        ScA =
          (float)
          ((offset - before.Offset) * (after.Color.ScA - before.Color.ScA) / (after.Offset - before.Offset) +
           before.Color.ScA),
        ScR =
          (float)
          ((offset - before.Offset) * (after.Color.ScR - before.Color.ScR) / (after.Offset - before.Offset) +
           before.Color.ScR),
        ScG =
          (float)
          ((offset - before.Offset) * (after.Color.ScG - before.Color.ScG) / (after.Offset - before.Offset) +
           before.Color.ScG),
        ScB =
          (float)
          ((offset - before.Offset) * (after.Color.ScB - before.Color.ScB) / (after.Offset - before.Offset) +
           before.Color.ScB)
      };
    }

    public static Color[] GetColors(int count)
    {
      var res = new Color[count];
      var val = 0.05;

      for (var i = 0; i < count; i++)
      {
        res[i] = GetColor(val);
        val += 0.14;
        if (val > 1.0)
          val -= 1;
      }

      return res;
    }

    private static void EnsureInitialisation()
    {
      if (_specturm != null)
        return;

      _collection = new GradientStopCollection(
                                               new[]
                                               {
                                                 new GradientStop(Color.FromRgb(255, 0, 0), 0.0),
                                                 new GradientStop(Color.FromRgb(255, 126, 0), 0.17),
                                                 new GradientStop(Color.FromRgb(255, 255, 0), 0.33),
                                                 new GradientStop(Color.FromRgb(0, 255, 0), 0.5),
                                                 new GradientStop(Color.FromRgb(0, 255, 255), 0.67),
                                                 new GradientStop(Color.FromRgb(0, 0, 255), 0.83),
                                                 new GradientStop(Color.FromRgb(255, 0, 255), 1.0)
                                               });
      _specturm = new LinearGradientBrush(_collection);
    }
  }
}