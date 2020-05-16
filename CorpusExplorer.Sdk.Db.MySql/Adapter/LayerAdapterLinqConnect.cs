#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Db.LinqConnect.Model;
using CorpusExplorer.Sdk.Db.MySQL.Model;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;
using Devart.Data.Linq;
using DataContext = CorpusExplorer.Sdk.Db.MySQL.Model.DataContext;
using Layer = CorpusExplorer.Sdk.Db.MySQL.Model.Layer;

#endregion

namespace CorpusExplorer.Sdk.Db.MySql.Adapter
{
  public class LayerAdapterLinqConnect : AbstractLayerAdapter
  {
    private DataContext _db;
    private int _dbIndex;
    private Layer _layer;

    private LayerAdapterLinqConnect()
    {
    }

    public override int CountDocuments
      => _layer.LayerDocuments.Count;

    public override int CountValues
      => _layer.LayerDictionaryEntries.Count;

    public override IEnumerable<Guid> DocumentGuids
      => from x in _layer.LayerDocuments select x.Document.GUID;

    public override string this[int index]
      => (from x in _layer.LayerDictionaryEntries where x.Index == index select x.Value).SingleOrDefault();

    public override int this[string index]
      => (from x in _layer.LayerDictionaryEntries where x.Value == index select x.Index).SingleOrDefault();

    public override int[][] this[Guid guid]
    {
      get => (from x in _layer.LayerDocuments
              where x.Document.GUID == guid
              select DocumentSerializerHelper.Deserialize(x.Content)).FirstOrDefault();
      set
      {
        var doc = (from x in _layer.LayerDocuments where x.Document.GUID == guid select x).FirstOrDefault();
        doc.Content = DocumentSerializerHelper.Serialize(value);
        _db.SubmitChanges();
      }
    }

    public override IEnumerable<string> Values
      => from x in _layer.LayerDictionaryEntries select x.Value;

    public override bool ContainsDocument(Guid guid)
    {
      return _layer.LayerDocuments.Any(x => x.Document.GUID == guid);
    }

    public override AbstractLayerAdapter Copy()
    {
      var layer = new Layer
      {
        CorpusID = _layer.CorpusID,
        Displayname = _layer.Displayname,
        GUID = Guid.NewGuid()
      };
      _db.Layers.InsertOnSubmit(layer);
      _db.SubmitChanges();

      foreach (var d in _layer.LayerDocuments)
        _db.LayerDocuments.InsertOnSubmit(
                                          new LayerDocument
                                          {
                                            Content = d.Content,
                                            LayerID = layer.ID,
                                            DocumentID = d.DocumentID
                                          });
      _db.SubmitChanges();

      foreach (var e in _layer.LayerDictionaryEntries)
        _db.LayerDictionaryEntries.InsertOnSubmit(
                                                  new LayerDictionaryEntry
                                                  {
                                                    Index = e.Index,
                                                    LayerID = layer.ID,
                                                    Value = e.Value
                                                  });
      _db.SubmitChanges();

      return new LayerAdapterLinqConnect
      {
        _db = _db,
        Displayname = layer.Displayname,
        _guid = layer.GUID,
        _layer = layer,
        _dbIndex = layer.ID
      };
    }

    public override AbstractLayerAdapter Copy(Guid documentGuid)
    {
      var layer = new Layer
      {
        CorpusID = _layer.CorpusID,
        Displayname = _layer.Displayname,
        GUID = Guid.NewGuid()
      };
      _db.Layers.InsertOnSubmit(layer);
      _db.SubmitChanges();

      var d = (from x in _layer.LayerDocuments where x.Document.GUID == documentGuid select x).SingleOrDefault();
      _db.LayerDocuments.InsertOnSubmit(
                                        new LayerDocument
                                        {
                                          Content = d.Content,
                                          LayerID = layer.ID,
                                          DocumentID = d.DocumentID
                                        });
      _db.SubmitChanges();

      foreach (var e in _layer.LayerDictionaryEntries)
        _db.LayerDictionaryEntries.InsertOnSubmit(
                                                  new LayerDictionaryEntry
                                                  {
                                                    Index = e.Index,
                                                    LayerID = layer.ID,
                                                    Value = e.Value
                                                  });
      _db.SubmitChanges();

      return new LayerAdapterLinqConnect
      {
        _db = _db,
        Displayname = layer.Displayname,
        _guid = layer.GUID,
        _dbIndex = layer.ID,
        _layer = layer
      };
    }

    public static AbstractLayerAdapter Create(AbstractCorpusAdapter corpus, AbstractLayerState layer)
    {
      var context = new DataContext(LinqConnectConfiguration.ConnectionString);
      var corpusID = ((CorpusAdapterLinqConnect) corpus).DbIndex;

      var layerSet = new Layer
      {
        GUID = Guid.NewGuid(),
        CorpusID = corpusID,
        Displayname = layer.Displayname
      };
      context.Layers.InsertOnSubmit(layerSet);
      context.SubmitChanges(ConflictMode.ContinueOnConflict);

      foreach (var d in layer.Documents)
      {
        var doc =
          (from x in context.Documents where x.GUID == d.Key && x.CorpusID == corpusID select x).FirstOrDefault();
        if (doc == null)
          continue;

        if (doc.CountToken == 0)
        {
          doc.CountSentences = d.Value.Length;
          doc.CountToken = d.Value.SelectMany(s => s).Count();
        }

        context.LayerDocuments.InsertOnSubmit(
                                              new LayerDocument
                                              {
                                                Content = DocumentSerializerHelper.Serialize(d.Value),
                                                LayerID = layerSet.ID,
                                                DocumentID = doc.ID
                                              });
      }

      context.SubmitChanges(ConflictMode.ContinueOnConflict);

      foreach (var v in layer.Cache)
        context.LayerDictionaryEntries.InsertOnSubmit(new LayerDictionaryEntry
        {
          LayerID = layerSet.ID,
          Index = v.Value,
          Value = v.Key
        });
      context.SubmitChanges(ConflictMode.ContinueOnConflict);

      return Create(context, layerSet);
    }

    public static AbstractLayerAdapter Create(DataContext db, Layer layer)
    {
      return new LayerAdapterLinqConnect
      {
        _db = db,
        _layer = layer,
        Displayname = layer.Displayname,
        _guid = layer.GUID,
        _dbIndex = layer.ID
      };
    }

    public override Dictionary<Guid, int[][]> GetDocumentDictionary()
    {
      return _layer.LayerDocuments.ToDictionary(x => x.Document.GUID,
                                                x => DocumentSerializerHelper.Deserialize(x.Content));
    }

    public override IEnumerable<IEnumerable<bool>> GetDocumentLayervalueMask(Guid documentGuid, string layerValue)
    {
      var val = this[layerValue];
      if (val == -1)
        return null;

      var doc = this[documentGuid];

      return doc?.Select(s => s.Select(w => w == val));
    }

    public override IEnumerable<IEnumerable<string>> GetReadableDocumentByGuid(Guid documentGuid)
    {
      var doc = this[documentGuid];
      return doc == null ? null : from s in doc where s != null select s.Select(w => this[w]);
    }

    public override IEnumerable<IEnumerable<string>> GetReadableDocumentSnippetByGuid(
      Guid documentGuid,
      int start,
      int stop)
    {
      var doc = this[documentGuid];
      if (doc == null)
        return null;

      start = start < 0 ? 0 : start;
      stop = stop   >= doc.Length ? doc.Length - 1 : stop;
      stop = stop   <= start ? start           + 1 : stop;

      var res = new List<IEnumerable<string>>();
      for (var i = start; i < stop; i++)
        res.Add(doc[i].Select(w => this[w]));

      return res;
    }

    protected override CeDictionary GetValueDictionary()
    {
      return new CeDictionary(ReciveRawLayerDictionary());
    }

    public override Dictionary<string, int> ReciveRawLayerDictionary()
    {
      return _layer.LayerDictionaryEntries.ToDictionary(x => x.Value, x => x.Index);
    }

    public override Dictionary<int, string> ReciveRawReverseLayerDictionary()
    {
      return _layer.LayerDictionaryEntries.ToDictionary(x => x.Index, x => x.Value);
    }

    public override void RefreshDictionaries()
    {
    }

    public override void ResetRawLayerDictionary(Dictionary<string, int> dictionary)
    {
      throw new NotImplementedException();
    }

    public override void ResetRawReverseLayerDictionary(Dictionary<int, string> reverse)
    {
      throw new NotImplementedException();
    }

    public override bool SetDocumentLayerValueMaskBySwitch(
      Guid documentGuid,
      int sentenceIndex,
      int wordIndex,
      string value)
    {
      // Prüfe ob Wert bereits vorhanden, wenn nicht, füge hinzu.
      var entry = (from x in _layer.LayerDictionaryEntries where x.Value == value select x).FirstOrDefault();
      if (entry == null)
      {
        entry = new LayerDictionaryEntry
        {
          LayerID = _dbIndex,
          Value = value
        };
        _db.LayerDictionaryEntries.InsertOnSubmit(entry);
        _db.SubmitChanges();
      }

      // Rufe value/idx sowie das Dokument ab
      var idx = entry.Index;
      var doc = this[documentGuid];
      if (doc == null)
        return false;

      // Überprüfe Überlauf der Indices sentenceIndex und wordIndex
      if (sentenceIndex >= doc.Length)
        return false;
      if (wordIndex >= doc[sentenceIndex].Length)
        return false;

      // Setze Layerwert auf -1 wenn alter == neuer Wert ansonst setzte neuen Wert
      if (doc[sentenceIndex][wordIndex] == idx)
        doc[sentenceIndex][wordIndex] = -1;
      else
        doc[sentenceIndex][wordIndex] = idx;

      // Speichere Dokument
      this[documentGuid] = doc;

      return true;
    }

    public override bool SetQuickStreamDocumentAnnotation(Guid documentGuid, IEnumerable<string> streamDocument)
    {
      var orig = this[documentGuid];
      if (orig == null)
        return false;

      var stream = streamDocument.ToArray();

      try
      {
        var ndoc = new List<int[]>();
        var cnt = 0;

        foreach (var sent in orig)
        {
          var nsent = new List<int>();
          for (var i = 0; i < sent.Length; i++)
          {
            var value = (from x in _layer.LayerDictionaryEntries where x.Value == stream[cnt] select x)
             .FirstOrDefault();
            if (value == null)
            {
              value = new LayerDictionaryEntry
              {
                LayerID = _dbIndex,
                Value = stream[cnt]
              };
              _db.LayerDictionaryEntries.InsertOnSubmit(value);
              _db.SubmitChanges();
            }

            nsent.Add(value.Index);

            cnt++;
          }

          ndoc.Add(nsent.ToArray());
        }

        if (cnt != stream.Length)
          throw new IndexOutOfRangeException();

        this[documentGuid] = ndoc.ToArray();

        return true;
      }
      catch
      {
        return false;
      }
    }

    public override Concept ToConcept(IEnumerable<string> ignoreValues = null)
    {
      // TODO: Konzepte werden von EntityFramework aktuell nicht unterstützt
      return null;
    }

    public override void ValueAdd(string value)
    {
      var v = (from x in _layer.LayerDictionaryEntries where x.Value == value select x).FirstOrDefault();
      if (v != null)
        return;
      _db.LayerDictionaryEntries.InsertOnSubmit(new LayerDictionaryEntry
      {
        LayerID = _dbIndex,
        Value = value
      });
      _db.SubmitChanges();
    }

    public override void ValueChange(string oldValue, string newValue)
    {
      var v = (from x in _layer.LayerDictionaryEntries where x.Value == oldValue select x).FirstOrDefault();
      if (v == null)
        return;
      v.Value = newValue;
      _db.SubmitChanges();
    }

    public override void ValueRemove(string removeValue)
    {
      var v = (from x in _layer.LayerDictionaryEntries where x.Value == removeValue select x).FirstOrDefault();
      if (v == null)
        return;
      _db.LayerDictionaryEntries.DeleteOnSubmit(v);
      _db.SubmitChanges();
    }

    protected override IEnumerable<string> ValuesByRegex(string regEx)
    {
      var res = new HashSet<string>();
      var @lock = new object();

      var regex = new Regex(regEx);
      Parallel.ForEach(
                       _db.LayerDictionaryEntries,
                       Configuration.ParallelOptions,
                       x =>
                       {
                         if (regex.IsMatch(x.Value))
                           lock (@lock)
                           {
                             res.Add(x.Value);
                           }
                       });

      return res;
    }
  }
}