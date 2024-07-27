using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Extern.Hdf5.Adapter;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;

namespace CorpusExplorer.Sdk.Extern.Hdf5.Builder
{
  public class CorpusBuilderHdf5 : AbstractCorpusBuilder
  {
    protected override AbstractCorpusAdapter CreateCorpus(Dictionary<Guid, Dictionary<string, object>> documentMetadata, Dictionary<string, object> corpusMetadata, List<Concept> concepts)
    {
      return CorpusAdapterHdf5.Create(documentMetadata, corpusMetadata, concepts);
    }

    protected override AbstractLayerAdapter CreateLayer(AbstractCorpusAdapter corpus, AbstractLayerState layer)
    {
      return LayerAdapterHdf5.Create(layer);
    }
  }
}