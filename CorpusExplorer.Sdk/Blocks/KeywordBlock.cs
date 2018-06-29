using System;
using System.Collections.Generic;
using System.Linq;
using CenterSpace.NMath.Stats;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.Cooccurrence;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class KeywordBlock : AbstractCompareSelectionBlock
  {
    public KeywordBlock()
    {
      LayerDisplayname = "Wort";
      N = 1000000;
    }

    public Dictionary<string, double> KeywordDiff { get; set; }
    public Dictionary<string, double> KeywordSignificance { get; set; }
    public Dictionary<string, double> KeywordFrequencyCurrent { get; set; }
    public Dictionary<string, double> KeywordFrequencyReference { get; set; }
    public string LayerDisplayname { get; set; }
    public double N { get; set; }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      KeywordFrequencyCurrent = GetFrequency(Selection);
      var sumA = KeywordFrequencyCurrent.Sum(x => x.Value);

      KeywordFrequencyReference = GetFrequency(SelectionToCompare);
      var sumB = KeywordFrequencyReference.Sum(x => x.Value);

      KeywordDiff = new Dictionary<string, double>();
      KeywordSignificance = new Dictionary<string, double>();
      foreach (var x in KeywordFrequencyCurrent)
      {
        if (!KeywordFrequencyReference.ContainsKey(x.Key))
          continue;

        KeywordDiff.Add(x.Key, ((x.Value - KeywordFrequencyReference[x.Key]) * 100d) / KeywordFrequencyReference[x.Key]);
        var chi = new PearsonsChiSquareTest(new[,]
        {
          {(int) x.Value, (int) KeywordFrequencyReference[x.Key]},
          {(int) (sumA - x.Value), (int) (sumB - KeywordFrequencyReference[x.Key])}
        });

        KeywordSignificance.Add(x.Key, chi.ChiSquareStatistic);
      }
    }

    private Dictionary<string, double> GetFrequency(Selection selection)
    {
      var block = selection.CreateBlock<Frequency1LayerOneOccurrenceBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.Calculate();

      var freq = block.Frequency;
      var sum = freq.Sum(x => x.Value);
      return freq.ToDictionary(x => x.Key, x => x.Value / sum * 1000000);
    }
  }
}