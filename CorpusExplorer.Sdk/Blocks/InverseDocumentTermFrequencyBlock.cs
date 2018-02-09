using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  public class InverseDocumentTermFrequencyBlock : AbstractBlock
  {
    public Dictionary<string, double> InverseDocumentTermFrequency { get; private set; }

    public string LayerDisplayname { get; set; } = "Wort";

    public override void Calculate()
    {
      var block = Selection.CreateBlock<DocumentTermFrequencyBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.Calculate();

      double n = Selection.CountDocuments;
      InverseDocumentTermFrequency = block.DocumentTermFrequency.ToDictionary(x => x.Key, x => Math.Log(n / x.Value));
    }
  }
}