using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Helper
{
  public static class IEnumerableStatistics
  {
    public static double GetMedian(this IEnumerable<double> enumerable)
    {
      var arr = enumerable.OrderBy(x => x).ToArray();
      return arr.Length     == 0 ? 0 :
             arr.Length % 2 == 0 ? (arr[arr.Length / 2 - 1] + arr[arr.Length / 2]) / 2.0 : arr[arr.Length / 2];
    }
  }
}
