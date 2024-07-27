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
  public class PositionFrequencyBlock : AbstractSimple1LayerBlock
  {
    private Dictionary<string, Dictionary<int, int>> _positions;
    private readonly object _positionsLock = new object();

    /// <summary>
    ///   Wort-Positionen.
    ///   Key = Wort.
    ///   Value =>
    ///   1 = erstes Vorkommen links
    ///   2 = Summe Vorkommen links
    ///   3 = Frequenz Vorkommen links
    ///   4 = Frequenz Vorkommen rechts
    ///   5 = Summe Vorkommen rechts
    ///   6 = letztes Vorkommen rechts
    ///   7 = Vorkommen Summe
    /// </summary>
    public Dictionary<string, Tuple<int, int, int[], int[], int, int, int>> Positions { get; private set; }

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
          if (_positions.ContainsKey(x.Key))
            foreach (var y in x.Value)
              if (_positions[x.Key].ContainsKey(y.Key))
                _positions[x.Key][y.Key] += y.Value;
              else
                _positions[x.Key].Add(y.Key, y.Value);
          else
            _positions.Add(x.Key, x.Value);
      }
    }

    protected override void CalculateCleanup()
    {
    }

    protected override void CalculateFinalize()
    {
      var min = _positions.SelectMany(x => x.Value).Min(x => x.Key);
      var max = _positions.SelectMany(x => x.Value).Max(x => x.Key);
      var minN = min * -1;
      var plock = new object();

      Parallel.ForEach(_positions, position =>
      {
        var sum = 0;
        var left = 0;
        var leftSum = 0;
        int[] pre;
        if (min < 0)
        {
          pre = new int[minN];
          for (var i = 0; i < pre.Length; i++)
          {
            if (!position.Value.ContainsKey(i - pre.Length))
            {
              pre[i] = 0;
              continue;
            }

            pre[i] = position.Value[i - pre.Length];
            sum += pre[i];
            leftSum += pre[i];
            if (left > i - pre.Length)
              left = i - pre.Length;
          }
        }
        else
        {
          pre = new int[0];
        }

        var right = 0;
        var rightSum = 0;
        int[] post;
        if (max > 0)
        {
          post = new int[max];
          for (var i = 0; i < post.Length; i++)
          {
            if (!position.Value.ContainsKey(i + 1))
            {
              post[i] = 0;
              continue;
            }

            post[i] = position.Value.ContainsKey(i + 1) ? position.Value[i + 1] : 0;
            sum += post[i];
            rightSum += post[i];
            if (right < i + 1)
              right = i + 1;
          }
        }
        else
        {
          post = new int[0];
        }

        lock (plock)
        {
          Positions.Add(position.Key,
                        new Tuple<int, int, int[], int[], int, int, int>(left, leftSum, pre, post, rightSum, right,
                                                                         sum));
        }
      });

      _positions.Clear();
    }

    protected override void CalculateInitProperties()
    {
      Positions = new Dictionary<string, Tuple<int, int, int[], int[], int, int, int>>();
      _positions = new Dictionary<string, Dictionary<int, int>>();
    }
  }
}