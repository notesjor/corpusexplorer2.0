using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.AdditionalTaggerWrapper.Model
{
  public class AdditionalTaggerWrapperCorpusBuilder : AbstractCorpusBuilder
  {
    protected override AbstractCorpusAdapter CreateCorpus(Dictionary<Guid, Dictionary<string, object>> documentMetadata,
                                                          Dictionary<string, object> corpusMetadata,
                                                          List<Concept> concepts)
    {
      return new AdditionalTaggerWrapperCorpus();
    }

    protected override AbstractLayerAdapter CreateLayer(AbstractCorpusAdapter corpus, AbstractLayerState layer)
    {
      return new AdditionalTaggerWrapperLayer(layer);
    }

    public List<AbstractLayerState> AbstractLayerStates { get; set; } = new List<AbstractLayerState>();
  }
}
