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
    private readonly object _lock = new object();

    public Dictionary<string, int> NGramFrequency { get; private set; }
    public Dictionary<string, string[]> NGramRaw { get; private set; }

    public int NGramSize { get; set; } = 3;

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
        for (var i = sentences[s].Length; i > NGramSize; i--)
        {
          var ngram = new string[NGramSize];
          for (var j = 0; j < NGramSize; j++)
            ngram[j] = sentences[s][i + j];

          var key = string.Join(" ", ngram);
          if (dic.ContainsKey(key))
          {
            dic[key]++;
          }
          else
          {
            dic.Add(key, 1);
            raw.Add(key, ngram);
          }
        }
      else
        foreach (var sentence in sentences)
          for (var i = 0; i < sentence.Length - NGramSize; i++)
          {
            var ngram = new string[NGramSize];
            for (var j = 0; j < NGramSize; j++)
              ngram[j] = sentence[i + j];

            var key = string.Join(" ", ngram);
            if (dic.ContainsKey(key))
            {
              dic[key]++;
            }
            else
            {
              dic.Add(key, 1);
              raw.Add(key, ngram);
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
      NGramFrequency = new Dictionary<string, int>();
      NGramRaw = new Dictionary<string, string[]>();

      // Property FIX!

      if (NGramSize < 1)
        NGramSize = 1;

      if (NGramSize > 99)
        NGramSize = 99;
    }
  }
}