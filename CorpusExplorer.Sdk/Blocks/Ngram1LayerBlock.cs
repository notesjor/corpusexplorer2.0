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
  public class Ngram1LayerBlock : AbstractSimple1LayerBlock
  {
    private object _lock = new object();

    public Dictionary<string, double> NGramFrequency { get; private set; }

    public int NGramSize { get; set; } = 3;

    protected override void CalculateCall(
      AbstractCorpusAdapter corpus,
      AbstractLayerAdapter layer,
      Guid dsel,
      int[][] doc)
    {
      var dic = new Dictionary<string, int>();
      var sentences = layer.ConvertToReadableDocument(doc).Select(x => x.ToArray()).ToArray();

      foreach (var sentence in sentences)
      {
        var max = sentence.Length - NGramSize + 1;

        for (var i = 0; i < max; i++)
        {
          var ngram = new string[NGramSize];
          for (var j = 0; j < NGramSize; j++)
            ngram[j] = sentence[i + j]?.Replace(" ", string.Empty);

          var key = string.Join(" ", ngram);

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
      NGramFrequency = new Dictionary<string, double>();

      // Property FIX!

      if (NGramSize < 1)
        NGramSize = 1;

      if (NGramSize > 99)
        NGramSize = 99;
    }
  }
}