using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Db.Core.Model.SimpleBinary;
using CorpusExplorer.Sdk.Db.Core.Model.SimpleBinary.Manager;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;
using Layer = CorpusExplorer.Sdk.Db.Core.Model.SimpleBinary.Layer;

namespace CorpusExplorer.Sdk.Db.Core.Adapter
{
  public class LayerAdapterEntityFramework : AbstractLayerAdapter
  {
    private CoreBinaryContext _db;
    private Layer _layer;
    private CeDictionary _values;

    private LayerAdapterEntityFramework() { }

    public override string this[int index]
      => _values[index];

    public override int this[string index]
      => _values[index];

    public override int[][] this[Guid guid]
    {
      get
      {
        return (from x in _layer.LayerDocuments where x.LayerDocumentId == guid select x.Content).FirstOrDefault();
      }
      set
      {
        var doc = (from x in _layer.LayerDocuments where x.LayerDocumentId == guid select x).FirstOrDefault();
        doc.Content = value;
      }
    }

    public override int CountDocuments
      => _layer.LayerDocuments.Count;

    public override int CountValues
      => _values.Count;

    public override IEnumerable<Guid> DocumentGuids
      => from x in _layer.LayerDocuments select x.LayerDocumentId;

    public override IEnumerable<string> Values
      => _values.Values;

    public override bool ContainsDocument(Guid guid) => _layer.LayerDocuments.Any(x => x.LayerDocumentId == guid);

    public override AbstractLayerAdapter Copy()
    {
      var res = _db.LayerSet.Add(
                     new Layer
                     {
                       CorpusId = _layer.CorpusId,
                       Dictionary = _values,
                       Displayname = _layer.Displayname,
                       LayerId = Guid.NewGuid()
                     });

      _db.SaveChangesAsync();

      foreach (var d in _layer.LayerDocuments)
      {
        _db.LayerDocumentSet.Add(
             new LayerDocument
             {
               Content = d.Content,
               LayerId = res.LayerId,
               LayerDocumentId = d.LayerDocumentId
             });
        _db.SaveChangesAsync();
      }

      return new LayerAdapterEntityFramework
      {
        _db = _db,
        Displayname = res.Displayname,
        _guid = res.LayerId,
        _values = res.Dictionary,
        _layer = res
      };
    }

    public override AbstractLayerAdapter Copy(Guid documentGuid)
    {
      var res = _db.LayerSet.Add(
                     new Layer
                     {
                       CorpusId = _layer.CorpusId,
                       Dictionary = _values,
                       Displayname = _layer.Displayname,
                       LayerId = Guid.NewGuid()
                     });

      _db.SaveChangesAsync();

      var doc = _layer.LayerDocuments.FirstOrDefault(x => x.LayerDocumentId == documentGuid);

      _db.LayerDocumentSet.Add(
           new LayerDocument
           {
             Content = doc.Content,
             LayerId = res.LayerId,
             LayerDocumentId = documentGuid
           });
      _db.SaveChangesAsync();

      return new LayerAdapterEntityFramework
      {
        _db = _db,
        Displayname = res.Displayname,
        _guid = res.LayerId,
        _values = res.Dictionary,
        _layer = res
      };
    }

    public static AbstractLayerAdapter Create(AbstractCorpusAdapter corpus, AbstractLayerState layer)
    {
      var context = CoreBinaryContextManager.GetContext();
      var layerSet = context.LayerSet.Add(
                              new Layer
                              {
                                LayerId = Guid.NewGuid(),
                                CorpusId = corpus.CorpusGuid,
                                Dictionary = new CeDictionary(layer.Cache),
                                Displayname = layer.Displayname
                              });

      context.SaveChangesAsync();

      foreach (var d in layer.Documents)
      {
        var doc = (from x in context.DocumentSet where (x.CorpusId == corpus.CorpusGuid) && (x.DocumentId == d.Key) select x).FirstOrDefault();
        if (doc != null)
        {
          doc = new Document
          {
            CorpusId = corpus.CorpusGuid,
            DocumentId = d.Key,
            SentenceCount = d.Value.Length,
            TokenCount = d.Value.SelectMany(s => s).Count()
          };
          context.DocumentSet.Add(doc);
          context.SaveChanges();
        }
        
        context.LayerDocumentSet.Add(
                 new LayerDocument
                 {
                   LayerDocumentId = d.Key,
                   Content = d.Value,
                   LayerId = layerSet.LayerId,                   
                 });

        context.SaveChangesAsync();
      }

      return Create(context, layerSet);
    }

    public static AbstractLayerAdapter Create(CoreBinaryContext db, Layer layer)
    {
      return new LayerAdapterEntityFramework
      {
        _db = db,
        _layer = layer,
        _values = layer.Dictionary,
        Displayname = layer.Displayname,
        _guid = layer.LayerId
      };
    }

    public override Dictionary<Guid, int[][]> GetDocumentDictionary()
      => _layer.LayerDocuments.ToDictionary(x => x.LayerDocumentId, x => x.Content);

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
      return doc == null ? null : (from s in doc where s != null select s.Select(w => this[w]));
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
      stop = stop >= doc.Length ? doc.Length - 1 : stop;
      stop = stop <= start ? start + 1 : stop;

      var res = new List<IEnumerable<string>>();
      for (var i = start; i < stop; i++)
        res.Add(doc[i].Select(w => this[w]));

      return res;
    }

    protected override CeDictionary GetValueDictionary() => _layer.Dictionary;

    public override Dictionary<string, int> ReciveRawLayerDictionary()
      => _values.ReciveRawValueToIndex().ToDictionary(x => x.Key, x => x.Value);

    public override void RefreshDictionaries() { }

    public override bool SetDocumentLayerValueMaskBySwitch(
      Guid documentGuid,
      int sentenceIndex,
      int wordIndex,
      string value)
    {
      // Prüfe ob Wert bereits vorhanden, wenn nicht, füge hinzu.
      if (!_values.Contains(value))
      {
        _values.Add(value);
        _layer.Dictionary = _values;
        _db.SaveChangesAsync();
      }

      // Rufe value/idx sowie das Dokument ab
      var idx = _values[value];
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
            if (!_values.Contains(stream[cnt]))
            {
              _values.Add(stream[cnt]);
              _layer.Dictionary = _values;
              _db.SaveChangesAsync();
            }

            nsent.Add(_values[stream[cnt]]);

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
      _values.Add(value);
      _layer.Dictionary = _values;
    }

    public override void ValueChange(string oldValue, string newValue)
    {
      _values.RenameValue(oldValue, newValue);
      _layer.Dictionary = _values;
    }

    public override void ValueRemove(string removeValue)
    {
      _values.Remove(removeValue);
      _layer.Dictionary = _values;
    }

    protected override IEnumerable<string> ValuesByRegex(string regEx)
    {
      var res = new HashSet<string>();
      var @lock = new object();

      var regex = new Regex(regEx);
      Parallel.ForEach(
        _values,
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