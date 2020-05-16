using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Db.Elastic.Sdk.Context;
using Elasticsearch.Net;
using Nest;

namespace CorpusExplorer.Sdk.Db.Elastic.Model.Context
{
  public class ElasticSearchContext : ElasticSearchContextBase
  {
    public ElasticSearchContext(
      IConnectionPool connectionPool,
      string index,
      ElasticSearchContextCredentials credentials)
      : base(connectionPool, index, credentials)
    {
      _connection = connectionPool;
      _settings = new ConnectionSettings(connectionPool);
      _settings.DefaultIndex("corpusexplorer");
      _client = new ElasticClient(_settings);

      Client.Map<Corpus>(
                         m =>
                           m.AutoMap()
                            .Properties(
                                        p =>
                                          p.Object<Dictionary<string, object>>(
                                                                               s =>
                                                                                 s.Name(n => n.Metadata)
                                                                                  .Properties(
                                                                                              v =>
                                                                                                v.Text(k => k
                                                                                                           .Index(false)
                                                                                                           .Name("key"))
                                                                                                 .Text(c => c
                                                                                                           .Index(false)
                                                                                                           .Name("value"))))));
      Client.Map<Layer>(
                        m => m.AutoMap().Properties(
                                                    p =>
                                                      p.Object<Dictionary<int, string>>(
                                                                                        s =>
                                                                                          s.Name(n => n.DictionaryRaw)
                                                                                           .Properties(
                                                                                                       v =>
                                                                                                         v.Number(k => k
                                                                                                                      .Type(NumberType
                                                                                                                             .Integer)
                                                                                                                      .Name("key"))
                                                                                                          .Text(c => c
                                                                                                                    .Index(false)
                                                                                                                    .Name("value"))))));
      Client.Map<Document>(
                           m => m.AutoMap()
                                 .Properties(
                                             p =>
                                               p.Object<Dictionary<string, object>>(
                                                                                    s =>
                                                                                      s.Name(n => n.Metadata)
                                                                                       .Properties(
                                                                                                   v =>
                                                                                                     v.Text(k => k
                                                                                                                .Index(false)
                                                                                                                .Name("key"))
                                                                                                      .Text(c => c
                                                                                                                .Index(false)
                                                                                                                .Name("value"))))));

      Client.Map<LayerDocument>(m => m.AutoMap());
    }

    public void Add(Corpus corpus)
    {
      _client.IndexDocument(corpus);
    }

    public void Add(IEnumerable<Document> documents)
    {
      _client.IndexMany(documents);
    }

    public void Add(Document document)
    {
      _client.IndexDocument(document);
    }

    public void Add(Layer layer)
    {
      _client.IndexDocument(layer);
    }

    public void Add(LayerDocument layerDocument)
    {
      _client.IndexDocument(layerDocument);
    }

    public void DeleteLayer(Guid guid)
    {
      _client.Delete<Layer>(guid);
    }

    public IEnumerable<Guid> GetCorpora()
    {
      var start = 0;
      var pageSize = 1000;

      var res = new List<Guid>();
      var current = _client
                   .Search<Corpus>(x => x.Skip(start).Size(1000).Source(s => s.Includes(i => i.Field(f => f.CorpusId))))
                   .Documents
                   .Select(x => x.CorpusId).ToArray();
      while (current.Length > 0)
      {
        res.AddRange(current);
        start += pageSize;
        current = _client
                 .Search<Corpus>(x => x.Skip(start).Size(1000).Source(s => s.Includes(i => i.Field(f => f.CorpusId))))
                 .Documents.Select(x => x.CorpusId).ToArray();
      }

      return res;
    }

    public Corpus GetCorpus(Guid guid)
    {
      return _client.Get<Corpus>(new GetRequest<Corpus>("corpus", guid)).Source;
    }

    public Document GetDocument(Guid guid)
    {
      return _client.Get<Document>(new GetRequest<Document>("document", guid)).Source;
    }

    public Layer GetLayer(Guid guid)
    {
      return _client.Get<Layer>(new GetRequest<Layer>("layer", guid)).Source;
    }

    public LayerDocument GetLayerDocument(Guid documentGuid, Guid layerGuid)
    {
      return _client.Get<LayerDocument>(new GetRequest<LayerDocument>("layerdocument", string.Concat(documentGuid, ".", layerGuid))).Source;
    }

    public void Update(Layer layer)
    {
      _client.Update(new DocumentPath<Layer>(layer.LayerId), u => u.Doc(layer));
    }

    public void Update(LayerDocument layerDocument)
    {
      _client.Update(new DocumentPath<LayerDocument>(layerDocument.LayerDocumentId), u => u.Doc(layerDocument));
    }

    public void Update(Document document)
    {
      _client.Update(new DocumentPath<Document>(document.DocumentId), u => u.Doc(document));
    }

    public void Update(Corpus corpus)
    {
      _client.Update(new DocumentPath<Corpus>(corpus.CorpusId), u => u.Doc(corpus));
    }
  }
}