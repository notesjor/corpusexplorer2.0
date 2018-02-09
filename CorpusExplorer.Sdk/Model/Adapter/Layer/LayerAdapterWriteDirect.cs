using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;

namespace CorpusExplorer.Sdk.Model.Adapter.Layer
{
  public class LayerAdapterWriteDirect : AbstractLayerAdapter
  {
    private Dictionary<string, int> _dictionary;
    private Dictionary<Guid, int[][]> _documents;
    private Dictionary<int, string> _reverse;

    public override string this[int index] => _reverse.ContainsKey(index) ? _reverse[index] : string.Empty;

    public override int this[string index] => _dictionary.ContainsKey(index) ? _dictionary[index] : -1;

    public override int[][] this[Guid guid]
    {
      get => _documents.ContainsKey(guid) ? _documents[guid] : null;
      set => _documents[guid] = value;
    }

    public override int CountDocuments => _documents.Count;
    public override int CountValues => _dictionary.Count;
    public override IEnumerable<Guid> DocumentGuids => _documents.Select(x => x.Key);
    public override IEnumerable<string> Values => _dictionary.Keys;
    public override bool ContainsDocument(Guid guid) { return _documents.ContainsKey(guid); }

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
        _documents = layer.Documents,
        _dictionary = layer.Cache,
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
        var buffer2 = new byte[sizeof(int)];
        while (true)
        {
          fs.Read(buffer2, 0, buffer2.Length);
          length = BitConverter.ToInt32(buffer2, 0);
          if (length < 0)
            break; // SPLIT (durch int.MinValue)
          buffer = new byte[length];
          fs.Read(buffer, 0, buffer.Length);

          var v = Configuration.Encoding.GetString(buffer);
          fs.Read(buffer2, 0, buffer2.Length);
          var i = BitConverter.ToInt32(buffer2, 0);

          res._dictionary.Add(v, i);
          res._reverse.Add(i, v);
        }

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

          res._documents.Add(guid, DocumentSerializerHelper.Deserialize(fs));
        }

        return res;
      }
      catch (Exception ex)
      {
        InMemoryErrorConsole.Log(ex);
        return null;
      }
    }

    public static AbstractLayerAdapter Create(Dictionary<Guid, int[][]> documents, ListOptimized<string> listOptimized, string layerDisplayname)
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

    public override Dictionary<Guid, int[][]> GetDocumentDictionary() { return _documents; }

    public override IEnumerable<IEnumerable<bool>> GetDocumentLayervalueMask(Guid documentGuid, string layerValue)
    {
      var idx = this[layerValue];
      return this[documentGuid].Select(s => s.Select(w => w == idx));
    }

    public override IEnumerable<IEnumerable<string>> GetReadableDocumentByGuid(Guid documentGuid)
    {
      return this[documentGuid] == null ? null : (from s in this[documentGuid] where s != null select s.Select(w => this[w]));
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

    protected override CeDictionary GetValueDictionary() { return new CeDictionary(_dictionary); }

    public override Dictionary<string, int> ReciveRawLayerDictionary() { return _dictionary; }

    public override void RefreshDictionaries() { _reverse = _dictionary.ToDictionary(x => x.Value, x => x.Key); }

    internal void Save(FileStream fs)
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
      // ReSharper disable once RedundantAssignment
      var buffer3 = new byte[sizeof(int)];
      foreach (var x in _dictionary)
      {
        buffer = Configuration.Encoding.GetBytes(x.Key);
        buffer2 = BitConverter.GetBytes(buffer.Length);
        fs.Write(buffer2, 0, buffer2.Length);
        fs.Write(buffer, 0, buffer.Length);
        buffer3 = BitConverter.GetBytes(x.Value);
        fs.Write(buffer3, 0, buffer2.Length);
      }

      // SPLIT (durch int.MinValue)
      var split = BitConverter.GetBytes(int.MinValue);
      fs.Write(split, 0, split.Length);

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

    public override bool SetDocumentLayerValueMaskBySwitch(
      Guid documentGuid,
      int sentenceIndex,
      int wordIndex,
      string value)
    { // Prüfe ob Wert bereits vorhanden, wenn nicht, füge hinzu.
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

    public override Concept ToConcept(IEnumerable<string> ignoreValues = null) { throw new NotImplementedException(); }

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

    protected override IEnumerable<string> ValuesByRegex(string regEx)
    {
      var rx = new Regex(regEx);
      return from x in _dictionary where rx.IsMatch(x.Key) select x.Key;
    }
  }
}