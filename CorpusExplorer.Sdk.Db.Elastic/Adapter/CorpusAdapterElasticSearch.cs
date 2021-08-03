using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using CorpusExplorer.Sdk.Db.Elastic.Model;
using CorpusExplorer.Sdk.Db.Elastic.Model.Context;
using CorpusExplorer.Sdk.Db.Elastic.Properties;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using Corpus = CorpusExplorer.Sdk.Db.Elastic.Model.Corpus;
using Layer = CorpusExplorer.Sdk.Db.Elastic.Model.Layer;

namespace CorpusExplorer.Sdk.Db.Elastic.Adapter
{
  public class CorpusAdapterElasticSearch : AbstractCorpusAdapter
  {
    private Corpus _corpus;
    private ElasticSearchContext _db;

    private CorpusAdapterElasticSearch()
    {
    }

    public override IEnumerable<Concept> Concepts
      => null; // TODO: Konzepte werden von EntityFramework aktuell nicht unterstützt

    public override string CorpusDisplayname
    {
      get => _corpus.Displayname;
      set => _corpus.Displayname = value;
    }

    public override Guid CorpusGuid => _corpus.CorpusId;

    public override IEnumerable<Guid> DocumentGuids
      => new HashSet<Guid>(from x in _corpus.Documents select x);

    public override IEnumerable<KeyValuePair<Guid, Dictionary<string, object>>> DocumentMetadata
      => _corpus.Documents.ToDictionary(dsel => dsel, dsel => _db.GetDocument(dsel).Metadata);

    public override Guid FirstDocument
      => _corpus.Documents.FirstOrDefault();

    public override IEnumerable<string> LayerDisplaynames
      => from x in _corpus.Layers select x.Value;

    public override IEnumerable<KeyValuePair<Guid, string>> LayerGuidAndDisplaynames
      => _corpus.Layers;

    public override IEnumerable<Guid> LayerGuids
      => from x in _corpus.Layers select x.Key;

    public override IEnumerable<AbstractLayerAdapter> Layers
      => from x in _corpus.Layers select LayerAdapterElasticSearch.Create(_db, _db.GetLayer(x.Key));

    public override IEnumerable<string> LayerUniqueDisplaynames
      => new HashSet<string>(from x in _corpus.Layers select x.Value);

    public override bool UseCompression
      => false;

    public override void AddConcept(Concept concept)
    {
      // TODO: Konzepte werden von EntityFramework aktuell nicht unterstützt
    }

    public override void AddLayer(AbstractLayerAdapter layer)
    {
      if (!_corpus.Layers.ContainsKey(layer.Guid))
        _corpus.Layers.Add(layer.Guid, layer.Displayname);
    }

    public override bool ContainsDocument(Guid documentGuid)
    {
      return (from x in _corpus.Documents select x).Any(x => x == documentGuid);
    }

    public override bool ContainsLayer(Guid layerGuid)
    {
      return (from x in _corpus.Layers select x).Any(x => x.Key == layerGuid);
    }

    public override bool ContainsLayer(string layerDisplayname)
    {
      return (from x in _corpus.Layers select x).Any(x => x.Value == layerDisplayname);
    }

    public static CorpusAdapterElasticSearch Create(
      string displayname,
      Dictionary<Guid, Dictionary<string, object>> documentMetadata,
      Dictionary<string, object> corpusMetadata,
      List<Concept> concepts)
    {
      var context = ElasticSearchContextManager.GetContext();

      // recyle
      const string GUID = "GUID";
      var guid = Guid.NewGuid();
      if (corpusMetadata != null && corpusMetadata.ContainsKey(GUID) && corpusMetadata[GUID] is Guid)
        guid = (Guid) corpusMetadata[GUID];
      var old = context.GetCorpus(guid);
      if (old != null)
        return new CorpusAdapterElasticSearch {_db = context, _corpus = old};

      var corpus =
        new Corpus
        {
          CorpusId = Guid.NewGuid(),
          Displayname = displayname,
          Metadata = corpusMetadata ?? new Dictionary<string, object>(),
          Documents = new HashSet<Guid>(documentMetadata.Select(x => x.Key)),
          Layers = new Dictionary<Guid, string>()
        };

      context.Add(documentMetadata.Select(
                                          m => new Document
                                          {
                                            CorpusId = corpus.CorpusId,
                                            DocumentId = m.Key,
                                            Metadata = m.Value,
                                            SentenceCount = 0,
                                            TokenCount = 0
                                          }));

      context.Add(corpus);

      return Create(context, corpus.CorpusId);
    }

    public static CorpusAdapterElasticSearch Create(ElasticSearchContext context, Guid corpusGuid)
    {
      var corpus = context.GetCorpus(corpusGuid);
      if (corpus == null)
        return null;

      return new CorpusAdapterElasticSearch
      {
        _db = context,
        _corpus = corpus
      };
    }

    public override IEnumerable<Guid> FindDocumentByMetadata(Dictionary<string, object> example)
    {
      return from d in _corpus.Documents
             let meta = _db.GetDocument(d).Metadata
             where example.All(x => meta.ContainsKey(x.Key) && meta[x.Key] == x.Value)
             select d;
    }

    public override AbstractCorpusBuilder GetCorpusBuilder()
    {
      return new CorpusBuilderElasticSearch();
    }

    public override IEnumerable<KeyValuePair<string, object>> GetCorpusMetadata()
    {
      return _corpus.Metadata;
    }

    public override long GetDocumentLengthInSentences(Guid documentGuid)
    {
      return (int)
        (from x in _corpus.Documents where x == documentGuid select _db.GetDocument(x).SentenceCount).FirstOrDefault();
    }

    public override long GetDocumentLengthInWords(Guid documentGuid)
    {
      return (int) (from x in _corpus.Documents where x == documentGuid select _db.GetDocument(x).TokenCount)
       .FirstOrDefault();
    }

    public override Dictionary<string, object> GetDocumentMetadata(Guid documentGuid)
    {
      return (from x in _corpus.Documents where x == documentGuid select _db.GetDocument(x).Metadata).FirstOrDefault();
    }

    public override Dictionary<string, HashSet<object>> GetDocumentMetadataPrototype()
    {
      var res = new Dictionary<string, HashSet<object>>();

      foreach (var dsel in _corpus.Documents)
      {
        var meta = _db.GetDocument(dsel).Metadata;
        foreach (var x in meta)
          if (res.ContainsKey(x.Key))
            res[x.Key].Add(x.Value);
          else
            res.Add(x.Key, new HashSet<object> {x.Value});
      }

      return res;
    }

    public override IEnumerable<string> GetDocumentMetadataPrototypeOnlyProperties()
    {
      var res = new HashSet<string>();

      foreach (var dsel in _corpus.Documents)
      {
        var meta = _db.GetDocument(dsel).Metadata;
        foreach (var x in meta)
          res.Add(x.Key);
      }

      return res;
    }

    public override IEnumerable<object> GetDocumentMetadataPrototypeOnlyPropertieValues(string property)
    {
      var res = new HashSet<object>();

      foreach (var dsel in _corpus.Documents)
      {
        var meta = _db.GetDocument(dsel).Metadata;
        if (meta.ContainsKey(property))
          res.Add(meta[property]);
      }

      return res;
    }

    public override AbstractLayerAdapter GetLayer(Guid layerGuid)
    {
      return layerGuid == Guid.Empty
               ? null
               : (from x in _corpus.Layers
                  where x.Key == layerGuid
                  select LayerAdapterElasticSearch.Create(_db, _db.GetLayer(layerGuid))).FirstOrDefault();
    }

    public override AbstractLayerAdapter GetLayerOfDocument(Guid documentGuid, string layerDisplayname)
    {
      var layers = GetLayers(layerDisplayname);
      foreach (var layer in layers)
        if (layer.ContainsDocument(documentGuid))
          return layer;
      return null;
    }

    public override IEnumerable<AbstractLayerAdapter> GetLayers(string displayname)
    {
      return from l in _corpus.Layers
             select _db.GetLayer(l.Key)
             into layer
             where layer.Displayname == displayname
             select LayerAdapterElasticSearch.Create(_db, layer);
    }

    public override IEnumerable<AbstractLayerAdapter> GetLayersOfDocument(Guid documentGuid)
    {
      return from l in _corpus.Layers
             select _db.GetLayer(l.Key)
             into layer
             where layer.LayerDocuments.Contains(documentGuid)
             select LayerAdapterElasticSearch.Create(_db, layer);
    }

    public override IEnumerable<string> GetLayerValues(string layerDisplayname)
    {
      var layers = GetLayers(layerDisplayname);

      var res = new HashSet<string>();
      foreach (var layer in layers)
      {
        var values = layer.Values;
        foreach (var x in values)
          res.Add(x);
      }

      return res;
    }

    public override IEnumerable<string> GetLayerValues(Guid layerGuid)
    {
      return GetLayer(layerGuid).Values;
    }

    public override IEnumerable<IEnumerable<string>> GetReadableDocument(Guid documentGuid, string layerDisplayname)
    {
      return GetReadableDocument(
                                 documentGuid,
                                 (from x in _corpus.Layers where x.Value == layerDisplayname select x.Key)
                                .FirstOrDefault());
    }

    public override IEnumerable<IEnumerable<string>> GetReadableDocument(Guid documentGuid, Guid layerGuid)
    {
      return GetLayer(layerGuid).GetReadableDocumentByGuid(documentGuid);
    }

    public override IEnumerable<IEnumerable<string>> GetReadableDocumentSnippet(
      Guid documentGuid,
      string layerDisplayname,
      int start,
      int stop)
    {
      return GetLayer((from x in _corpus.Layers where x.Value == layerDisplayname select x.Key).FirstOrDefault())
       .GetReadableDocumentByGuid(documentGuid);
    }

    public override Dictionary<string, IEnumerable<IEnumerable<string>>> GetReadableMultilayerDocument(
      Guid documentGuid)
    {
      var res = new Dictionary<string, IEnumerable<IEnumerable<string>>>();

      foreach (var l in _corpus.Layers)
      {
        var layer = GetLayer(l.Key);
        var doc = layer.GetReadableDocumentByGuid(documentGuid);
        if (doc != null)
          res.Add(l.Value, doc);
      }

      return res;
    }

    public override void LayerCopy(string layerDisplaynameOriginal, string layerDisplaynameCopy)
    {
      var layer = GetLayers(layerDisplaynameOriginal).FirstOrDefault();
      if (layer == null)
        return;
      var nguid = layer.Copy().Guid;

      _corpus.Layers.Add(nguid, layerDisplaynameCopy);
      _db.Update(_corpus);

      var nlayer = _db.GetLayer(nguid);
      nlayer.Displayname = layerDisplaynameCopy;
      _db.Update(nlayer);
    }

    public override void LayerDelete(string layerDisplayname)
    {
      var layer = _corpus.Layers.FirstOrDefault(l => l.Value == layerDisplayname);
      _db.DeleteLayer(layer.Key);
    }

    public override void LayerNew(string layerDisplayname)
    {
      _db.Add(
              new Layer
              {
                CorpusId = _corpus.CorpusId,
                Dictionary = new CeDictionary(new Dictionary<string, int>()),
                Displayname = layerDisplayname,
                LayerId = Guid.NewGuid()
              });
    }

    public override void LayerRename(string layerDisplaynameOld, string layerDisplaynameNew)
    {
      var layer = _db.GetLayer(_corpus.Layers.FirstOrDefault(l => l.Value == layerDisplaynameOld).Key);
      if (layer == null)
        return;
      layer.Displayname = layerDisplaynameNew;
      _db.Update(layer);
    }

    public override bool RemoveConcept(Concept concept)
    {
      // TODO: Konzepte werden von EntityFramework aktuell nicht unterstützt
      return false;
    }

    public override void ResetAllDocumentMetadata(Dictionary<Guid, Dictionary<string, object>> newMetadata)
    {
      foreach (var x in newMetadata)
      {
        if (!_corpus.Documents.Contains(x.Key))
          continue;
        var doc = _db.GetDocument(x.Key);
        doc.Metadata = x.Value;
        _db.Update(doc);
      }
    }

    public override void Save(string path, bool useCompression)
    {
      File.WriteAllLines(
                         path.EndsWith(".cenes") ? path : path + ".cenes",
                         new[] {_corpus.CorpusId.ToString(), _db.Connection});
    }

    public override void SetCorpusMetadata(string key, object value)
    {
      if (_corpus.Metadata.ContainsKey(key))
        _corpus.Metadata[key] = value;
      else
        _corpus.Metadata.Add(key, value);

      _db.Update(_corpus);
    }

    public override bool SetDocumentLayerValueMask(
      Guid documentGuid,
      Guid layerGuid,
      int sentenceIndex,
      int wordIndex,
      string layerValue)
    {
      var layer = GetLayer(layerGuid);
      return layer != null
          && layer.SetDocumentLayerValueMaskBySwitch(documentGuid, sentenceIndex, wordIndex, layerValue);
    }

    public override bool SetDocumentLayerValueMask(
      Guid documentGuid,
      string layerDisplayname,
      int sentenceIndex,
      int wordIndex,
      string layerValue)
    {
      return SetDocumentLayerValueMask(
                                       documentGuid,
                                       (from x in _corpus.Layers where x.Value == layerDisplayname select x.Key)
                                      .FirstOrDefault(),
                                       sentenceIndex,
                                       wordIndex,
                                       layerValue);
    }

    public override void SetDocumentMetadata(Guid documentGuid, Dictionary<string, object> metadata)
    {
      var doc = _db.GetDocument(documentGuid);
      if (doc == null)
        return;
      doc.Metadata = metadata;
      _db.Update(doc);
    }

    public override void SetNewDocumentMetadata(string metadataKey, Type type)
    {
      if (!type.IsSerializable)
        throw new SerializationException(Resources.SetDocumentMetadata_SerializerException);

      foreach (var d in _corpus.Documents)
      {
        var doc = _db.GetDocument(d);
        if (doc.Metadata.ContainsKey(metadataKey))
          continue;
        doc.Metadata.Add(metadataKey, Activator.CreateInstance(type));
        _db.Update(doc);
      }
    }
  }
}