using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Helper
{
  public static class RangeHelper
  {
    public static IEnumerable<int> Range(int from, int to)
    {
      var res = new List<int>();
      for (var i = from; i < to; i++)
        res.Add(i);
      return res;
    }
  }
}
