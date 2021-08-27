#region usings

using System;
using System.Linq;

#endregion

namespace CorpusExplorer.Sdk.Data.Helper
{
  public static class HelperStatistik
  {
    public static double Fakultät(double zahl)
    {
      return Fakultät((int) Math.Round(zahl, 0));
    }

    public static int Fakultät(int zahl)
    {
      if (zahl < 0)
        zahl *= -1;

      if (zahl == 0 || zahl == 1)
        return 1;

      var fakultät = 1;
      for (var i = 1; i <= zahl; i++)
        fakultät *= i;

      return fakultät;
    }

    public static double Mittelwert(int[] data)
    {
      return data.Aggregate<int, double>(0, (current, x) => current + x)/data.Count();
    }

    public static double Standardabweichung(int[] data)
    {
      var am = Mittelwert(data);
      return data.Sum(x => Math.Abs(x - am))/data.Count();
    }
  }
}