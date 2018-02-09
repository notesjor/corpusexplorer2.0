using System.Collections.Concurrent;
using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Helper
{
  public static class QueueExtension
  {
    private static readonly object EnqueueLock = new object();

    public static void Enqueue<T>(this Queue<T> queue, IEnumerable<T> items)
    {
      lock (EnqueueLock)
      {
        foreach (var item in items)
          queue.Enqueue(item);
      }
    }

    public static void Enqueue<T>(this ConcurrentQueue<T> queue, IEnumerable<T> items)
    {
      foreach (var item in items)
        queue.Enqueue(item);
    }
  }
}