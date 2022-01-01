#region

using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Db.SQLite.Adapter;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Db.SQLite.Builder
{
  public class CorpusBuilderSqlite : AbstractCorpusBuilder
  {
    public string CorpusDisplayname { get; set; } = "SQLite";

    protected override AbstractCorpusAdapter CreateCorpus(
      Dictionary<Guid, Dictionary<string, object>> documentMetadata,
      Dictionary<string, object> corpusMetadata,
      List<Concept> concepts) =>
      CorpusAdapterLinqConnect.Create(CorpusDisplayname, documentMetadata, corpusMetadata, concepts);

    protected override AbstractLayerAdapter CreateLayer(
      AbstractCorpusAdapter corpus,
      AbstractLayerState layer) =>
      LayerAdapterLinqConnect.Create(corpus, layer);
  }
}