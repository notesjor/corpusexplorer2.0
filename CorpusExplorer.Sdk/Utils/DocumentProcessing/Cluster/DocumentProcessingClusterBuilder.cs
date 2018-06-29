using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Cluster
{
  public static class DocumentProcessingClusterBuilder
  {
    public static ConcurrentQueue<Dictionary<string, object>> Build(ref Queue<string> files, AbstractScraper scraper, int clusterSize, out List<string> processedFiles)
    {
      var res = new ConcurrentQueue<Dictionary<string, object>>();
      processedFiles = new List<string>();
      var sum = 0;

      while (files.Count > 0 && sum < clusterSize)
      {
        try
        {
          var file = files.Dequeue();
          scraper.Input.Enqueue(file);
          scraper.Execute();
          sum += scraper.Output.Count;
          while (scraper.Output.Count > 0)
          {
            if (!scraper.Output.TryDequeue(out var doc))
              continue;
            res.Enqueue(doc);
          }

          processedFiles.Add(file);
        }
        catch
        {
          // ignore
        }
      }

      return res;
    }

    public static ConcurrentQueue<ConcurrentQueue<Dictionary<string, object>>> Build(ref List<Dictionary<string, object>> input, int clusterSize)
    {
      var local = (IEnumerable<Dictionary<string, object>>)input;
      return Build(ref local, clusterSize, 
      (x) =>
      {
        if (!(x is List<Dictionary<string, object>> list) || list.Count == 0)
          return null;
        var last = list.Last();
        list.RemoveAt(list.Count - 1);
        return last;
      });
    }

    public static ConcurrentQueue<ConcurrentQueue<Dictionary<string, object>>> Build(ref Queue<Dictionary<string, object>> input, int clusterSize)
    {
      var local = (IEnumerable<Dictionary<string, object>>)input;
      return Build(ref local, clusterSize, 
      (x) =>
      {
        if (!(x is Queue<Dictionary<string, object>> queue) || queue.Count == 0)
          return null;
        return queue.Dequeue();
      });
    }

    public static ConcurrentQueue<ConcurrentQueue<Dictionary<string, object>>> Build(ref ConcurrentQueue<Dictionary<string, object>> input, int clusterSize)
    {
      var local = (IEnumerable<Dictionary<string, object>>)input;
      return Build(ref local, clusterSize,
      (x) =>
      {
        if (!(x is ConcurrentQueue<Dictionary<string, object>> queue) || queue.Count == 0)
          return null;
        return queue.TryDequeue(out var value) ? value : null;
      });
    }

    private delegate Dictionary<string, object> GetEntryDelegate(IEnumerable<Dictionary<string, object>> input);

    private static ConcurrentQueue<ConcurrentQueue<Dictionary<string, object>>> Build(
      ref IEnumerable<Dictionary<string, object>> input, int clusterSize, GetEntryDelegate func)
    {
      var res = new ConcurrentQueue<ConcurrentQueue<Dictionary<string, object>>>();
      var cur = new List<Dictionary<string, object>>();

      // ReSharper disable PossibleMultipleEnumeration
      while (input.Any())        
      {
        if (cur.Count >= clusterSize)
        {
          res.Enqueue(new ConcurrentQueue<Dictionary<string, object>>(cur));
          cur.Clear();
          GC.Collect();
        }

        var val = func(input);
        if (val == null)
          continue;
        cur.Add(val);
      }
      // ReSharper restore PossibleMultipleEnumeration

      if (cur.Count == 0) 
        return res;

      res.Enqueue(new ConcurrentQueue<Dictionary<string, object>>(cur));
      cur.Clear();
      GC.Collect();

      return res;
    }
  }
}
