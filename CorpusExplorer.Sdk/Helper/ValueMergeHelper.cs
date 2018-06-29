using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Helper
{
  public static class ValueMergeHelper
  {
    public static IEnumerable<T> Merge<T>(T first, IEnumerable<T> list)
    {
      var res = new List<T> {first};
      res.AddRange(list);
      return res;
    }

    public static IEnumerable<T> Merge<T>(IEnumerable<T> list, T last) 
      => new List<T>(list) {last};
  }
}
