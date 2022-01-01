#region

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.Similarity;
using CorpusExplorer.Sdk.Blocks.Similarity.Abstract;
using CorpusExplorer.Sdk.Helper;

#endregion

namespace CorpusExplorer.Sdk.Blocks
{
  public class CooccurrenceSecondLevelProfileBlock : AbstractBlock
  {
    public Dictionary<string, double> CooccurrencesSimilarity { get; set; }
    public string LayerDisplayname { get; set; } = "Wort";
    public string LayerValue { get; set; }
    public AbstractSimilarity Similarity { get; set; } = new CosineMeasure();

    public override void Calculate()
    {
      CooccurrencesSimilarity = new Dictionary<string, double>();
      var lockSim = new object();

      if (string.IsNullOrEmpty(LayerValue))
        return;

      var dic = GetDictionary();
      if (dic.Count == 0 || !dic.ContainsKey(LayerValue) || dic[LayerValue].Count < 1)
        return;

      var orig = dic[LayerValue];

      Parallel.ForEach(dic, x =>
      {
        if (x.Value == null || x.Value.Count == 0)
          return;

        // Rufe Kookkurrenzen ab
        var rawA = CleanDictionary(orig, x.Key);
        var rawB = CleanDictionary(x.Value, LayerValue);

        // Baue Vector-Dictionary
        var dicV = new HashSet<string>();
        foreach (var v in rawA)
          dicV.Add(v.Key);
        foreach (var v in rawB)
          dicV.Add(v.Key);
        var keyV = dicV.ToArray();

        // Erzeuge Vectoren
        var vecA = MakeVector(rawA, keyV);
        var vecB = MakeVector(rawB, keyV);

        // Vergleiche Vectoren
        var sim = Similarity.CalculateSimilarity(vecA, vecB);
        lock (lockSim)
          CooccurrencesSimilarity.Add(x.Key, sim);
      });
    }

    private Dictionary<string, double> CleanDictionary(Dictionary<string, double> dic, string ignore)
    {
      var res = new Dictionary<string, double>();
      foreach (var d in dic)
        if (d.Key != ignore)
          res.Add(d.Key, d.Value);

      return res;
    }

    private Dictionary<string, Dictionary<string, double>> GetDictionary()
    {
      var block = Selection.CreateBlock<CooccurrenceBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.Calculate();
      return block.CooccurrenceSignificance.CompleteDictionaryToFullDictionary();
    }

    private double[] MakeVector(Dictionary<string, double> rawValues, string[] keyV)
    {
      var res = new double[keyV.Length];
      for (var i = 0; i < keyV.Length; i++)
        res[i] = rawValues.ContainsKey(keyV[i]) ? rawValues[keyV[i]] : 0;
      return res;
    }
  }
}