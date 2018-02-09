using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using CorpusExplorer.Sdk.Db.LinqConnect.Model;
using CorpusExplorer.Sdk.Db.LinqConnect.Serializer;
using CorpusExplorer.Sdk.Db.MySql.Builder;
using CorpusExplorer.Sdk.Db.MySQL.Model;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using Devart.Data.Linq;
using Corpus = CorpusExplorer.Sdk.Db.MySQL.Model.Corpus;
using Layer = CorpusExplorer.Sdk.Db.MySQL.Model.Layer;
using DataContext = CorpusExplorer.Sdk.Db.MySQL.Model.DataContext;

namespace CorpusExplorer.Sdk.Db.MySql.Adapter
{
  public class CorpusAdapterLinqConnect : AbstractCorpusAdapter
  {
    private Corpus _corpus;
    private DataContext _db;

    private CorpusAdapterLinqConnect() { }

    public override IEnumerable<Concept> Concepts
      => null; // TODO: Konzepte werden von EntityFramework aktuell nicht unterstützt

    public override string CorpusDisplayname
    {
      get => _corpus.Displayname;
      set => _corpus.Displayname = value;
    }

    public override Guid CorpusGuid => _corpus.GUID;

    public override IEnumerable<Guid> DocumentGuids
      => new HashSet<Guid>(from x in _corpus.Documents select x.GUID);

    public override IEnumerable<KeyValuePair<Guid, Dictionary<string, object>>> DocumentMetadata
      => _corpus.Documents.ToDictionary(x => x.GUID, x => x.DocumentMetadataEntries.ToDictionary(y => y.Label, y => ValueSerializer.DeserializeValue(y.Value)));

    public override Guid FirstDocument
      => _corpus.Documents.FirstOrDefault().GUID;

    public override IEnumerable<string> LayerDisplaynames
      => from x in _corpus.Layers select x.Displayname;

    public override IEnumerable<KeyValuePair<Guid, string>> LayerGuidAndDisplaynames
      => _corpus.Layers.ToDictionary(x => x.GUID, x => x.Displayname);

    public override IEnumerable<Guid> LayerGuids
      => from x in _corpus.Layers select x.GUID;

    public override IEnumerable<AbstractLayerAdapter> Layers
      => from x in _corpus.Layers select LayerAdapterLinqConnect.Create(_db, x);

    public override IEnumerable<string> LayerUniqueDisplaynames
      => new HashSet<string>(from x in _corpus.Layers select x.Displayname);

    public override bool UseCompression
      => false;

    internal int DbIndex => _corpus.ID;

    public override AbstractCorpusBuilder GetCorpusBuilder() => new CorpusBuilderMySql();

    public override void AddConcept(Concept concept)
    {
      // TODO: Konzepte werden von LinqConnect aktuell nicht unterstützt
    }

    public override void AddLayer(AbstractLayerAdapter layer)
    {
      // LayerAdapterLinqConnect.Create führt alles aus was notwendig ist, um zu diesem Korpus hinzugefügt zu werden.
    }

    public override bool ContainsDocument(Guid documentGuid)
      => (from x in _corpus.Documents select x).Any(x => x.GUID == documentGuid);

    public override bool ContainsLayer(Guid layerGuid)
      => (from x in _corpus.Layers select x).Any(x => x.GUID == layerGuid);

    public override bool ContainsLayer(string layerDisplayname)
      => (from x in _corpus.Layers select x).Any(x => x.Displayname == layerDisplayname);

    public static CorpusAdapterLinqConnect Create(
      string displayname,
      Dictionary<Guid, Dictionary<string, object>> documentMetadata,
      Dictionary<string, object> corpusMetadata,
      List<Concept> concepts)
    {
      var context = new DataContext(LinqConnectConfiguration.ConnectionString);
      if (!context.DatabaseExists())
        context.CreateDatabase(true, true);

      var corpus = new Corpus
      {
        GUID = Guid.NewGuid(),
        Displayname = displayname
      };
      context.Corpora.InsertOnSubmit(corpus);
      context.SubmitChanges(ConflictMode.ContinueOnConflict);

      foreach (var doc in documentMetadata)
        context.Documents.InsertOnSubmit(new Document
        {
          CorpusID = corpus.ID,
          CountSentences = 0,
          CountToken = 0,
          GUID = doc.Key
        });
      context.SubmitChanges(ConflictMode.ContinueOnConflict);

      foreach (var doc in documentMetadata)
      {
        var ndoc = (from x in context.Documents where x.GUID == doc.Key select x.ID).FirstOrDefault();

        foreach (var entry in doc.Value)
          context.DocumentMetadataEntries.InsertOnSubmit(
            new DocumentMetadataEntry
            {
              DocumentID = ndoc,
              Label = entry.Key,
              Value = ValueSerializer.SerializeValue(entry.Value)
            });
      }
      context.SubmitChanges(ConflictMode.ContinueOnConflict);

      return Create(context, corpus.GUID);
    }

    public static CorpusAdapterLinqConnect Create(DataContext context, Guid corpusGuid)
    {
      var corpus = (from x in context.Corpora where x.GUID == corpusGuid select x).FirstOrDefault();
      if (corpus == null)
        return null;

      return new CorpusAdapterLinqConnect
      {
        _db = context,
        _corpus = corpus
      };
    }

    public static CorpusAdapterLinqConnect[] Create()
    {
      var context = new DataContext(LinqConnectConfiguration.ConnectionString);
      var corpora = context.Corpora;
      if (corpora == null || !corpora.Any())
        return null;

      var res = new List<CorpusAdapterLinqConnect>();
      foreach (var corpus in corpora)
      {
        if (corpus == null)
          continue;

        try
        {
          res.Add(new CorpusAdapterLinqConnect
          {
            _db = context,
            _corpus = corpus
          });
        }
        catch
        {
          // ignore
        }
      }

      return res.ToArray();
    }

    public override IEnumerable<Guid> FindDocumentByMetadata(Dictionary<string, object> example)
    {
      return (from doc in _corpus.Documents
              let meta = doc.DocumentMetadataEntries.Where(x => example.ContainsKey(x.Label)).ToArray()
              where meta.Length == example.Count
              where meta.All(entry => example.ContainsKey(entry.Label) && example[entry.Label] == entry.Value)
              select doc.GUID);
    }

    public override IEnumerable<KeyValuePair<string, object>> GetCorpusMetadata() => _corpus.CorpusMetadataEntries.ToDictionary(x => x.Label, x => ValueSerializer.DeserializeValue(x.Value));

    public override int GetDocumentLengthInSentences(Guid documentGuid)
      => (from x in _corpus.Documents where x.GUID == documentGuid select x.CountSentences).FirstOrDefault();

    public override int GetDocumentLengthInWords(Guid documentGuid)
      => (from x in _corpus.Documents where x.GUID == documentGuid select x.CountToken).FirstOrDefault();

    public override Dictionary<string, object> GetDocumentMetadata(Guid documentGuid)
    {
      try
      {
        return (from x in _corpus.Documents where x.GUID == documentGuid from y in x.DocumentMetadataEntries select y).ToDictionary(y => y.Label, y => ValueSerializer.DeserializeValue(y.Value));
      }
      catch
      {
        return null;
      }
    }

    public override Dictionary<string, HashSet<object>> GetDocumentMetadataPrototype()
    {
      var res = new Dictionary<string, HashSet<object>>();

      foreach (var doc in _corpus.Documents)
        foreach (var meta in doc.DocumentMetadataEntries)
          if (res.ContainsKey(meta.Label))
            res[meta.Label].Add(ValueSerializer.DeserializeValue(meta.Value));
          else
            res.Add(meta.Label, new HashSet<object> { ValueSerializer.DeserializeValue(meta.Value) });

      return res;
    }

    public override IEnumerable<string> GetDocumentMetadataPrototypeOnlyProperties()
      => new HashSet<string>(from doc in _corpus.Documents
                             from entry in doc.DocumentMetadataEntries
                             select entry.Label);

    public override IEnumerable<object> GetDocumentMetadataPrototypeOnlyPropertieValues(string property)
      => new HashSet<object>(from doc in _corpus.Documents
                             from entry in doc.DocumentMetadataEntries
                             where entry.Label == property
                             select entry.Value);

    public override AbstractLayerAdapter GetLayer(Guid layerGuid)
      =>
      layerGuid == Guid.Empty
        ? null
        : (from x in _corpus.Layers where x.GUID == layerGuid select LayerAdapterLinqConnect.Create(_db, x))
          .FirstOrDefault();

    public override AbstractLayerAdapter GetLayerOfDocument(Guid documentGuid, string layerDisplayname)
      => (from l in _corpus.Layers where l.Displayname == layerDisplayname from d in l.LayerDocuments where d.Document != null && d.Document.GUID == documentGuid select LayerAdapterLinqConnect.Create(_db, l)).FirstOrDefault();

    public override IEnumerable<AbstractLayerAdapter> GetLayers(string displayname)
      => from x in _corpus.Layers where x.Displayname == displayname select LayerAdapterLinqConnect.Create(_db, x);

    public override IEnumerable<AbstractLayerAdapter> GetLayersOfDocument(Guid documentGuid)
      => from x in _corpus.Layers where x.GUID == documentGuid select LayerAdapterLinqConnect.Create(_db, x);

    public override IEnumerable<string> GetLayerValues(string layerDisplayname)
    {
      var layers = from x in _corpus.Layers where x.Displayname == layerDisplayname select x;

      var res = new HashSet<string>();
      foreach (var layer in layers)
        foreach (var x in layer.LayerDictionaryEntries.Select(x => x.Value))
          res.Add(x);

      return res;
    }

    public override IEnumerable<string> GetLayerValues(Guid layerGuid)
      => (from x in _corpus.Layers where x.GUID == layerGuid select x).FirstOrDefault()?.LayerDictionaryEntries.Select(x => x.Value);

    public override IEnumerable<IEnumerable<string>> GetReadableDocument(Guid documentGuid, string layerDisplayname)
      =>
      GetReadableDocument(
        documentGuid,
        (from x in _corpus.Layers where x.Displayname == layerDisplayname select x.GUID).FirstOrDefault());

    public override IEnumerable<IEnumerable<string>> GetReadableDocument(Guid documentGuid, Guid layerGuid)
      => GetLayer(layerGuid).GetReadableDocumentByGuid(documentGuid);

    public override IEnumerable<IEnumerable<string>> GetReadableDocumentSnippet(
        Guid documentGuid,
        string layerDisplayname,
        int start,
        int stop)
      =>
      GetLayer((from x in _corpus.Layers where x.Displayname == layerDisplayname select x.GUID).FirstOrDefault())
        .GetReadableDocumentByGuid(documentGuid);

    public override Dictionary<string, IEnumerable<IEnumerable<string>>> GetReadableMultilayerDocument(
      Guid documentGuid)
    {
      var res = new Dictionary<string, IEnumerable<IEnumerable<string>>>();

      foreach (var l in _corpus.Layers)
      {
        var layer = GetLayer(l.GUID);
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
          (from x in _corpus.Layers where x.Displayname == layerDisplaynameOriginal select x.GUID).FirstOrDefault());
      var nguid = layer.Copy().Guid;
      var nlayer = (from x in _corpus.Layers where x.GUID == nguid select x).FirstOrDefault();
      nlayer.Displayname = layerDisplaynameCopy;
      _db.SubmitChanges();
    }

    public override void LayerDelete(string layerDisplayname)
    {
      var layer = _corpus.Layers.FirstOrDefault(l => l.Displayname == layerDisplayname);
      if (layer == null)
        return;
      _db.Layers.DeleteOnSubmit(layer);
      _db.SubmitChanges();
    }

    public override void LayerNew(string layerDisplayname)
    {
      _db.Layers.InsertOnSubmit(
           new Layer
           {
             CorpusID = _corpus.ID,
             Displayname = layerDisplayname,
             GUID = Guid.NewGuid()
           });
      _db.SubmitChanges();
    }

    public override void LayerRename(string layerDisplaynameOld, string layerDisplaynameNew)
    {
      var layer = _corpus.Layers.FirstOrDefault(l => l.Displayname == layerDisplaynameOld);
      if (layer == null)
        return;
      layer.Displayname = layerDisplaynameNew;
      _db.SubmitChanges();
    }

    public override bool RemoveConcept(Concept concept)
    {
      // TODO: Konzepte werden von EntityFramework aktuell nicht unterstützt
      return false;
    }

    public override void ResetAllDocumentMetadata(Dictionary<Guid, Dictionary<string, object>> newMetadata)
    {
      foreach (var nmeta in newMetadata)
      {
        var doc = (from x in _db.Documents where x.GUID == nmeta.Key select x).First();
        _db.DocumentMetadataEntries.DeleteAllOnSubmit(doc.DocumentMetadataEntries);
        foreach (var x in nmeta.Value)
          _db.DocumentMetadataEntries.InsertOnSubmit(new DocumentMetadataEntry
          {
            DocumentID = doc.ID,
            Label = x.Key,
            Value = ValueSerializer.SerializeValue(x.Value)
          });

        _db.SubmitChanges();
      }
    }

    public override void Save(string path, bool useCompression) { _db.SubmitChanges(); }

    public override void SetCorpusMetadata(string key, object value)
    {
      var meta = (from x in _corpus.CorpusMetadataEntries where x.Label == key select x).FirstOrDefault();
      if (meta == null)
        _db.CorpusMetadataEntries.InsertOnSubmit(new CorpusMetadataEntry
        {
          CorpusID = _corpus.ID,
          Label = key,
          Value = ValueSerializer.SerializeValue(value)
        });
      else
        meta.Value = ValueSerializer.SerializeValue(value);

      _db.SubmitChanges();
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
        (from x in _corpus.Layers where x.Displayname == layerDisplayname select x.GUID).FirstOrDefault(),
        sentenceIndex,
        wordIndex,
        layerValue);
    }

    public override void SetDocumentMetadata(Guid documentGuid, Dictionary<string, object> metadata)
    {
      var doc = (from x in _corpus.Documents where x.GUID == documentGuid select x).FirstOrDefault();
      if (doc == null)
        return;

      foreach (var x in metadata)
      {
        var exsits = (from y in doc.DocumentMetadataEntries where y.Label == x.Key select y).FirstOrDefault();
        if (exsits == null)
          _db.CorpusMetadataEntries.InsertOnSubmit(
            new CorpusMetadataEntry
            {
              CorpusID = _corpus.ID,
              Label = x.Key,
              Value = ValueSerializer.SerializeValue(x.Value)
            });
        else
          exsits.Value = ValueSerializer.SerializeValue(x.Value);
      }
      _db.SubmitChanges();
    }

    public override void SetNewDocumentMetadata(string metadataKey, Type type)
    {
      if (!type.IsSerializable)
        throw new SerializationException($"Der Typ {type} is als nicht serialisierbar gekennzeichnet");

      foreach (var document in _corpus.Documents)
      {
        var exsits = (from y in document.DocumentMetadataEntries where y.Label == metadataKey select y).FirstOrDefault();
        if (exsits != null)
          _db.DocumentMetadataEntries.InsertOnSubmit(
            new DocumentMetadataEntry
            {
              DocumentID = document.ID,
              Label = metadataKey,
              Value = ValueSerializer.SerializeValue(Activator.CreateInstance(type))
            });
      }
      _db.SubmitChanges();
    }
  }
}