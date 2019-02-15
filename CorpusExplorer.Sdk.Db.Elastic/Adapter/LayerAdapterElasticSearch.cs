using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Db.Elastic.Model;
using CorpusExplorer.Sdk.Db.Elastic.Model.Context;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;
using Layer = CorpusExplorer.Sdk.Db.Elastic.Model.Layer;

namespace CorpusExplorer.Sdk.Db.Elastic.Adapter
{
  public class LayerAdapterElasticSearch : AbstractLayerAdapter
  {
    private ElasticSearchContext _db;
    private Layer _layer;
    private CeDictionary _values;

    private LayerAdapterElasticSearch()
    {
    }

    public override int CountDocuments
      => _layer.LayerDocuments.Count;

    public override int CountValues
      => _values.Count;

    public override IEnumerable<Guid> DocumentGuids
      => from x in _layer.LayerDocuments select x;

    public override string this[int index]
      => _values[index];

    public override int this[string index]
      => _values[index];

    public override int[][] this[Guid guid]
    {
      get => _db.GetLayerDocument(guid, _layer.LayerId).Content;
      set
      {
        var doc = _db.GetLayerDocument(guid, _layer.LayerId);
        doc.Content = value;
        _db.Update(doc);
      }
    }

    public override IEnumerable<string> Values
      => _values.Values;

    public override bool ContainsDocument(Guid guid)
    {
      return _layer.LayerDocuments.Any(x => x == guid);
    }

    public override AbstractLayerAdapter Copy()
    {
      var res =
        new Layer
        {
          CorpusId = _layer.CorpusId,
          Dictionary = _values,
          Displayname = _layer.Displayname,
          LayerId = Guid.NewGuid()
        };

      _db.Add(res);

      foreach (var d in _layer.LayerDocuments)
      {
        var doc = _db.GetLayerDocument(d, _layer.LayerId);

        _db.Add(
                new LayerDocument
                {
                  Content = doc.Content,
                  LayerId = res.LayerId,
                  DocumentId = doc.DocumentId
                });
      }

      return new LayerAdapterElasticSearch
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
      var res =
        new Layer
        {
          CorpusId = _layer.CorpusId,
          Dictionary = _values,
          Displayname = _layer.Displayname,
          LayerId = Guid.NewGuid()
        };

      _db.Add(res);

      var doc = _db.GetLayerDocument(documentGuid, _layer.LayerId);

      _db.Add(
              new LayerDocument
              {
                Content = doc.Content,
                LayerId = res.LayerId,
                DocumentId = doc.DocumentId
              });

      return new LayerAdapterElasticSearch
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
      var context = ElasticSearchContextManager.GetContext();

      var corpusSet = context.GetCorpus(corpus.CorpusGuid);
      if (corpusSet == null)
        return null;

      // recyle
      foreach (var pair in corpusSet.Layers)
      {
        if (pair.Value != layer.Displayname)
          continue;

        var layerOld = context.GetLayer(pair.Key);
        if (layerOld == null)
          break;

        layerOld.Dictionary = new CeDictionary(layer.Cache);
        context.Update(layerOld);

        return Create(context, layerOld);
      }

      var layerSet =
        new Layer
        {
          LayerId = Guid.NewGuid(),
          CorpusId = corpus.CorpusGuid,
          Dictionary = new CeDictionary(layer.Cache),
          Displayname = layer.Displayname,
          LayerDocuments = new HashSet<Guid>(layer.Documents.Select(x => x.Key))
        };
      context.Add(layerSet);

      corpusSet.Layers.Add(layerSet.LayerId, layerSet.Displayname);
      context.Update(corpusSet);

      foreach (var d in layer.Documents)
      {
        var doc = context.GetDocument(d.Key);
        if (doc == null)
          context.Add(new Document
          {
            CorpusId = corpusSet.CorpusId,
            DocumentId = d.Key,
            Metadata = new Dictionary<string, object>(),
            SentenceCount = d.Value.Length,
            TokenCount = d.Value.SelectMany(s => s).Count()
          });

        context.Add(
                    new LayerDocument
                    {
                      DocumentId = d.Key,
                      Content = d.Value,
                      LayerId = layerSet.LayerId
                    });
      }

      var res = Create(context, layerSet);
      corpus.AddLayer(res);

      return res;
    }

    public static AbstractLayerAdapter Create(ElasticSearchContext db, Layer layer)
    {
      return new LayerAdapterElasticSearch
      {
        _db = db,
        _layer = layer,
        _values = layer.Dictionary,
        Displayname = layer.Displayname,
        _guid = layer.LayerId
      };
    }

    public override Dictionary<Guid, int[][]> GetDocumentDictionary()
    {
      return _layer.LayerDocuments.ToDictionary(x => x, x => _db.GetLayerDocument(x, _layer.LayerId).Content);
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
      stop = stop >= doc.Length ? doc.Length - 1 : stop;
      stop = stop <= start ? start + 1 : stop;

      var res = new List<IEnumerable<string>>();
      for (var i = start; i < stop; i++)
        res.Add(doc[i].Select(w => this[w]));

      return res;
    }

    public override Dictionary<string, int> ReciveRawLayerDictionary()
    {
      return _values.ReciveRawValueToIndex().ToDictionary(x => x.Key, x => x.Value);
    }

    public override Dictionary<int, string> ReciveRawReverseLayerDictionary()
    {
      return _values.ReciveRawIndexToValue().ToDictionary(x => x.Key, x => x.Value);
    }

    public override void ResetRawLayerDictionary(Dictionary<string, int> dictionary)
    {
      _values = new CeDictionary(dictionary);
    }

    public override void ResetRawReverseLayerDictionary(Dictionary<int, string> reverse)
    {
      _values = new CeDictionary(reverse);
    }

    public override void RefreshDictionaries()
    {
    }

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
        _db.Update(_layer);
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
              _db.Update(_layer);
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

    protected override CeDictionary GetValueDictionary()
    {
      return _layer.Dictionary;
    }

    protected override IEnumerable<string> ValuesByRegex(string regEx)
    {
      var res = new HashSet<string>();
      var @lock = new object();

      var regex = new Regex(regEx);
      Parallel.ForEach(
                       _values,
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