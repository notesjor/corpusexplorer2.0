using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Db.Core.Adapter;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;

namespace CorpusExplorer.Sdk.Db.Core
{
  public class CorpusBuilderAdoDotNet : AbstractCorpusBuilder
  {
    public string CorpusDisplayname { get; set; } = "ADO.NET-CorpusExplorer";

    protected override AbstractCorpusAdapter CreateCorpus(
        Dictionary<Guid, Dictionary<string, object>> documentMetadata,
        Dictionary<string, object> corpusMetadata,
        List<Concept> concepts)
      =>
      CorpusAdapterEntityFramework.Create(CorpusDisplayname, documentMetadata, corpusMetadata, concepts);

    protected override AbstractLayerAdapter CreateLayer(
        AbstractCorpusAdapter corpus,
        AbstractLayerState layer)
      =>
      LayerAdapterEntityFramework.Create(corpus, layer);
  }
}