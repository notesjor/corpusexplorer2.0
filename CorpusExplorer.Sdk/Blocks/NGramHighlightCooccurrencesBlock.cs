using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.Interfaces;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class NGramHighlightCooccurrencesBlock : AbstractBlock, IUseHydraSentenceOptimization
  {
    public double HighSignificanceThreshold { get; set; } = 10.0;

    public string LayerDisplayname { get; set; } = "Wort";
    public double LowSignificanceThreshold { get; set; } = 5.0;

    public double MinimumSignificanceThreshold { get; set; } = 1.0;
    public byte MinimumTrashhold { get; set; } = 2;

    public int NGramSize { get; set; } = 5;

    public Dictionary<KeyValuePair<string, byte>[], double> WeightedNgrams { get; set; }

    /// <summary>
    ///   Soll die Hydra-Optimierung verwendet werden. In diesem Fall nur die Fundsätze und nicht das gesamte Dokument
    ///   betrachtet.
    /// </summary>
    public bool UseHydraOptimization { get; set; } = false;

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      var block1 = Selection.CreateBlock<Ngram1LayerBlock>();
      block1.LayerDisplayname = LayerDisplayname;
      block1.NGramSize = NGramSize;
      block1.Calculate();

      var block2 = Selection.CreateBlock<CooccurrenceBlock>();
      block2.LayerDisplayname = LayerDisplayname;
      block2.Calculate();
      var dic = block2.CooccurrenceSignificance.CompleteDictionaryToFullDictionary();

      WeightedNgrams = new Dictionary<KeyValuePair<string, byte>[], double>();

      foreach (var ngram in block1.NGramFrequency)
      {
        var chunks = ngram.Key.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

        var key = new byte[chunks.Length];
        for (var i = 0; i < key.Length; i++)
          key[i] = 0;

        var trash = (byte) 0;
        for (var i = 0; i < chunks.Length; i++)
        {
          if (!dic.ContainsKey(chunks[i]))
            continue;

          var sig = dic[chunks[i]];
          byte max = 0;

          for (var j = i + 1; j < key.Length; j++)
          {
            if (!sig.ContainsKey(chunks[j]))
              continue;

            var val = sig[chunks[j]];
            var res = val < MinimumSignificanceThreshold
                        ? (byte) 0
                        : val < LowSignificanceThreshold
                          ? (byte) 1
                          : val < HighSignificanceThreshold
                            ? (byte) 2
                            : (byte) 3;

            if (res > max)
              max = res;

            key[j] = res;
          }

          if (max <= key[i])
            continue;

          key[i] = max;
          if (max > trash)
            trash = max;
        }

        if (trash < MinimumTrashhold)
          continue;

        var join = new List<KeyValuePair<string, byte>>();
        var was0 = true;

        for (var i = 0; i < key.Length; i++)
          if (was0)
          {
            if (key[i] == 0)
              continue;
            join.Add(new KeyValuePair<string, byte>(chunks[i], key[i]));
            was0 = false;
          }
          else
          {
            join.Add(new KeyValuePair<string, byte>(chunks[i], key[i]));
            if (key[i] == 0)
              was0 = true;
          }

        while (join.Count                 > 0 &&
               join[join.Count - 1].Value == 0)
          join.RemoveAt(join.Count - 1);

        WeightedNgrams.Add(join.ToArray(), ngram.Value);
      }
    }
  }
}