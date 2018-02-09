#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.CorpusExplorer;

#endregion

namespace CorpusExplorer.Sdk.Model
{
  /// <summary>
  ///   The layer.
  /// </summary>
  [Serializable]
  public class Layer : CeObject, IEnumerable<KeyValuePair<Guid, int[][]>>
  {
    /// <summary>
    ///   The _dictionary.
    /// </summary>
    private readonly CeDictionary _dictionary;

    /// <summary>
    ///   The _documents.
    /// </summary>
    [NonSerialized]
    private Dictionary<Guid, int[][]> _documents = new Dictionary<Guid, int[][]>();

    private KeyValuePair<Guid, int[][]>[] _documentsSerialized;

    /// <summary>
    ///   Initializes a new instance of the <see cref="Layer" /> class.
    ///   Erzeugt einen neuen Layer
    /// </summary>
    /// <param name="documents">
    ///   Dokumente
    /// </param>
    /// <param name="dictionary">
    ///   Wert zu Index
    /// </param>
    /// <param name="layerMetadata">
    ///   Metadaten zum Layer
    /// </param>
    public Layer(
      Dictionary<Guid, int[][]> documents,
      Dictionary<string, int> dictionary,
      Dictionary<string, object> layerMetadata)
    {
      _documents = documents;
      _dictionary = new CeDictionary(dictionary);
      Metadata = layerMetadata;
    }

    /// <summary>
    ///   Initializes a new instance of the <see cref="Layer" /> class.
    /// </summary>
    /// <param name="documents">
    ///   The documents.
    /// </param>
    /// <param name="dictionary">
    ///   The dictionary.
    /// </param>
    /// <param name="layerMetadata">
    ///   The layer metadata.
    /// </param>
    public Layer(
      Dictionary<Guid, int[][]> documents,
      ListOptimized<string> dictionary,
      Dictionary<string, object> layerMetadata)
    {
      _documents = documents;
      _dictionary = new CeDictionary(dictionary.GetRawDictionary());
      Metadata = layerMetadata;
    }

    /// <summary>
    ///   Prevents a default instance of the <see cref="Layer" /> class from being created.
    /// </summary>
    private Layer() { }

    /// <summary>
    ///   Gibt die entsprechende Wertbeschreibung zurück
    /// </summary>
    /// <param name="index">
    ///   Index
    /// </param>
    /// <returns>
    ///   Wertbeschreibung
    /// </returns>
    public string this[int index] => _dictionary[index];

    /// <summary>
    ///   Gibt den Index zur Wertbeschreibung zurück
    /// </summary>
    /// <param name="index">
    ///   Wertbeschreibung
    /// </param>
    /// <returns>
    ///   Index
    /// </returns>
    public int this[string index] => _dictionary[index];

    /// <summary>
    ///   Gibt die Layerrohdaten des Dokuments zurück
    /// </summary>
    /// <param name="guid">
    ///   GUID des Dokuments
    /// </param>
    /// <returns>
    ///   Rohdaten (Indexbasiert)
    /// </returns>
    public int[][] this[Guid guid]
    {
      get
      {
        try
        {
          return _documents[guid];
        }
        catch
        {
          return null;
        }
      }
      set
      {
        try
        {
          _documents[guid] = value;
        }
        catch
        {
          // ignore
        }
      }
    }

    /// <summary>
    ///   Anzahl der enthaltenen Dokumente
    /// </summary>
    public int CountDocuments => _documents.Count;

    /// <summary>
    ///   Anzahl der enthaltenen Werte
    /// </summary>
    public int CountValues => _dictionary.Count;

    /// <summary>
    ///   Auflistung aller Dokument-GUIDs
    /// </summary>
    public IEnumerable<Guid> DocumentGuids => _documents.Keys;

    /// <summary>
    ///   Auflistung aller Werte des Layers
    /// </summary>
    public IEnumerable<string> Values => _dictionary.Values;

    /// <summary>
    ///   Returns an enumerator that iterates through a collection.
    /// </summary>
    /// <returns>
    ///   An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
    /// </returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    /// <summary>
    ///   Enumerator für Dokumente
    /// </summary>
    /// <returns>Enumerator</returns>
    public IEnumerator<KeyValuePair<Guid, int[][]>> GetEnumerator()
    {
      return _documents.GetEnumerator();
    }

    /// <summary>
    ///   Enthält der Layer informationen zum gesuchten Dokument
    /// </summary>
    /// <param name="guid">
    ///   GUID des Dokuments
    /// </param>
    /// <returns>
    ///   Ja/Nein?
    /// </returns>
    public bool ContainsDocument(Guid guid)
    {
      return _documents.ContainsKey(guid);
    }

    /// <summary>
    ///   Erstellt eine Kopie dieses Layers. Der neue Layer enthält exakt die gleichen Werte, wie der Ursprungslayer.
    ///   Lediglich der GUID und die Metadaten werden verworfen.
    /// </summary>
    /// <returns>Kopie des Layers</returns>
    public Layer Copy()
    {
      var ndocs = new Dictionary<Guid, int[][]>();
      foreach (var document in _documents)
        try
        {
          var doc = document.Value;
          if (doc == null)
            continue;
          ndocs.Add(document.Key, (int[][]) doc.Clone());
        }
        catch
        {
          // ignore
        }
      var ndic = new Dictionary<string, int>();
      foreach (var entry in _dictionary)
        try
        {
          ndic.Add(entry.Value, entry.Key);
        }
        catch
        {
          // ignore
        }

      return new Layer(ndocs, ndic, new Dictionary<string, object>());
    }

    public Layer Copy(Guid documentGuid)
    {
      var ndic = new Dictionary<string, int>();
      foreach (var entry in _dictionary)
        try
        {
          ndic.Add(entry.Value, entry.Key);
        }
        catch
        {
          // ignore
        }

      return new Layer(
        new Dictionary<Guid, int[][]> {{documentGuid, _documents[documentGuid]}},
        ndic,
        new Dictionary<string, object>());
    }

    public IEnumerable<IEnumerable<bool>> GetDocumentLayervalueMask(Guid documentGuid, string layerValue)
    {
      var val = this[layerValue];
      if (val == -1)
        return null;

      var doc = this[documentGuid];

      return doc?.Select(s => s.Select(w => w == val));
    }

    public int[][] GetRawDocumentArray(Guid documentGuid)
    {
      return _documents.ContainsKey(documentGuid) ? _documents[documentGuid] : null;
    }

    /// <summary>
    ///   The get readable document by guid.
    /// </summary>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <returns>
    ///   The <see cref="IEnumerable" />.
    /// </returns>
    public IEnumerable<IEnumerable<string>> GetReadableDocumentByGuid(Guid documentGuid)
    {
      var doc = this[documentGuid];
      return doc == null ? null : (from s in doc where s != null select s.Select(w => this[w]));
    }

    /// <summary>
    ///   The get readable document snippet by guid.
    /// </summary>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <param name="start">
    ///   The start.
    /// </param>
    /// <param name="stop">
    ///   The stop.
    /// </param>
    /// <returns>
    ///   The <see cref="IEnumerable" />.
    /// </returns>
    public IEnumerable<IEnumerable<string>> GetReadableDocumentSnippetByGuid(Guid documentGuid, int start, int stop)
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

    public CeDictionary GetValueDictionary() { return _dictionary; }

    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
      try
      {
        _documents = _documentsSerialized?.ToDictionary(x => x.Key, x => x.Value) ?? new Dictionary<Guid, int[][]>();
      }
      catch // Fallback
      {
        _documents = new Dictionary<Guid, int[][]>();

        if (_documentsSerialized != null)
          foreach (var entry in _documentsSerialized.Where(entry => !_documents.ContainsKey(entry.Key)))
            _documents.Add(entry.Key, entry.Value);
      }
      _documentsSerialized = null;
      GC.Collect();
      GC.WaitForPendingFinalizers();
    }

    [OnSerialized]
    private void OnSerialized(StreamingContext context)
    {
      _documentsSerialized = null;
      GC.Collect();
      GC.WaitForPendingFinalizers();
    }

    [OnSerializing]
    private void OnSerializing(StreamingContext context)
    {
      _documentsSerialized = _documents?.ToArray();
    }

    public Dictionary<string, int> ReciveRawLayerDictionary()
    {
      return _dictionary.ReciveRawValueToIndex().ToDictionary(x => x.Key, x => x.Value);
    }

    public void RefreshDictionaries() { _dictionary.RefreshDictionaries(); }

    public bool SetDocumentLayerValueMaskBySwitch(Guid documentGuid, int sentenceIndex, int wordIndex, string value)
    {
      // Prüfe ob Wert bereits vorhanden, wenn nicht, füge hinzu.
      if (!_dictionary.Contains(value))
        _dictionary.Add(value);

      // Rufe value/idx sowie das Dokument ab
      var idx = _dictionary[value];
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

    /// <summary>
    ///   Ändert sehr schnell alle annotierten Daten eines bestimmten Dokuments mithilfe eines StreamDokuments.
    /// </summary>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <param name="streamDocument">
    ///   Stream-Dokument muss exakt den Ausmaßen des mittels GUID referenziertem Dokuments
    ///   entsprechen.
    /// </param>
    /// <returns>Erfolgreich?</returns>
    public bool SetQuickStreamDocumentAnnotation(Guid documentGuid, IEnumerable<string> streamDocument)
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
            if (!_dictionary.Contains(stream[cnt]))
              _dictionary.Add(stream[cnt]);

            nsent.Add(_dictionary[stream[cnt]]);

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

    public Concept ToConcept(IEnumerable<string> ignoreValues = null)
    {
      var res = new Concept();
      var @lock = new object();
      var ignore = ignoreValues == null ? new HashSet<int>() : new HashSet<int>(ignoreValues.Select(x => this[x]));

      Parallel.ForEach(
        DocumentGuids,
        dsel =>
        {
          var doc = this[dsel];
          int open = -1, sent = 0, word = 0;

          for (var i = 0; i < doc.Length; i++)
          {
            if (doc[i] == null)
              continue;
            for (var j = 0; j < doc[i].Length; j++)
            {
              if (ignore.Contains(doc[i][j]))
              {
                // Fire-and-forget
                ToConcept_WriteValue(open, @lock, ref res, dsel, sent, word, i, j);
                open = -1;
                continue;
              }

              if (open == doc[i][j])
                continue;

              // Fire-and-forget
              ToConcept_WriteValue(open, @lock, ref res, dsel, sent, word, i, j);
              open = doc[i][j];
              sent = i;
              word = j;
            }
          }
          // Fire-and-forget
          ToConcept_WriteValue(
            open,
            @lock,
            ref res,
            dsel,
            sent,
            word,
            doc.Length - 1,
            doc[doc.Length - 1].Length - 1);
        });
      return res;
    }

    private void ToConcept_WriteValue(
      int open,
      object @lock,
      ref Concept res,
      Guid dsel,
      int sent,
      int word,
      int i,
      int j)
    {
      if (open == -1)
        return;
      lock (@lock)
      {
        res.AddMark(dsel, sent, word, i, j, this[open]);
      }
    }

    /// <summary>
    ///   Fügt dem Layer einen neuen Wert hinzu
    /// </summary>
    /// <param name="value">
    ///   neuer Wert
    /// </param>
    public void ValueAdd(string value)
    {
      _dictionary.Add(value);
    }

    /// <summary>
    ///   Fügt dem Layer eine ganze Auflistung von Werten hinzu
    /// </summary>
    /// <param name="values">
    ///   Auflistung von Werten
    /// </param>
    public void ValueAddRange(IEnumerable<string> values)
    {
      if (values == null)
        return;

      foreach (var value in from value in values let idx = this[value] where idx == -1 select value)
        _dictionary.Add(value);
    }

    /// <summary>
    ///   Ändert den die Wertbezeichnung von Layerdaten.
    /// </summary>
    /// <param name="oldValue">
    ///   Alter Wert
    /// </param>
    /// <param name="newValue">
    ///   Neuer Wert
    /// </param>
    public void ValueChange(string oldValue, string newValue)
    {
      if (!_dictionary.Contains(oldValue) ||
          string.IsNullOrEmpty(oldValue))
        return;

      if (!_dictionary.Contains(newValue))
        _dictionary.InternRedefineValue(oldValue, newValue);

      var oidx = _dictionary[oldValue];
      var nidx = _dictionary[newValue];

      if (oidx == nidx)
        return;

      Parallel.ForEach(
        this,
        doc =>
        {
          foreach (var s in doc.Value)
            for (var i = 0; i < s.Length; i++)
              if (s[i] == oidx)
                s[i] = nidx;
        });
    }

    /// <summary>
    ///   Entfernt einen Layerwert
    /// </summary>
    /// <param name="removeValue">
    ///   Zu entfernender Wert
    /// </param>
    public void ValueRemove(string removeValue)
    {
      ValueChange(removeValue, string.Empty);
    }

    public IEnumerable<string> ValuesByRegex(string regEx)
    {
      var res = new HashSet<string>();
      var @lock = new object();

      var regex = new Regex(regEx);
      Parallel.ForEach(
        _dictionary,
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

    /// <summary>
    ///   Wandelt eine Auflistung von Werten in die entsprechenden Indices um.
    ///   Enthält KEINE -1-Indices
    /// </summary>
    /// <param name="values">
    /// </param>
    /// <returns>
    ///   The <see cref="IEnumerable" />.
    /// </returns>
    public IEnumerable<int> ValuesToIndices(IEnumerable<string> values)
    {
      return values.Select(value => this[value]).Where(value => value > -1);
    }
  }
}