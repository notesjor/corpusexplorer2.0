using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.Interfaces;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class Ngram1LayerSelectiveHighlightCooccurrencesBlock : AbstractBlock
  {
    public double HighSignificanceThreshold { get; set; } = 10.0;

    public string LayerDisplayname { get; set; } = "Wort";
    public double LowSignificanceThreshold { get; set; } = 5.0;
    public IEnumerable<string> LayerQueries { get; set; }
    public double MinimumSignificanceThreshold { get; set; } = 1.0;

    public int NGramSize { get; set; } = 5;

    /// <summary>
    /// Format:
    /// Key = NGram > Key = Token / Value = Signifikanz (max.)
    /// Value = Frequenz
    /// </summary>
    public KeyValuePair<KeyValuePair<string, double>[], double>[] NgramsSignificants { get; set; }

    /// <summary>
    /// Format:
    /// Key = NGram > Key = Token / Value = Rang
    /// Value = Werte > [0] = Frequenz / [1] = Signifikanz (max.) / [2] = Signifikanz (Summe)
    /// </summary>
    public KeyValuePair<KeyValuePair<string, byte>[], double[]>[] NgramsWeighted
    {
      get
      {
        var res = new List<KeyValuePair<KeyValuePair<string, byte>[], double[]>>();

        for (var i = 0; i < NgramsSignificants.Length; i++)
        {
          var key = new KeyValuePair<string, byte>[NgramsSignificants[i].Key.Length];
          var max = 0.0;
          var sum = 0.0;

          for (var j = 0; j < NgramsSignificants[i].Key.Length; j++)
          {
            var val = NgramsSignificants[i].Key[j].Value;
            if (double.IsNaN(val) || double.IsInfinity(val))
              val = 0;

            key[j] = new KeyValuePair<string, byte>(NgramsSignificants[i].Key[j].Key, val < MinimumSignificanceThreshold
                                                      ? (byte)0
                                                      : val < LowSignificanceThreshold
                                                        ? (byte)1
                                                        : val < HighSignificanceThreshold
                                                          ? (byte)2
                                                          : (byte)3);
            if (val > max)
              max = val;
            sum += val;
          }

          if (sum < Configuration.MinimumSignificance)
            continue;

          res.Add(new KeyValuePair<KeyValuePair<string, byte>[], double[]>(key, new[] { NgramsSignificants[i].Value, max, sum }));
        }

        return res.ToArray();
      }
    }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      var block1 = Selection.CreateBlock<Ngram1LayerSelectiveBlock>();
      block1.LayerDisplayname = LayerDisplayname;
      block1.LayerQueries = LayerQueries;
      block1.NGramSize = NGramSize;
      block1.Calculate();

      var block2 = Selection.CreateBlock<CooccurrenceBlock>();
      block2.LayerDisplayname = LayerDisplayname;
      block2.Calculate();
      var dict = block2.CooccurrenceSignificance.CompleteDictionaryToFullDictionary();

      var lst = new List<KeyValuePair<KeyValuePair<string, double>[], double>>();
      var init = 0.0;

      foreach (var ngram in block1.NGramFrequency)
      {
        if (ngram.Value < Configuration.MinimumFrequency)
          continue;

        var tokens = ngram.Key.Split(Splitter.Space, StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length != NGramSize)
          continue;

        var rates = new double[tokens.Length];
        for (var i = 0; i < rates.Length; i++)
          rates[i] = 0;

        for (var i = 0; i < tokens.Length; i++)
        {
          if (!dict.ContainsKey(tokens[i]))
            continue;

          var max = init;
          var sdic = dict[tokens[i]];
          for (var j = i + 1; j < tokens.Length; j++)
          {
            if (!sdic.ContainsKey(tokens[j]))
              continue;

            var val = sdic[tokens[j]];
            if (val > max)
              max = val;

            if (val > rates[j])
              rates[j] = val;
          }

          if (max > init)
            rates[i] = max;
        }

        var key = new KeyValuePair<string, double>[tokens.Length];
        for (var i = 0; i < tokens.Length; i++)
          key[i] = new KeyValuePair<string, double>(tokens[i], rates[i]);

        lst.Add(new KeyValuePair<KeyValuePair<string, double>[], double>(key, ngram.Value));
      }

      NgramsSignificants = lst.ToArray();
    }
  }
}