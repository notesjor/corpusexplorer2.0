using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class Ngram1LayerPatternIgnoreSentencesBlock : AbstractSimple1LayerBlock
  {
    private readonly object _lock = new object();
    public Dictionary<string, int> NGramFrequency { get; private set; }
    public string NGramPattern { get; set; } = "###";
    public int NGramPatternSize { get; set; } = 1;

    public int NGramSize { get; set; } = 5;

    protected override void CalculateCall(
      AbstractCorpusAdapter corpus,
      AbstractLayerAdapter layer,
      Guid dsel,
      int[][] doc)
    {
      var dic = new Dictionary<string, int>();
      var stream = layer.ConvertToReadableDocument(doc).ReduceDocumentToStreamDocument().ToArray();
      var ngram = new string[NGramSize];

      var max = stream.Length - NGramSize + 1;
      for (var i = 0; i < max; i++)
      {
        for (var j = 0; j < NGramSize; j++)
          ngram[j] = stream[i + j]?.Replace(" ", string.Empty);

        var queue = new Queue<string[]>();
        queue.Enqueue(ngram);
        var gens = Mutate(queue, 0);

        foreach (var gen in gens)
        {
          var key = string.Join(" ", gen);
          if (dic.ContainsKey(key))
            dic[key]++;
          else
            dic.Add(key, 1);
        }
      }

      lock (_lock)
        foreach (var x in dic)
          if (NGramFrequency.ContainsKey(x.Key))
            NGramFrequency[x.Key] += x.Value;
          else
            NGramFrequency.Add(x.Key, x.Value);
    }

    protected override void CalculateCleanup()
    {
    }

    protected override void CalculateFinalize()
    {
    }

    protected override void CalculateInitProperties()
    {
      NGramFrequency = new Dictionary<string, int>();

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

            var ngen = (string[])x.Clone();
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