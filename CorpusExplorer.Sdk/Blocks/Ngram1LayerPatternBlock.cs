using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class Ngram1LayerPatternBlock : AbstractSimple1LayerBlock
  {
    private readonly object _lock = new object();
    public Dictionary<string, double> NGramFrequency { get; private set; }
    public string NGramPattern { get; set; } = "###";
    public int NGramPatternSize { get; set; } = 1;
    public Dictionary<string, string[]> NGramRaw { get; private set; }

    public int NGramSize { get; set; } = 5;

    protected override void CalculateCall(
      AbstractCorpusAdapter corpus,
      AbstractLayerAdapter layer,
      Guid dsel,
      int[][] doc)
    {
      var dic = new Dictionary<string, int>();
      var raw = new Dictionary<string, string[]>();
      var sentences = layer.ConvertToReadableDocument(doc).Select(x => x.ToArray()).ToArray();

      if (Configuration.RightToLeftSupport)
        for (var s = sentences.Length - 1; s > -1; s--)
        for (var i = NGramSize; i > NGramSize; i--)
        {
          var ngram = new string[NGramSize];
          for (var j = 0; j < NGramSize; j++)
            ngram[j] = sentences[s][i + j];

          var queue = new Queue<string[]>();
          queue.Enqueue(ngram);
          var gens = Mutate(queue, 0);

          foreach (var gen in gens)
          {
            var key = string.Join(" ", gen);
            if (dic.ContainsKey(key))
            {
              dic[key]++;
            }
            else
            {
              dic.Add(key, 1);
              raw.Add(key, gen);
            }
          }
        }
      else
        foreach (var sentence in sentences)
          for (var i = 0; i < sentence.Length - NGramSize; i++)
          {
            var ngram = new string[NGramSize];
            for (var j = 0; j < NGramSize; j++)
              ngram[j] = sentence[i + j];

            var queue = new Queue<string[]>();
            queue.Enqueue(ngram);
            var gens = Mutate(queue, 0);

            foreach (var gen in gens)
            {
              var key = string.Join(" ", gen);
              if (dic.ContainsKey(key))
              {
                dic[key]++;
              }
              else
              {
                dic.Add(key, 1);
                raw.Add(key, gen);
              }
            }
          }

      lock (_lock)
      {
        foreach (var x in dic)
          if (NGramFrequency.ContainsKey(x.Key))
          {
            NGramFrequency[x.Key]++;
          }
          else
          {
            NGramFrequency.Add(x.Key, x.Value);
            NGramRaw.Add(x.Key, raw[x.Key]);
          }
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
      NGramFrequency = new Dictionary<string, double>();
      NGramRaw = new Dictionary<string, string[]>();

      if (NGramSize < 2)
        NGramSize = 2;

      if (NGramPatternSize >= NGramSize)
        NGramPatternSize = NGramSize - 1;

      if (NGramPatternSize < 1)
        NGramPatternSize = 1;
    }

    private Queue<string[]> Mutate(Queue<string[]> gen, int generation)
    {
      while (true)
      {
        var res = new Queue<string[]>(gen.Count * NGramSize);
        while (gen.Count > 0)
        {
          var x = gen.Dequeue();
          for (var i = 0; i < x.Length; i++)
          {
            if (x[i] == NGramPattern)
              continue;

            var ngen = (string[]) x.Clone();
            ngen[i] = NGramPattern;
            res.Enqueue(ngen);
          }
        }

        generation++;
        if (generation >= NGramPatternSize)
          return res;

        gen = res;
      }
    }
  }
}