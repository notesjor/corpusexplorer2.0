using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Helper
{
  public static class IntArrayCutter
  {
    public static IEnumerable<int> CutArray(this int[] array, int from, int to)
    {
      var res = new List<int>();
      for (var i = from; i < to; i++)
        res.Add(array[i]);
      return res;
    }
  }
}