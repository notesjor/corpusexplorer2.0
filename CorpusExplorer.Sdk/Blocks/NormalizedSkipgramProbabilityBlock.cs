using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Blocks
{
  public class NormalizedSkipgramProbabilityBlock : AbstractBlock
  {
    public bool NoSelfCrossingValues { get; set; } = true;

    public Dictionary<string, Dictionary<string, double>> NormalizedSkipgramProbability { get; set; }

    public string LayerDisplayname { get; set; } = "Wort";

    public override void Calculate()
    {
      // var blockF = Selection.CreateBlock<Frequency1LayerBlock>();
      // blockF.LayerDisplayname = LayerDisplayname;
      // blockF.Calculate();
      // var freq = blockF.Frequency.GetNormalizedDictionary();

      var blockC = Selection.CreateBlock<CrossFrequencyBlock>();
      blockC.LayerDisplayname = LayerDisplayname;
      blockC.Calculate();
      var cross = blockC.CooccurrencesFrequency.GetNormalizedDictionary();

      NormalizedSkipgramProbability = new Dictionary<string, Dictionary<string, double>>();
      foreach (var x in cross)
      foreach (var y in x.Value)
      {
        if (NoSelfCrossingValues && x.Key == y.Key)
          continue;

        var val = Math.Log(y.Value / cross[x.Key][x.Key] / cross[y.Key][y.Key]);
        if (double.IsNaN(val) || double.IsInfinity(val))
          continue;

        if (NormalizedSkipgramProbability.ContainsKey(x.Key))
        {
          if (!NormalizedSkipgramProbability[x.Key].ContainsKey(y.Key))
            NormalizedSkipgramProbability[x.Key].Add(y.Key, val);
        }
        else
        {
          NormalizedSkipgramProbability.Add(x.Key, new Dictionary<string, double> {{y.Key, val}});
        }
      }
    }
  }
}