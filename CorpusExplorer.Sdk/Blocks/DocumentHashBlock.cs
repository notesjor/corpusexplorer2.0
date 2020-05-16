using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  public class DocumentHashBlock : AbstractSimple1LayerBlock
  {
    protected override void CalculateCall(AbstractCorpusAdapter corpus, AbstractLayerAdapter layer, Guid dsel, int[][] doc)
    {
      var hash =
        Convert.ToBase64String(HashAlgorithm
                                .ComputeHash(Configuration.Encoding.GetBytes(layer
                                                                            .ConvertToReadableDocument(doc)
                                                                            .ReduceDocumentToText())));
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
    public HashAlgorithm HashAlgorithm { get; set; } = SHA512.Create();
  }
}
