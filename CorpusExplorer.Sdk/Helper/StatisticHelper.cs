#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace CorpusExplorer.Sdk.Helper
{
  /// <summary>
  ///   The helper statistik.
  /// </summary>
  public static class StatisticHelper
  {
    /// <summary>
    ///   The fakultät.
    /// </summary>
    /// <param name="zahl">
    ///   The zahl.
    /// </param>
    /// <returns>
    ///   The <see cref="double" />.
    /// </returns>
    public static double Fakultät(double zahl)
    {
      return Fakultät((int) Math.Round(zahl, 0));
    }

    /// <summary>
    ///   The fakultät.
    /// </summary>
    /// <param name="zahl">
    ///   The zahl.
    /// </param>
    /// <returns>
    ///   The <see cref="int" />.
    /// </returns>
    public static int Fakultät(int zahl)
    {
      if (zahl < 0)
        zahl *= -1;

      if (zahl == 0 ||
          zahl == 1)
        return 1;

      var fakultät = 1;
      for (var i = 1; i <= zahl; i++)
        fakultät *= i;

      return fakultät;
    }

    /// <summary>
    ///   The mittelwert.
    /// </summary>
    /// <param name="data">
    ///   The data.
    /// </param>
    /// <returns>
    ///   The <see cref="double" />.
    /// </returns>
    public static double Mittelwert(IEnumerable<double> data)
    {
      var d = data.ToArray();
      return d.Sum() / d.Length;
    }

    /// <summary>
    ///   The standardabweichung.
    /// </summary>
    /// <param name="data">
    ///   The data.
    /// </param>
    /// <returns>
    ///   The <see cref="double" />.
    /// </returns>
    public static double Standardabweichung(IEnumerable<double> data)
    {
      var d = data.ToArray();
      var am = Mittelwert(d);
      return d.Sum(x => Math.Abs(x - am)) / d.Length;
    }
  }
}