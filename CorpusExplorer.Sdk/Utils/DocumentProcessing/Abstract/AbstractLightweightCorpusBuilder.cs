using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract
{
  public abstract class AbstractLightweightCorpusBuilder : AbstractCorpusBuilder
  {
    public override IEnumerable<AbstractCorpusAdapter> Create(
      IEnumerable<AbstractLayerState> layers,
      Dictionary<Guid, Dictionary<string, object>> documentMetadata,
      Dictionary<string, object> corpusMetadata,
      List<Concept> concepts)
    {
      return documentMetadata.Select(
                                     meta =>
                                       base.Create(
                                                   layers.Select(x => x.Reduce(meta.Key)),
                                                   new Dictionary<Guid, Dictionary<string, object>>
                                                     {{meta.Key, meta.Value}},
                                                   corpusMetadata,
                                                   concepts).FirstOrDefault()).ToList();
    }
  }
}