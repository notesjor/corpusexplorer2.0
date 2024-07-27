using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  public class PositionFrequencySimpleBlock : AbstractSimple1LayerBlock
  {
    private readonly object _positionsLock = new object();

    /// <summary>
    ///   Wort-Positionen.
    ///   Key = Wort.
    ///   Value =>
    ///     Position
    ///     Frequenz
    /// </summary>
    public Dictionary<string, Dictionary<int, int>> Positions { get; private set; }

    public string[] LayerQueries { get; set; }

    protected override void CalculateCall(AbstractCorpusAdapter corpus, AbstractLayerAdapter layer, Guid dsel,
                                          int[][] doc)
    {
      var temp = new Dictionary<string, Dictionary<int, int>>();

      foreach (var layerQuery in LayerQueries)
      {
        var q = layer[layerQuery];
        if (q < 0)
          continue;

        foreach (var s in doc)
        {
          if (Configuration.ProtectMemoryOverflow && s.Length > 100)
            continue;

          var idx = -1;
          for (var i = 0; i < s.Length; i++)
            if (idx > -1)
            {
              if (s[i] == q)
                if (i <= idx)
                {
                  continue;
                }
                else
                {
                  var t = idx;
                  idx = i;
                  i = t;
                  continue;
                }

              var pos = i - idx;
              var word = layer[s[i]];
              if (temp.ContainsKey(word))
                if (temp[word].ContainsKey(pos))
                  temp[word][pos]++;
                else
                  temp[word].Add(pos, 1);
              else
                temp.Add(word, new Dictionary<int, int> { { pos, 1 } });
            }
            else
            {
              if (s[i] != q)
                continue;
              idx = i;
              i = -1;
            }
        }
      }

      lock (_positionsLock)
      {
        foreach (var x in temp)
          if (Positions.ContainsKey(x.Key))
            foreach (var y in x.Value)
              if (Positions[x.Key].ContainsKey(y.Key))
                Positions[x.Key][y.Key] += y.Value;
              else
                Positions[x.Key].Add(y.Key, y.Value);
          else
            Positions.Add(x.Key, x.Value);
      }
    }

    protected override void CalculateCleanup()
    {
    }

    protected override void CalculateFinalize()
    {
    }

    protected override void CalculateInitProperties()
    {
      Positions = new Dictionary<string, Dictionary<int, int>>();
    }
  }
}