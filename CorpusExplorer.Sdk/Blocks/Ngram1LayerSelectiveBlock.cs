using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class Ngram1LayerSelectiveBlock : AbstractBlock
  {
    public Dictionary<string, int> NGramFrequency { get; private set; }
    public Dictionary<string, string[]> NGramRaw { get; private set; }
    public IEnumerable<string> LayerQueries { get; set; }
    public string LayerDisplayname { get; set; } = "Wort";
    public int NGramSize { get; set; } = 3;

    public override void Calculate()
    {
      var query = new FilterQuerySingleLayerExactPhrase
      {
        LayerDisplayname = LayerDisplayname,
        LayerQueries = LayerQueries
      };
      var selection = Selection.CreateTemporary(new[] { query });

      NGramFrequency = new Dictionary<string, int>();
      NGramRaw = new Dictionary<string, string[]>();

      // Property FIX!
      if (NGramSize < 1)
        NGramSize = 1;
      if (NGramSize > 99)
        NGramSize = 99;

      var resLock = new object();

      Parallel.ForEach(selection, csel =>
      {
        var corpus = selection.GetCorpus(csel.Key);
        var layer = corpus?.GetLayers(LayerDisplayname).FirstOrDefault();
        if (layer == null)
          return;

        Parallel.ForEach(csel.Value, dsel =>
        {
          var sentences = query.GetSentenceIndices(corpus, dsel);
          var dic = new Dictionary<string, int>();
          var raw = new Dictionary<string, string[]>();

          foreach (var sentence in sentences)
          {
            var indices = query.GetWordIndices(corpus, dsel, sentence);
            var sent = layer.GetReadableDocumentSnippetByGuid(dsel, sentence, sentence).First().ToArray();

            foreach (var index in indices)
            {
              var min = index - NGramSize;
              var max = index + NGramSize;

              // min/max - FIX
              if (min < 0)
                min = 0;
              if (max >= sent.Length)
                max = sent.Length - 1;
              
              for (var i = min; i < max - NGramSize; i++)
              {
                var ngram = new string[NGramSize];
                for (var j = 0; j < NGramSize; j++)
                  ngram[j] = sent[i + j];

                var key = string.Join(@" ", ngram);
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
            }
          }

          lock (resLock)
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
        });
      });
    }
  }
}