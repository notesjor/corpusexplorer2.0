using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Helper
{
  public static class ChunkHelper
  {
    public static IEnumerable<T[]> Chunk<T>(this IEnumerable<T> items, int chunkSize)
    {
      var queue = new Queue<T>(items);
      var current = new List<T>();
      var res = new List<T[]>();
      
      while (queue.Count > 0)
      {
        if (current.Count >= chunkSize)
        {
          res.Add(current.ToArray());
          current.Clear();
        }
        current.Add(queue.Dequeue());
      }

      return res;
    }
  }
}
