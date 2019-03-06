using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;

namespace CorpusExplorer.Sdk.Extern.LuceneNet
{
  public class SimpleInvertIndex
  {
    private readonly Dictionary<int, Guid> _backward = new Dictionary<int, Guid>();

    [NonSerialized] private readonly AbstractCorpusAdapter _corpus;

    private readonly Dictionary<string, Dictionary<int, int[]>> _index =
      new Dictionary<string, Dictionary<int, int[]>>();

    public SimpleInvertIndex(AbstractCorpusAdapter corpus)
    {
      _corpus = corpus;
      var forward = new Dictionary<Guid, int>();
      foreach (var dsel in corpus.DocumentGuids)
      {
        forward.Add(dsel, forward.Count);
        _backward.Add(_backward.Count, dsel);
      }

      var lock0 = new object();
      Parallel.ForEach(corpus.Layers, layer =>
      {
        var l = layer.ReciveRawLayerDictionary().Values.ToDictionary(x => x, _ => new List<int>());
        var lock1 = new object();
        Parallel.ForEach(layer.DocumentGuids, dsel =>
        {
          var ws = new HashSet<int>();
          foreach (var s in layer[dsel])
          foreach (var w in s)
            ws.Add(w);

          var id = forward[dsel];

          lock (lock1)
          {
            foreach (var w in ws)
              try
              {
                l[w].Add(id);
              }
              catch
              {
                // ignore
              }
          }
        });

        lock (lock0)
        {
          _index.Add(layer.Displayname, l.ToDictionary(x => x.Key, x => x.Value.ToArray()));
        }
      });

      forward.Clear(); // cleanup
      GC.Collect();
    }

    public IEnumerable<Guid> Search(string layerDisplayname, IEnumerable<string> queries)
    {
      var layer = _corpus.GetLayers(layerDisplayname).Single();
      if (layer == null)
        return null;

      var values = layer.ValuesToIndices(queries);
      var part = _index[layerDisplayname];

      var res = new List<Guid>();
      var @lock = new object();
      Parallel.ForEach(values, value =>
      {
        var resolved = part[value].Select(x => _backward[x]).ToArray();
        lock (@lock)
        {
          res.AddRange(resolved);
        }
      });

      return res;
    }
  }
}