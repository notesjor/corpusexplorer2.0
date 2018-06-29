using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator;
using CorpusExplorer.Sdk.Blocks.Similarity;
using CorpusExplorer.Sdk.Blocks.Similarity.Abstract;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Blocks
{
  public class BurrowsDeltaBlock : AbstractBlock
  {
    private string[] _mfw;

    public Dictionary<string, Dictionary<string, double>> KnownAuthors { get; set; }

    public AbstractSimilarity Measure { get; set; } = new CosineMesure();

    public string MetadataKey { get; set; } = "Autor";

    public int MFWCount { get; set; } = 2000;

    public int MFWTrainingFactor { get; set; } = 10;

    private Dictionary<string, Tuple<double, double>> MfwRanges { get; set; }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      // Berechne MFW
      var blockF = Selection.CreateBlock<Frequency1LayerBlock>();
      blockF.Calculate();
      _mfw = blockF.FrequencyRelative.OrderByDescending(x => x.Value).Take(MFWCount).Select(x => x.Key).ToArray();

      // Zufalssauswahl 
      var blockC = Selection.CreateBlock<RandomSelectionClusterBlock>();
      blockC.ClusterCount = 10;
      blockC.Calculate();

      // Berechnung von MFWRanges (MFW + Zufallsauswahl)
      var cfreq = blockC.Clusters.Select(CalculateMfw).ToArray();
      var xfreq = CalculateX(cfreq); // Arithmetischer Mittelwert
      var sfreq = CalculateS(cfreq, xfreq); // Standardabweichung
      MfwRanges = sfreq.ToDictionary(
        s => s.Key,
        s => new Tuple<double, double>(xfreq[s.Key] - s.Value, xfreq[s.Key] + s.Value));

      // Training
      var blockT = Selection.CreateBlock<SelectionClusterBlock>();
      blockT.ClusterGenerator = new SelectionClusterGeneratorStringValue();
      blockT.MetadataKey = MetadataKey;
      blockT.Calculate();

      KnownAuthors = new Dictionary<string, Dictionary<string, double>>();
      foreach (var range in blockT.SelectionClusters)
      {
        var tsel = Selection.CreateTemporary(range.Value);
        if (tsel.CountToken > MFWTrainingFactor * MFWCount)
          KnownAuthors.Add(range.Key, GetProfile(tsel));
      }
    }

    public BurrowsDeltaResult Compare(Selection seletionToCompare)
    {
      var res = new BurrowsDeltaResult {CompareProfile = GetProfile(seletionToCompare)};
      res.CompareResults = KnownAuthors.ToDictionary(x => x.Key, x => CompareProfiles(x.Value, res.CompareProfile));
      return res;
    }

    public double CompareProfiles(Dictionary<string, double> profileA, Dictionary<string, double> profileB)
    {
      // Gebe Vektoren eine einheitliche Richtung!
      var keys = profileA.Keys;
      var vectorA = keys.Select(key => profileA.ContainsKey(key) ? profileA[key] : 0).Select(x => x).ToArray();
      var vectorB = keys.Select(key => profileB.ContainsKey(key) ? profileB[key] : 0).Select(x => x).ToArray();

      return Measure.CalculateSimilarity(vectorA, vectorB);
    }

    private Dictionary<string, double> CalculateMfw(Selection selection)
    {
      var block = selection.CreateBlock<Frequency1LayerBlock>();
      block.Calculate();
      var freq = block.FrequencyRelative;
      return _mfw.ToDictionary(x => x, x => freq.ContainsKey(x) ? freq[x] : 0);
    }

    private Dictionary<string, double> CalculateS(Dictionary<string, double>[] cfreq, Dictionary<string, double> xfreq)
    {
      var temp = xfreq.Keys.ToDictionary(k => k, k => new List<double>());

      foreach (var f in cfreq)
      foreach (var x in xfreq)
      {
        var v = (f.ContainsKey(x.Key) ? f[x.Key] : 0) - x.Value;
        temp[x.Key].Add(v * v);
      }

      return temp.ToDictionary(x => x.Key, x => Math.Sqrt(x.Value.Sum() / x.Value.Count));
    }

    private Dictionary<string, double> CalculateX(Dictionary<string, double>[] sfreq)
    {
      var res = new Dictionary<string, double>();
      foreach (var d in sfreq.SelectMany(dic => dic))
        if (res.ContainsKey(d.Key))
          res[d.Key] += d.Value;
        else
          res.Add(d.Key, d.Value);

      var keys = res.Keys.ToArray();
      foreach (var k in keys)
        res[k] /= sfreq.Length;

      return res;
    }

    private Dictionary<string, double> GetProfile(Selection selection)
    {
      var freq = CalculateMfw(selection);

      return MfwRanges.ToDictionary(tuple => tuple.Key, tuple => !freq.ContainsKey(tuple.Key) ? 0 : freq[tuple.Key]);
    }

    public class BurrowsDeltaResult
    {
      public Dictionary<string, double> CompareProfile { get; set; }

      public Dictionary<string, double> CompareResults { get; set; }
    }
  }
}