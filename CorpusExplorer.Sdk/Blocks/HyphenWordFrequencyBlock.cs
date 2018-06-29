using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Blocks
{
  /// <summary>
  ///   The hyphen block.
  /// </summary>
  [Serializable]
  public class HyphenWordFrequencyBlock : AbstractBlock
  {
    /// <summary>
    ///   Silbe/Frequenz-Wörterbuch
    /// </summary>
    public Dictionary<string, Dictionary<string, int>> HyphenFrequency { get; set; }

    public string LayerDisplayname { get; set; } = "Wort";

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      HyphenFrequency = new Dictionary<string, Dictionary<string, int>>();

      var layers = Selection.GetLayers(LayerDisplayname);
      var done = new HashSet<string>();

      foreach (var value in from layer in layers from value in layer.Values where !done.Contains(value) select value)
      {
        done.Add(value);

        string[] hyphens;
        try
        {
          hyphens = Configuration.Hyphen.Hyphenate(value)
            .HyphenatedWord.Split(new[] {"="}, StringSplitOptions.RemoveEmptyEntries);
        }
        catch
        {
          continue;
        }

        foreach (var hyphen in hyphens)
          if (HyphenFrequency.ContainsKey(hyphen))
            if (HyphenFrequency[hyphen].ContainsKey(value))
              HyphenFrequency[hyphen][value] += 1;
            else
              HyphenFrequency[hyphen].Add(value, 1);
          else
            HyphenFrequency.Add(hyphen, new Dictionary<string, int> {{value, 1}});
      }
    }
  }
}