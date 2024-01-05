using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using CorpusExplorer.Sdk.Db.Core.Model.SimpleBinary;
using CorpusExplorer.Sdk.Db.Core.Model.SimpleBinary.Manager;
using CorpusExplorer.Sdk.Db.Core.Properties;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using Corpus = CorpusExplorer.Sdk.Db.Core.Model.SimpleBinary.Corpus;
using Layer = CorpusExplorer.Sdk.Db.Core.Model.SimpleBinary.Layer;

namespace CorpusExplorer.Sdk.Db.Core.Adapter
{
  public class CorpusAdapterEntityFramework : AbstractCorpusAdapter
  {
    private Corpus _corpus;
    private CoreBinaryContext _db;

    private CorpusAdapterEntityFramework() { }

    public override IEnumerable<Concept> Concepts
      => null; // TODO: Konzepte werden von EntityFramework aktuell nicht unterstützt

    public override string CorpusDisplayname
    {
      get => _corpus.Displayname;
      set => _corpus.Displayname = value;
    }

    public override Guid CorpusGuid => _corpus.CorpusId;

    public override IEnumerable<Guid> DocumentGuids
      => new HashSet<Guid>(from x in _corpus.Documents select x.DocumentId);

    public override IEnumerable<KeyValuePair<Guid, Dictionary<string, object>>> DocumentMetadata
      => _corpus.Documents.ToDictionary(x => x.DocumentId, x => x.Metadata);

    public override Guid FirstDocument
      => _corpus.Documents.FirstOrDefault().DocumentId;

    public override IEnumerable<string> LayerDisplaynames
      => from x in _corpus.Layers select x.Displayname;

    public override IEnumerable<KeyValuePair<Guid, string>> LayerGuidAndDisplaynames
      => _corpus.Layers.ToDictionary(x => x.LayerId, x => x.Displayname);

    public override IEnumerable<Guid> LayerGuids
      => from x in _corpus.Layers select x.LayerId;

    public override IEnumerable<AbstractLayerAdapter> Layers
      => from x in _corpus.Layers select LayerAdapterEntityFramework.Create(_db, x);

    public override IEnumerable<string> LayerUniqueDisplaynames
      => new HashSet<string>(from x in _corpus.Layers select x.Displayname);

    public override bool UseCompression
      => false;

    public override AbstractCorpusBuilder GetCorpusBuilder() => new CorpusBuilderAdoDotNet();

    public override void AddConcept(Concept concept)
    {
      // TODO: Konzepte werden von EntityFramework aktuell nicht unterstützt
    }

    public override void AddLayer(AbstractLayerAdapter layer)
    {
      // LayerAdapterEntityFramework.Create führt alles aus was notwendig ist, um zu diesem Korpus hinzugefügt zu werden.
    }

    public override bool ContainsDocument(Guid documentGuid)
      => (from x in _corpus.Documents select x).Any(x => x.DocumentId == documentGuid);

    public override bool ContainsLayer(Guid layerGuid)
      => (from x in _corpus.Layers select x).Any(x => x.LayerId == layerGuid);

    public override bool ContainsLayer(string layerDisplayname)
      => (from x in _corpus.Layers select x).Any(x => x.Displayname == layerDisplayname);

    public static CorpusAdapterEntityFramework Create(
      string displayname,
      Dictionary<Guid, Dictionary<string, object>> documentMetadata,
      Dictionary<string, object> corpusMetadata,
      List<Concept> concepts)
    {
      var context = CoreBinaryContextManager.GetContext();

      // Der folgende try-catch-block sorgt dafür das die Datenbank korrekt erstellt wird, falls diese noch nicht exsistiert.
      Corpus corpus;
      try
      {
        corpus = context.CorpusSet.Add(
                          new Corpus
                          {
                            CorpusId = Guid.NewGuid(),
                            Displayname = displayname,
                            Metadata = corpusMetadata ?? new Dictionary<string, object>()
                          });
        context.SaveChangesAsync();
      }
      catch
      {
        corpus = context.CorpusSet.Add(
                          new Corpus
                          {
                            CorpusId = Guid.NewGuid(),
                            Displayname = displayname,
                            Metadata = corpusMetadata ?? new Dictionary<string, object>()
                          });
        context.SaveChangesAsync();
      }

      var meta = documentMetadata.ToDictionary(
        m => m.Key,
        m => new Document
        {
          CorpusId = corpus.CorpusId,
          DocumentId = m.Key,
          Metadata = m.Value,
          SentenceCount = 0,
          TokenCount = 0
        });

      foreach (var m in meta)
        context.DocumentSet.Add(m.Value);

      context.SaveChanges();

      return Create(context, corpus.CorpusId);
    }

    public static CorpusAdapterEntityFramework Create(CoreBinaryContext context, Guid corpusGuid)
    {
      var corpus = (from x in context.CorpusSet where x.CorpusId == corpusGuid select x).FirstOrDefault();
      if (corpus == null)
        return null;

      return new CorpusAdapterEntityFramework
      {
        _db = context,
        _corpus = corpus
      };
    }

    public override IEnumerable<Guid> FindDocumentByMetadata(Dictionary<string, object> example)
      => from d in _corpus.Documents
         let meta = d.Metadata
         where example.All(x => meta.ContainsKey(x.Key) && (meta[x.Key] == x.Value))
         select d.DocumentId;

    public override IEnumerable<KeyValuePair<string, object>> GetCorpusMetadata() => _corpus.Metadata;

    public override int GetDocumentLengthInSentences(Guid documentGuid)
      => (from x in _corpus.Documents where x.DocumentId == documentGuid select x.SentenceCount).FirstOrDefault();

    public override int GetDocumentLengthInWords(Guid documentGuid)
      => (from x in _corpus.Documents where x.DocumentId == documentGuid select x.TokenCount).FirstOrDefault();

    public override Dictionary<string, object> GetDocumentMetadata(Guid documentGuid)
      => (from x in _corpus.Documents where x.DocumentId == documentGuid select x.Metadata).FirstOrDefault();

    public override Dictionary<string, HashSet<object>> GetDocumentMetadataPrototype()
    {
      var res = new Dictionary<string, HashSet<object>>();

      foreach (var meta in _corpus.Documents.SelectMany(doc => doc.Metadata))
      {
        HashSet<object> value;
        if (!res.TryGetValue(meta.Key, out value))
          res.Add(meta.Key, new HashSet<object> {meta.Value});
        else
        {
          if (!value.Contains(meta.Value))
            value.Add(meta.Value);
        }
      }

      return res;
    }

    public override IEnumerable<string> GetDocumentMetadataPrototypeOnlyProperties()
    {
      return new HashSet<string>(_corpus.Documents.SelectMany(doc => doc.Metadata).Select(meta => meta.Key));
    }

    public override IEnumerable<object> GetDocumentMetadataPrototypeOnlyPropertieValues(string property)
    {
      return
        new HashSet<object>(
          from document in _corpus.Documents
          where document.Metadata.ContainsKey(property)
          select document.Metadata[property]);
    }
    
    public override AbstractLayerAdapter GetLayer(Guid layerGuid)
      =>
      layerGuid == Guid.Empty
        ? null
        : (from x in _corpus.Layers where x.LayerId == layerGuid select LayerAdapterEntityFramework.Create(_db, x))
          .FirstOrDefault();

    public override AbstractLayerAdapter GetLayerOfDocument(Guid documentGuid, string layerDisplayname)
      => (from l in _corpus.Layers
          where l.Displayname == layerDisplayname
          from d in l.LayerDocuments
          where d.LayerDocumentId == documentGuid
          select LayerAdapterEntityFramework.Create(_db, l)).FirstOrDefault();

    public override IEnumerable<AbstractLayerAdapter> GetLayers(string displayname)
      => from x in _corpus.Layers where x.Displayname == displayname select LayerAdapterEntityFramework.Create(_db, x);

    public override IEnumerable<AbstractLayerAdapter> GetLayersOfDocument(Guid documentGuid)
      => from x in _corpus.Layers where x.LayerId == documentGuid select LayerAdapterEntityFramework.Create(_db, x);

    public override IEnumerable<string> GetLayerValues(string layerDisplayname)
    {
      var layers = from x in _corpus.Layers where x.Displayname == layerDisplayname select x;

      var res = new HashSet<string>();
      foreach (var layer in layers)
      {
        var values = layer.Dictionary.Values;
        foreach (var x in values)
          res.Add(x);
      }

      return res;
    }

    public override IEnumerable<string> GetLayerValues(Guid layerGuid)
      => (from x in _corpus.Layers where x.LayerId == layerGuid select x).FirstOrDefault()?.Dictionary.Values;

    public override IEnumerable<IEnumerable<string>> GetReadableDocument(Guid documentGuid, string layerDisplayname)
      =>
      GetReadableDocument(
        documentGuid,
        (from x in _corpus.Layers where x.Displayname == layerDisplayname select x.LayerId).FirstOrDefault());

    public override IEnumerable<IEnumerable<string>> GetReadableDocument(Guid documentGuid, Guid layerGuid)
      => GetLayer(layerGuid).GetReadableDocumentByGuid(documentGuid);

    public override IEnumerable<IEnumerable<string>> GetReadableDocumentSnippet(
        Guid documentGuid,
        string layerDisplayname,
        int start,
        int stop)
      =>
      GetLayer((from x in _corpus.Layers where x.Displayname == layerDisplayname select x.LayerId).FirstOrDefault())
        .GetReadableDocumentByGuid(documentGuid);

    public override Dictionary<string, IEnumerable<IEnumerable<string>>> GetReadableMultilayerDocument(
      Guid documentGuid)
    {
      var res = new Dictionary<string, IEnumerable<IEnumerable<string>>>();

      foreach (var l in _corpus.Layers)
      {
        var layer = GetLayer(l.LayerId);
        var doc = layer.GetReadableDocumentByGuid(documentGuid);
        if (doc != null)
          res.Add(l.Displayname, doc);
      }

      return res;
    }

    public override void LayerCopy(string layerDisplaynameOriginal, string layerDisplaynameCopy)
    {
      var layer =
        GetLayer(
          (from x in _corpus.Layers where x.Displayname == layerDisplaynameOriginal select x.LayerId).FirstOrDefault());
      var nguid = layer.Copy().Guid;
      var nlayer = (from x in _corpus.Layers where x.LayerId == nguid select x).FirstOrDefault();
      nlayer.Displayname = layerDisplaynameCopy;
      _db.SaveChangesAsync();
    }

    public override void LayerDelete(string layerDisplayname)
    {
      var layer = _corpus.Layers.FirstOrDefault(l => l.Displayname == layerDisplayname);
      if (layer == null)
        return;
      _db.LayerSet.Remove(layer);
      _db.SaveChangesAsync();
    }

    public override void LayerNew(string layerDisplayname)
    {
      _db.LayerSet.Add(
           new Layer
           {
             CorpusId = _corpus.CorpusId,
             Dictionary = new CeDictionary(new Dictionary<string, int>()),
             Displayname = layerDisplayname,
             LayerId = Guid.NewGuid()
           });
      _db.SaveChanges();
    }

    public override void LayerRename(string layerDisplaynameOld, string layerDisplaynameNew)
    {
      var layer = _corpus.Layers.FirstOrDefault(l => l.Displayname == layerDisplaynameOld);
      if (layer == null)
        return;
      layer.Displayname = layerDisplaynameNew;
      _db.SaveChangesAsync();
    }

    public override void LayerValueDelete(string layerDisplayname, string layerValue)
    {
      var layer = _corpus.Layers.FirstOrDefault(l => l.Displayname == layerDisplayname);
      if (layer == null)
        return;

      var dic = layer.Dictionary;
      dic.Remove(layerValue);
      layer.Dictionary = dic;

      _db.SaveChangesAsync();
    }

    public override void LayerValueNew(string layerDisplayname, string layerValue)
    {
      var layer = _corpus.Layers.FirstOrDefault(l => l.Displayname == layerDisplayname);
      if (layer == null)
        return;

      var dic = layer.Dictionary;
      dic.Add(layerValue);
      layer.Dictionary = dic;

      _db.SaveChangesAsync();
    }

    public override void LayerValueRename(string layerDisplayname, string layerValueOld, string layerValueNew)
    {
      var layer = _corpus.Layers.FirstOrDefault(l => l.Displayname == layerDisplayname);
      if (layer == null)
        return;

      var dic = layer.Dictionary;
      dic.RenameValue(layerValueOld, layerValueNew);
      layer.Dictionary = dic;

      _db.SaveChangesAsync();
    }

    public override bool RemoveConcept(Concept concept)
    {
      // TODO: Konzepte werden von EntityFramework aktuell nicht unterstützt
      return false;
    }

    public override void ResetAllDocumentMetadata(Dictionary<Guid, Dictionary<string, object>> newMetadata)
    {
      foreach (var x in _corpus.Documents)
      {
        if (!newMetadata.ContainsKey(x.DocumentId))
          continue;
        x.Metadata = newMetadata[x.DocumentId];
        _db.SaveChangesAsync();
      }
    }

    public override void Save(string path, bool useCompression) { _db.SaveChangesAsync(); }

    public override void SetCorpusMetadata(string key, object value)
    {
      if (_corpus.Metadata.ContainsKey(key))
        _corpus.Metadata[key] = value;
      else
        _corpus.Metadata.Add(key, value);

      _db.SaveChanges();
    }

    public override bool SetDocumentLayerValueMask(
      Guid documentGuid,
      Guid layerGuid,
      int sentenceIndex,
      int wordIndex,
      string layerValue)
    {
      var layer = GetLayer(layerGuid);
      return (layer != null)
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
        (from x in _corpus.Layers where x.Displayname == layerDisplayname select x.LayerId).FirstOrDefault(),
        sentenceIndex,
        wordIndex,
        layerValue);
    }

    public override void SetDocumentMetadata(Guid documentGuid, Dictionary<string, object> metadata)
    {
      var doc = (from x in _corpus.Documents where x.DocumentId == documentGuid select x).FirstOrDefault();
      if (doc == null)
        return;
      doc.Metadata = metadata;
      _db.SaveChangesAsync();
    }

    public override void SetNewDocumentMetadata(string metadataKey, Type type)
    {
      if (!type.IsSerializable)
        throw new SerializationException(Resources.SetDocumentMetadata_SerializerException);

      foreach (var document in _corpus.Documents)
      {
        var meta = document.Metadata;
        if (meta.ContainsKey(metadataKey))
          continue;
        meta.Add(metadataKey, Activator.CreateInstance(type));
        document.Metadata = meta;
        _db.SaveChangesAsync();
      }
    }
  }
}