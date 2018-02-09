using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
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

    public Dictionary<string, double> Keywords { get; set; }
    public string LayerDisplayname { get; set; }
    public double N { get; set; }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      var a = GetFrequency(Selection);
      var sumA = a.Sum(x => x.Value);

      var b = GetFrequency(SelectionToCompare);
      var sumB = b.Sum(x => x.Value);

      Keywords = new Dictionary<string, double>();
      foreach (var x in a)
      {
        if (!b.ContainsKey(x.Key))
          continue;

        Configuration.Significance.PreCalculationSetup(x.Value, sumA - x.Value);
        Keywords.Add(x.Key, Configuration.Significance.Calculate(b[x.Key], sumB - b[x.Key]));
      }
    }

    private Dictionary<string, double> GetFrequency(Selection selection)
    {
      var block = selection.CreateBlock<Frequency1LayerOneOccurrenceBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.Calculate();
      return block.Frequency;
    }
  }
}