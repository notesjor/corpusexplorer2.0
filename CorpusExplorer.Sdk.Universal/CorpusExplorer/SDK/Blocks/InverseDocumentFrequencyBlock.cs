using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  public class InverseDocumentFrequencyBlock : AbstractBlock
  {
    public Dictionary<string, double> InverseDocumentTermFrequency { get; private set; }

    public string LayerDisplayname { get; set; } = "Wort";

    public override void Calculate()
    {
      var block = Selection.CreateBlock<DocumentTermFrequencyBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.Calculate();

      InverseDocumentTermFrequency = new Dictionary<string, double>();
      foreach (var x in block.DocumentTermFrequency.SelectMany(dsel => dsel.Value))
        if (InverseDocumentTermFrequency.ContainsKey(x.Key))
          InverseDocumentTermFrequency[x.Key]++;
        else
          InverseDocumentTermFrequency.Add(x.Key, 1);

      double n = Selection.CountDocuments;
      InverseDocumentTermFrequency = InverseDocumentTermFrequency.ToDictionary(x => x.Key, x => Math.Log(n / x.Value));
    }
  }
}