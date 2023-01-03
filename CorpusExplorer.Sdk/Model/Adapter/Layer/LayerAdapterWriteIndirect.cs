using System;
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
  public class LayerAdapterWriteIndirect : AbstractLayerAdapter, IDisposable
  {
    private Dictionary<string, int> _dictionary;
    private Dictionary<Guid, long> _documentInfo;
    private string _path;
    private Dictionary<int, string> _reverse;
    private FileStream _fs;
    private BufferedStream _stream;
    private object _streamLock = new object();

    public override int CountDocuments => _documentInfo.Count;
    public override int CountValues => _dictionary.Count;
    public override IEnumerable<Guid> DocumentGuids => _documentInfo.Select(x => x.Key);

    public override string this[int index] => _reverse.ContainsKey(index) ? _reverse[index] : string.Empty;

    public override int this[string index] => _dictionary.ContainsKey(index) ? _dictionary[index] : -1;

    public override int[][] this[Guid guid]
    {
      get => _documentInfo.ContainsKey(guid) ? ReadDocument(guid) : null;
      set => throw new NotImplementedException();
    }

    public override IEnumerable<string> Values => _dictionary.Keys;

    public override bool ContainsDocument(Guid guid)
    {
      return _documentInfo.ContainsKey(guid);
    }

    public override AbstractLayerAdapter Copy()
    {
      var res = new LayerAdapterWriteIndirect
      {
        _guid = Guid.NewGuid(),
        _path = _path,
        _documentInfo = _documentInfo.ToDictionary(x => x.Key, x => x.Value),
        _dictionary = _dictionary.ToDictionary(x => x.Key, x => x.Value),
        Displayname = Displayname
      };
      res.RefreshDictionaries();
      return res;
    }

    public override AbstractLayerAdapter Copy(Guid documentGuid)
    {
      throw new NotImplementedException();
    }

    public static AbstractLayerAdapter Create(AbstractLayerState layer)
    {
      throw new NotImplementedException();
    }

    public static LayerAdapterWriteIndirect Create(Stream fs, string corpusPath)
    {
      try
      {
        var res = new LayerAdapterWriteIndirect
        {
          _dictionary = new Dictionary<string, int>(),
          _reverse = new Dictionary<int, string>(),
          _documentInfo = new Dictionary<Guid, long>(),
          _path = corpusPath
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

          res._documentInfo.Add(guid, DocumentSerializerHelper.DeserializeDocumentStreamPosition(fs));
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
      throw new NotImplementedException();
    }

    public override Dictionary<Guid, int[][]> GetDocumentDictionary()
    {
      return _documentInfo.ToDictionary(x => x.Key, x => ReadDocument(x.Key));
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
      stop = stop <= start ? start + 1 : stop;

      var res = new List<IEnumerable<string>>();
      for (var i = start; i < stop; i++)
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
      throw new NotImplementedException();
    }

    public override bool SetQuickStreamDocumentAnnotation(Guid documentGuid, IEnumerable<string> streamDocument)
    {
      throw new NotImplementedException();
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
      var rx = new Regex(regEx);
      return from x in _dictionary where rx.IsMatch(x.Key) select x.Key;
    }

    internal void Save(FileStream fs)
    {
      throw new NotImplementedException();
    }

    private int[][] ReadDocument(Guid dsel)
    {
      lock (_streamLock)
        return DocumentSerializerHelper.DeserializeDocumentFromStreamPosition(GetStream(), _documentInfo[dsel]);
    }

    private Stream GetStream()
    {
      if (_fs != null && _stream != null && _fs.CanRead && _stream.CanRead)
        return _stream;

      _stream?.Close();
      _fs?.Close();

      _fs = new FileStream(_path, FileMode.Open, FileAccess.Read, FileShare.Read);
      _stream = new BufferedStream(_fs);
      return _stream;
    }

    public void Dispose()
    {
      _fs?.Dispose();
      _stream?.Dispose();
      _dictionary?.Clear();
      _reverse?.Clear();
      _documentInfo?.Clear();
    }
  }
}