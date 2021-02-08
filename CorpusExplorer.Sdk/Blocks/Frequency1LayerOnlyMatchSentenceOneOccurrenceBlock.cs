using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Blocks.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  [XmlRoot]
  [Serializable]
  public class Frequency1LayerOnlyMatchSentenceOneOccurrenceBlock : AbstractBlock
  {
    private readonly object _lockFrequency = new object();
    private readonly object _lockSum = new object();

    [XmlIgnore]
    public Dictionary<string, double> Frequency { get; set; } = new Dictionary<string, double>();

    [XmlElement]
    public string LayerDisplayname { get; set; } = "Wort";

    [XmlIgnore]
    public int SentenceCount { get; set; }

    public override void Calculate()
    {
      if (Selection.Queries == null || Selection.Queries.Length == 0)
        return;

      Frequency = new Dictionary<string, double>();
      SentenceCount = 0;

      foreach (var csel in Selection)
      {
        var corpus = Selection.GetCorpus(csel.Key);
        var layer = corpus?.GetLayers(LayerDisplayname)?.FirstOrDefault();
        if (layer == null)
          return;

        foreach (var dsel in csel.Value)
        {
          var doc = layer[dsel];
          if (doc == null)
            return;
          var sentences = new HashSet<int>(Selection.Queries.SelectMany(q => q.GetSentenceIndices(corpus, dsel)));
          lock (_lockSum)
          {
            SentenceCount += sentences.Count;
          }

          var freq = new Dictionary<string, double>();
          foreach (var sentence in sentences)
          {
            var s = doc[sentence];
            var f = new HashSet<int>();
            foreach (var w in s)
            {
              if (f.Contains(w))
                continue;
              f.Add(w);

              var word = layer[w];
              if (freq.ContainsKey(word))
                freq[word]++;
              else
                freq.Add(word, 1);
            }
          }

          lock (_lockFrequency)
          {
            foreach (var x in freq)
              if (Frequency.ContainsKey(x.Key))
                Frequency[x.Key] += x.Value;
              else
                Frequency.Add(x.Key, x.Value);
          }
        }
      }
    }
  }
}