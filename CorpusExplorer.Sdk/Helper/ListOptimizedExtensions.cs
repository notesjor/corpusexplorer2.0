#region

using System.Collections.Generic;

#endregion

namespace CorpusExplorer.Sdk.Helper
{
  /// <summary>
  ///   The list optimized extensions.
  /// </summary>
  public static class ListOptimizedExtensions
  {
    /// <summary>
    ///   The to list optimized.
    /// </summary>
    /// <param name="enumeration">
    ///   The array.
    /// </param>
    /// <typeparam name="T">
    /// </typeparam>
    public static ListOptimized<T> ToListOptimized<T>(this IEnumerable<T> enumeration)
    {
      return new ListOptimized<T>(enumeration);
    }
  }
}