using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

namespace CorpusExplorer.Sdk.Blocks
{
  [XmlRoot]
  [Serializable]
  public class CooccurrenceSelectiveBlock : AbstractBlock
  {
    public Dictionary<string, double> CooccurrenceFrequency { get; set; }

    public Dictionary<string, double> CooccurrenceSignificance { get; set; }

    [XmlElement] public string LayerDisplayname { get; set; } = "Wort";

    [XmlArray] public string[] LayerQueries { get; set; }

    public override void Calculate()
    {
      var n = Selection.CountSentences;
      var selection = Selection.CreateTemporary(new[]
      {
        new FilterQuerySingleLayerExactPhrase
        {
          LayerDisplayname = LayerDisplayname,
          LayerQueries = LayerQueries
        }
      });

      var blockA = selection.CreateBlock<Frequency1LayerOnlyMatchSentenceOneOccurrenceBlock>();
      blockA.LayerDisplayname = LayerDisplayname;
      blockA.Calculate();

      if (blockA.Frequency == null)
        return;

      var a = blockA.SentenceCount;
      CooccurrenceFrequency = blockA.Frequency;

      var blockB = Selection.CreateBlock<Frequency1LayerOneOccurrenceBlock>();
      blockB.LayerDisplayname = LayerDisplayname;
      blockB.Calculate();

      // Signifikanz

      var sign = Configuration.GetSignificance(a, n);

      var ignore = new HashSet<string>(LayerQueries);
      var dictionary = new Dictionary<string, double>();
      foreach (var k in CooccurrenceFrequency)
      {
        if (ignore.Contains(k.Key))
          continue;
        try
        {
          var sig = sign.Calculate(blockB.Frequency[k.Key], k.Value);
          if (double.IsInfinity(sig) || double.IsNaN(sig) || sig < Configuration.MinimumSignificance)
            continue;
          dictionary.Add(k.Key, sig);
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex);
        }
      }

      CooccurrenceSignificance = dictionary;
    }

    [XmlRoot]
    [Serializable]
    public class Frequency1LayerOnlyMatchSentenceBlock : AbstractBlock
    {
      private readonly object _lockFrequency = new object();
      private readonly object _lockSum = new object();

      [XmlIgnore] public Dictionary<string, double> Frequency { get; set; } = new Dictionary<string, double>();

      [XmlElement] public string LayerDisplayname { get; set; } = "Wort";

      [XmlIgnore] public int SentenceCount { get; set; }

      public override void Calculate()
      {
        if (Selection.Queries == null || Selection.Queries.Length == 0)
          return;

        Frequency = new Dictionary<string, double>();
        SentenceCount = 0;

        Parallel.ForEach(Selection, Configuration.ParallelOptions, csel =>
        {
          var corpus = Selection.GetCorpus(csel.Key);
          var layer = corpus?.GetLayers(LayerDisplayname).FirstOrDefault();
          if (layer == null)
            return;

          Parallel.ForEach(csel.Value, Configuration.ParallelOptions, dsel =>
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
              foreach (var w in s)
              {
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
          });
        });
      }
    }

    [XmlRoot]
    [Serializable]
    public class Frequency1LayerOnlyMatchSentenceOneOccurrenceBlock : AbstractBlock
    {
      private readonly object _lockFrequency = new object();
      private readonly object _lockSum = new object();

      [XmlIgnore] public Dictionary<string, double> Frequency { get; set; } = new Dictionary<string, double>();

      [XmlElement] public string LayerDisplayname { get; set; } = "Wort";

      [XmlIgnore] public int SentenceCount { get; set; }

      public override void Calculate()
      {
        if (Selection.Queries == null || Selection.Queries.Length == 0)
          return;

        Frequency = new Dictionary<string, double>();
        SentenceCount = 0;

        foreach (var csel in Selection)
        {
          var corpus = Selection.GetCorpus(csel.Key);
          var layer = corpus?.GetLayers(LayerDisplayname).FirstOrDefault();
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
}