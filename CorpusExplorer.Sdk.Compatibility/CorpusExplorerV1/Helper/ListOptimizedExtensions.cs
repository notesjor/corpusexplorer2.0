using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Data.Helper
{
  public static class ListOptimizedExtensions
  {
    public static ListOptimized<T> ToListOptimized<T>(this IEnumerable<T> array)
    {
      return new ListOptimized<T>(array);
    }
  }
}