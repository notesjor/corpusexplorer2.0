using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  public class DocumentTermFrequencyBlock : AbstractSimple1LayerBlock
  {
    private readonly object _lockDocumentTermFrequency = new object();
    public DocumentTermFrequencyBlock() { LayerDisplayname = "Wort"; }
    public Dictionary<string, int> DocumentTermFrequency { get; set; }

    protected override void CalculateCall(
      AbstractCorpusAdapter corpus,
      AbstractLayerAdapter layer,
      Guid dsel,
      int[][] doc)
    {
      var hash = new HashSet<int>(from s in doc from w in s select w).Select(x => layer[x]).ToArray();

      lock (_lockDocumentTermFrequency)
      {
        foreach (var x in hash)
          if (DocumentTermFrequency.ContainsKey(x))
            DocumentTermFrequency[x]++;
          else
            DocumentTermFrequency.Add(x, 1);
      }
    }

    protected override void CalculateCleanup() { }
    protected override void CalculateFinalize() { }

    protected override void CalculateInitProperties() { DocumentTermFrequency = new Dictionary<string, int>(); }
  }
}