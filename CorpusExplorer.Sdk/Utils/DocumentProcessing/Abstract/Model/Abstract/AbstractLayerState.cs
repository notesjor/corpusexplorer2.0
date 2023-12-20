using CorpusExplorer.Sdk.Model.CorpusExplorer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract
{
  public abstract class AbstractLayerState : IDisposable
  {
    private CeDictionary _dictionary;

    protected AbstractLayerState(string displayname, Dictionary<string, int> cache = null, Dictionary<Guid, int[][]> documents = null)
    {
      Displayname = displayname;
      _documents = documents ?? new Dictionary<Guid, int[][]>();
      _dictionary = cache == null ? new CeDictionary(new Dictionary<string, int>()) : new CeDictionary(cache);
    }

    public IEnumerable<KeyValuePair<string, int>> GetCache() => _dictionary.ReciveRawValueToIndex();
    public IEnumerable<KeyValuePair<Guid, int[][]>> GetDocuments() => _documents;
    public bool DocumentExists(Guid documentGuid) => _documents.ContainsKey(documentGuid);
    public void DocumentAdd(Guid documentGuid, int[][] document)
    {
      if (_documents.ContainsKey(documentGuid))
        _documents[documentGuid] = document;
      else
        _documents.Add(documentGuid, document);
    }
    public int[][] DocumentGet(Guid documentGuid) => _documents[documentGuid];
    internal void ForceReplaceDocument(Guid documentGuid, int[][] document) => _documents[documentGuid] = document;
    public void FlushDocuments() => _documents.Clear();
    internal void ForceReplaceCache(Dictionary<string, int> cache) => _dictionary = new CeDictionary(cache);

    public string Displayname { get; set; }
    public Dictionary<Guid, int[][]> _documents { get; set; }
    public abstract bool AllowAnnotation(string[] data);
    public abstract bool AllowValueChange(string[] data);

    public int GetDocumentLengthInSentences(Guid documentGuid)
    {
      return !_documents.ContainsKey(documentGuid) ? 0 : _documents[documentGuid].Length;
    }

    public int GetDocumentLengthInWords(Guid documentGuid)
    {
      return !_documents.ContainsKey(documentGuid) ? 0 : _documents[documentGuid].SelectMany(s => s).Count();
    }

    /// <summary>
    ///   Gibt einen AbstractLayerState zurück, der nur das gewünschte Dokument beinhaltet.
    ///   Wird z. B. dafür verwendet um ein Korpus in ein Lightweight-Korpus aufzuspalten.
    /// </summary>
    /// <param name="documentGuid">Ausgewähltes Dokument</param>
    /// <returns>AbstractLayerState für ein Dokument</returns>
    public AbstractLayerState Reduce(Guid documentGuid)
    {
      if (!_documents.ContainsKey(documentGuid))
        return null;

      var doc = _documents[documentGuid];

      var res = new LayerRangeState(Displayname) { _documents = new Dictionary<Guid, int[][]> { { documentGuid, doc } } };

      var dic = new Dictionary<string, int>();
      foreach (var s in doc)
        foreach (var w in s)
        {
          var key = _dictionary[w];
          if (!dic.ContainsKey(key))
            dic.Add(key, w);
        }

      res._dictionary = new CeDictionary(dic);

      return res;
    }

    public abstract int RequestIndex(string[] data, int lastIndex);

    public int RequestIndex(string data)
    {
      if (!_dictionary.Contains(data))
        _dictionary.Add(data);

      return _dictionary[data];
    }

    public void Dispose()
    {
      _dictionary.Clear();
      _documents.Clear();
    }
  }
}