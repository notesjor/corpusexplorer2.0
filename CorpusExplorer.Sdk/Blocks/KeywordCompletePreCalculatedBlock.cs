using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class KeywordCompletePreCalculatedBlock : AbstractBlock
  {
    public KeywordCompletePreCalculatedBlock()
    {
      N = 1000000;
    }

    public Dictionary<string, double> KeywordDiff { get; set; }
    public Dictionary<string, double> KeywordSignificance { get; set; }
    public Dictionary<string, double> KeywordFrequencyCurrent { get; set; }
    public Dictionary<string, double> KeywordFrequencyReference { get; set; }
    public double N { get; set; }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      var mult = 1000000d;

      KeywordDiff = new Dictionary<string, double>();
      KeywordSignificance = new Dictionary<string, double>();
      var @lock = new object();

      Parallel.ForEach(KeywordFrequencyCurrent, x =>
      {
        if (!KeywordFrequencyReference.ContainsKey(x.Key))
          return;

        var dif = (x.Value - KeywordFrequencyReference[x.Key]) * mult / KeywordFrequencyReference[x.Key];
        var sig = Configuration.GetSignificance((int)KeywordFrequencyReference[x.Key], mult);
        var val = sig.Calculate((int)x.Value, (int)Math.Abs(KeywordFrequencyReference[x.Key] - x.Value));

        lock (@lock)
        {
          KeywordDiff.Add(x.Key, dif);
          KeywordSignificance.Add(x.Key, val);
        }
      });
    }
  }
}