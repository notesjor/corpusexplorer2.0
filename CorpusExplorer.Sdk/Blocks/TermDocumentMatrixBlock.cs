using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class TermDocumentMatrixBlock : AbstractBlock
  {
    private readonly object _lockInverseDocumentVector = new object();

    public string LayerDisplayname { get; set; } = "Wort";

    public string MetadataKey { get; set; } = "GUID";

    public Dictionary<string, Dictionary<string, double>> TermDocumentMatrix { get; private set; }

    public double MinimumInversDocumentFrequency { get; set; } = 0.003d;

    public override void Calculate()
    {
      var tf = Selection.CreateBlock<DocumentTermFrequencyBlock>();
      tf.LayerDisplayname = LayerDisplayname;
      tf.MetadataKey = MetadataKey;
      tf.Calculate();

      var idf = Selection.CreateBlock<InverseDocumentFrequencyBlock>();
      idf.LayerDisplayname = LayerDisplayname;
      idf.MetadataKey = MetadataKey;
      idf.Calculate();

      lock (_lockInverseDocumentVector)
        TermDocumentMatrix = new Dictionary<string, Dictionary<string, double>>();

      Parallel.ForEach(tf.DocumentTermFrequency, Configuration.ParallelOptions, dsel =>
      {
        var m = new Dictionary<string, double>();
        foreach (var x in dsel.Value)
        {
          var v = x.Value * idf.InverseDocumentTermFrequency[x.Key];
          if (v < MinimumInversDocumentFrequency)
            continue;
          m.Add(x.Key, v);
        }

        lock (_lockInverseDocumentVector)
          TermDocumentMatrix.Add(dsel.Key, m);
      });
    }
  }
}