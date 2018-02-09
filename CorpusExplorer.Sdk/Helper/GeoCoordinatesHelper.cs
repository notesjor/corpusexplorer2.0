#region

using System;

#endregion

namespace CorpusExplorer.Sdk.Helper
{
  public static class GeoCoordinatesHelper
  {
    public static double[] Deserialize(string coordinates)
    {
      var res = new[] {0d, 0d};

      if (string.IsNullOrEmpty(coordinates))
        return res;
      var split = coordinates.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
      if (split.Length != 2)
        return res;
      if (!double.TryParse(split[0], out res[0]))
        return res;
      double.TryParse(split[1], out res[1]);
      return res;
    }

    public static string Serialize(double[] coordinates)
    {
      return coordinates == null || coordinates.Length != 2 ? string.Empty : coordinates[0] + ";" + coordinates[1];
    }
  }
}