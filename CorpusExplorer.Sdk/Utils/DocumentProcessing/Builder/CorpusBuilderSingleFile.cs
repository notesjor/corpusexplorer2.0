using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder
{
  public class CorpusBuilderSingleFile : AbstractCorpusBuilder
  {
    protected override AbstractCorpusAdapter CreateCorpus(
      Dictionary<Guid, Dictionary<string, object>> documentMetadata,
      Dictionary<string, object> corpusMetadata,
      List<Concept> concepts)
    {
      return CorpusAdapterSingleFile.Create(documentMetadata, corpusMetadata, concepts);
    }

    protected override AbstractLayerAdapter CreateLayer(AbstractCorpusAdapter corpus, AbstractLayerState layer)
    {
      return LayerAdapterSingleFile.Create(layer);
    }
  }
}