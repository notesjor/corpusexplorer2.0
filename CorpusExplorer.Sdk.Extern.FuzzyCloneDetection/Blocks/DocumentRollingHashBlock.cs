using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using Hyldahl.Hashing.SpamSum;

namespace CorpusExplorer.Sdk.Extern.FuzzyCloneDetection.Blocks
{
  public class DocumentRollingHashBlock : AbstractSimple1LayerBlock
  {
    protected override void CalculateCall(AbstractCorpusAdapter corpus, AbstractLayerAdapter layer, Guid dsel, int[][] doc)
    {
      var hash = FuzzyHashing.CalculateQuick(layer.ConvertToReadableDocument(doc).ReduceDocumentToText()).ToString();
      lock (_lock)
        DocumentHashes.Add(dsel, hash);
    }

    protected override void CalculateCleanup()
    {

    }

    protected override void CalculateFinalize()
    {

    }

    protected override void CalculateInitProperties()
    {
      DocumentHashes = new Dictionary<Guid, string>();
    }

    private object _lock = new object();
    public Dictionary<Guid, string> DocumentHashes { get; set; }
  }
}