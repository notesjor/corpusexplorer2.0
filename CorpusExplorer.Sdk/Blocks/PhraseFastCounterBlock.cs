using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Blocks
{
  public class PhraseFastCounterBlock : AbstractBlock
  {
    private object _lock = new object();

    public IEnumerable<string[]> LayerQueries { get; set; }

    public string LayerDisplayname { get; set; } = "Wort";

    public Dictionary<string, double> Frequency { get; set; } = new Dictionary<string, double>();

    public override void Calculate()
    {
      Frequency = new Dictionary<string, double>();

      Parallel.ForEach(base.Selection.CorporaAndDocumentGuids, Configuration.ParallelOptions, csel =>
      {
        try
        {
          var corpus = base.Selection.GetCorpus(csel.Key);
          var layer = corpus.GetLayers(LayerDisplayname).FirstOrDefault();

          var queryTree = GetQueryTree(layer);

          Parallel.ForEach(csel.Value, Configuration.ParallelOptions, dsel =>
          {
            try
            {
              var doc = layer[dsel];
              var traces = new Queue<QueryTreeNode>();

              for (int i = 0; i < doc.Length; i++)
                for (int j = 0; j < doc[i].Length; j++)
                {
                  var w = doc[i][j];

                  // test open traces
                  var tmp = new Queue<QueryTreeNode>();
                  while (traces.Count > 0)
                  {
                    var test = traces.Dequeue().Validate(w);
                    if (test != null)
                      tmp.Enqueue(test);
                  }
                  traces = tmp;

                  var current = queryTree.Validate(w);
                  if (current != null)
                    traces.Enqueue(current);
                }
            }
            catch
            {
              // ignore
            }
          });

          var dict = queryTree.Resolve(layer);
          lock (_lock)
            foreach (var x in dict)
              if (Frequency.ContainsKey(x.Key))
                Frequency[x.Key] += x.Value;
              else
                Frequency.Add(x.Key, x.Value);
        }
        catch
        {
          // ignore
        }
      });
    }

    private sealed class QueryTreeNode
    {
      private object _lock = new object();

      public double Count { get; set; }
      public bool IsEnd { get; set; } = false;
      public Dictionary<int, QueryTreeNode> Children { get; set; } = new Dictionary<int, QueryTreeNode>();

      public void Create(Queue<int> path)
      {
        if (path.Count < 1)
        {
          IsEnd = true;
          Count = 0;

          return;
        }

        var current = path.Dequeue();
        if (!Children.ContainsKey(current))
          Children.Add(current, new QueryTreeNode());
        Children[current].Create(path);
      }

      public QueryTreeNode Validate(int w)
      {
        if (IsEnd)
          lock (_lock)
            Count++;

        return Children.ContainsKey(w) ? Children[w] : null;
      }

      public Dictionary<string, double> Resolve(AbstractLayerAdapter layer)
      {
        var res = new Dictionary<string, double>();
        foreach (var x in Children)
        {
          if (x.Value.IsEnd && x.Value.Count > 0)
            res.Add(layer[x.Key], x.Value.Count);

          foreach (var y in x.Value.Resolve(layer))
            res.Add($"{layer[x.Key]} {y.Key}", y.Value);
        }

        return res;
      }
    }

    private QueryTreeNode GetQueryTree(AbstractLayerAdapter layer)
    {
      var root = new QueryTreeNode();

      foreach (var query in LayerQueries)
      {
        var path = new int[query.Length];
        var noMatch = false;

        for (var i = 0; i < query.Length; i++)
        {
          var val = layer[query[i]];
          if (val == -1)
          {
            noMatch = true;
            break;
          }
          path[i] = val;
        }

        if (noMatch)
          continue;

        root.Create(new Queue<int>(path));
      }

      return root;
    }
  }
}
