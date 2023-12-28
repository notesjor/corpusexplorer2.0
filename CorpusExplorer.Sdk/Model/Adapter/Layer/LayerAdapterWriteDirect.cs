﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;

namespace CorpusExplorer.Sdk.Model.Adapter.Layer
{
  public class LayerAdapterWriteDirect : AbstractLayerAdapter, IDisposable
  {
    private Dictionary<string, int> _dictionary;
    private Dictionary<Guid, int[][]> _documents;
    private Dictionary<int, string> _reverse;

    public override int CountDocuments => _documents.Count;
    public override int CountValues => _dictionary.Count;
    public override IEnumerable<Guid> DocumentGuids => _documents.Select(x => x.Key);

    public override string this[int index] => _reverse.ContainsKey(index) ? _reverse[index] : string.Empty;

    public override int this[string index] => _dictionary.ContainsKey(index) ? _dictionary[index] : -1;

    public override int[][] this[Guid guid]
    {
      get => _documents.ContainsKey(guid) ? _documents[guid] : null;
      set => _documents[guid] = value;
    }

    public void Dispose()
    {
      _dictionary.Clear();
      _documents.Clear();
      _reverse.Clear();
    }

    public override IEnumerable<string> Values => _dictionary.Keys;

    public override bool ContainsDocument(Guid guid)
    {
      return _documents.ContainsKey(guid);
    }

    public override AbstractLayerAdapter Copy()
    {
      var res = new LayerAdapterWriteDirect
      {
        _guid = Guid.NewGuid(),
        _documents = _documents.ToDictionary(x => x.Key, x => x.Value),
        _dictionary = _dictionary.ToDictionary(x => x.Key, x => x.Value),
        Displayname = Displayname
      };
      res.RefreshDictionaries();
      return res;
    }

    public override AbstractLayerAdapter Copy(Guid documentGuid)
    {
      if (!_documents.ContainsKey(documentGuid))
        return null;

      var doc = _documents[documentGuid];
      var dic = new Dictionary<string, int>();
      foreach (var s in doc)
        foreach (var w in s)
        {
          var k = _reverse[w];
          if (!dic.ContainsKey(k))
            dic.Add(k, w);
        }

      var res = new LayerAdapterWriteDirect
      {
        _guid = Guid.NewGuid(),
        _documents = new Dictionary<Guid, int[][]> { { documentGuid, doc } },
        _dictionary = dic,
        Displayname = Displayname
      };
      res.RefreshDictionaries();
      return res;
    }

    public static AbstractLayerAdapter Create(AbstractLayerState layer)
    {
      var res = new LayerAdapterWriteDirect
      {
        _guid = Guid.NewGuid(),
        _documents = layer.GetDocuments().ToDictionary(x => x.Key, x => x.Value),
        _dictionary = layer.GetCache().ToDictionary(x => x.Key, x => x.Value),
        Displayname = layer.Displayname
      };
      res.RefreshDictionaries();
      return res;
    }

    public static LayerAdapterWriteDirect Create(Stream fs)
    {
      try
      {
        var res = new LayerAdapterWriteDirect
        {
          _dictionary = new Dictionary<string, int>(),
          _reverse = new Dictionary<int, string>(),
          _documents = new Dictionary<Guid, int[][]>()
        };

        var buffer = new byte[16];
        fs.Read(buffer, 0, buffer.Length);

        // GUID
        res._guid = new Guid(buffer);
        if (res._guid == Guid.Empty)
          return null;

        // Displayname
        buffer = new byte[sizeof(int)];
        fs.Read(buffer, 0, buffer.Length);
        var length = BitConverter.ToInt32(buffer, 0);
        buffer = new byte[length];
        fs.Read(buffer, 0, buffer.Length);
        res.Displayname = Configuration.Encoding.GetString(buffer);

        // Dictionary
        DictionarySerializerHelper.Deserialize(fs, ref res._dictionary, ref res._reverse);

        // Documents
        buffer = new byte[16];
        while (true)
        {
          if (fs.Read(buffer, 0, buffer.Length) == 0)
            break;
          var guid = new Guid(buffer);
          // SPLIT / SPLIT (durch Guid.Empty)
          if (guid == Guid.Empty)
            break;

          var doc = DocumentSerializerHelper.Deserialize(fs);
          if (doc == null)
            throw new FormatException();
          res._documents.Add(guid, doc);
        }
        return res;
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
        return null;
      }
    }

    public static AbstractLayerAdapter Create(Dictionary<Guid, int[][]> documents, ListOptimized<string> listOptimized,
                                              string layerDisplayname)
    {
      return new LayerAdapterWriteDirect
      {
        _guid = Guid.NewGuid(),
        _documents = documents,
        _dictionary = listOptimized.GetRawDictionary(),
        _reverse = listOptimized.GetRawDictionary().ToDictionary(x => x.Value, x => x.Key),
        Displayname = layerDisplayname
      };
    }

    public override Dictionary<Guid, int[][]> GetDocumentDictionary()
    {
      return _documents;
    }

    public override IEnumerable<IEnumerable<bool>> GetDocumentLayervalueMask(Guid documentGuid, string layerValue)
    {
      var idx = this[layerValue];
      return this[documentGuid].Select(s => s.Select(w => w == idx));
    }

    public override IEnumerable<IEnumerable<string>> GetReadableDocumentByGuid(Guid documentGuid)
    {
      return this[documentGuid] == null
               ? null
               : from s in this[documentGuid] where s != null select s.Select(w => this[w]);
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

      var res = new List<IEnumerable<string>>();
      for (var i = start; i <= stop; i++)
        res.Add(doc[i].Select(w => this[w]));

      return res;
    }

    public override Dictionary<string, int> ReciveRawLayerDictionary()
    {
      return _dictionary;
    }

    public override Dictionary<int, string> ReciveRawReverseLayerDictionary()
    {
      return _reverse;
    }

    public override void ResetRawLayerDictionary(Dictionary<string, int> dictionary)
    {
      _dictionary = dictionary;
      RefreshDictionaries();
    }

    public override void ResetRawReverseLayerDictionary(Dictionary<int, string> reverse)
    {
      _reverse = reverse;
      _dictionary = _reverse.ToDictionary(x => x.Value, x => x.Key);
    }

    public override void RefreshDictionaries()
    {
      _reverse = _dictionary.ToDictionary(x => x.Value, x => x.Key);
    }

    public override bool SetDocumentLayerValueMaskBySwitch(
      Guid documentGuid,
      int sentenceIndex,
      int wordIndex,
      string value)
    {
      // Prüfe ob Wert bereits vorhanden, wenn nicht, füge hinzu.
      if (!_dictionary.ContainsKey(value))
        ValueAdd(value);

      // Rufe value/idx sowie das Dokument ab
      var idx = this[value];
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
            if (!_dictionary.ContainsKey(stream[cnt]))
              ValueAdd(stream[cnt]);

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

    public override Concept ToConcept(IEnumerable<string> ignoreValues = null)
    {
      throw new NotImplementedException();
    }

    public override void ValueAdd(string value)
    {
      if (_dictionary.ContainsKey(value))
        return;

      var idx = _dictionary.Count;
      _dictionary.Add(value, idx);
      _reverse.Add(idx, value);
    }

    public override void ValueChange(string oldValue, string newValue)
    {
      if (!_dictionary.ContainsKey(oldValue) || _dictionary.ContainsKey(newValue))
        return;

      var idx = _dictionary[oldValue];
      _dictionary.Remove(oldValue);
      _dictionary.Add(newValue, idx);
      _reverse[idx] = newValue;
    }

    public override void ValueRemove(string removeValue)
    {
      if (!_dictionary.ContainsKey(removeValue))
        return;

      _reverse.Remove(_dictionary[removeValue]);
      _dictionary.Remove(removeValue);
    }

    protected override CeDictionary GetValueDictionary()
    {
      return new CeDictionary(_dictionary);
    }

    protected override IEnumerable<string> ValuesByRegex(string regEx)
    {
      var rx = new Regex(regEx, RegexOptions.Compiled);
      return from x in _dictionary where rx.IsMatch(x.Key) select x.Key;
    }

    internal void Save(Stream fs)
    {
      // GUID
      var buffer = _guid.ToByteArray();
      fs.Write(buffer, 0, buffer.Length);

      // Displayname
      buffer = Configuration.Encoding.GetBytes(Displayname);
      var buffer2 = BitConverter.GetBytes(buffer.Length);
      fs.Write(buffer2, 0, buffer2.Length);
      fs.Write(buffer, 0, buffer.Length);

      // Dictionary
      DictionarySerializerHelper.Serialize(_dictionary, fs);

      // Documents
      foreach (var document in _documents)
      {
        if (document.Key == Guid.Empty || document.Value == null || document.Value.Length == 0)
          continue;

        using (var ms = new MemoryStream())
        {
          // Document GUID
          buffer = document.Key.ToByteArray();
          ms.Write(buffer, 0, buffer.Length);

          DocumentSerializerHelper.Serialize(ms, document.Value);

          buffer = ms.ToArray();
          fs.Write(buffer, 0, buffer.Length);
        }
      }

      // SPLIT / SPLIT (durch Guid.Empty)
      buffer = Guid.Empty.ToByteArray();
      fs.Write(buffer, 0, buffer.Length);
    }

    internal Dictionary<Guid, long> WriteFuriousIndex(string path)
    {
      var res = new Dictionary<Guid, long>();
      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read))
        foreach (var document in _documents)
        {
          res.Add(document.Key, fs.Position);
          DocumentSerializerHelper.Serialize(fs, document.Value);
        }
      return res;
    }

    [Obsolete("Ersetzt durch WriteFuriousIndex im Zusammhang mit neuer Version von QuickIndex")]
    internal Dictionary<Guid, long> GetFuriousIndex(long pos)
    {
      pos += 16; // GUID
      pos += 4; // Length Displayname;
      pos += Configuration.Encoding.GetBytes(Displayname).Length; // Displayname
      using (var ms = new MemoryStream())
      {
        DictionarySerializerHelper.Serialize(_dictionary, ms);
        pos += ms.Length;
      }

      var res = new Dictionary<Guid, long>();
      foreach (var document in _documents)
      {
        pos += 16;
        res.Add(document.Key, pos);
        using (var ms = new MemoryStream())
        {
          DocumentSerializerHelper.Serialize(ms, document.Value);
          pos += ms.Length;
        }
      }
      return res;
    }
  }
}