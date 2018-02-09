using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract
{
  public abstract class AbstractCorpusBuilder
  {
    public AbstractCorpusAdapter Append(AbstractCorpusAdapter corpus, IEnumerable<AbstractLayerState> layers)
    {
      foreach (var layer in layers)
        corpus.AddLayer(CreateLayer(corpus, layer));
      return corpus;
    }

    public virtual IEnumerable<AbstractCorpusAdapter> Create(
      IEnumerable<AbstractLayerState> layers,
      Dictionary<Guid, Dictionary<string, object>> documentMetadata,
      Dictionary<string, object> corpusMetadata,
      List<Concept> concepts)
    {
      var corpus = CreateCorpus(documentMetadata, corpusMetadata, concepts);
      foreach (var layer in layers)
        corpus.AddLayer(CreateLayer(corpus, layer));
      return new[] {corpus};
    }

    protected abstract AbstractCorpusAdapter CreateCorpus(
      Dictionary<Guid, Dictionary<string, object>> documentMetadata,
      Dictionary<string, object> corpusMetadata,
      List<Concept> concepts);

    protected abstract AbstractLayerAdapter CreateLayer(AbstractCorpusAdapter corpus, AbstractLayerState layer);
  }
}