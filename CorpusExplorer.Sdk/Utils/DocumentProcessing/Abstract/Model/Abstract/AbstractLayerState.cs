using System;
using System.Collections.Generic;
using System.Linq;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract
{
  public abstract class AbstractLayerState : IDisposable
  {
    private object _cacheLock = new object();

    protected AbstractLayerState(string displayname)
    {
      Displayname = displayname;
      Documents = new Dictionary<Guid, int[][]>();
      Cache = new Dictionary<string, int>();
    }

    public Dictionary<string, int> Cache { get; set; }
    public string Displayname { get; set; }
    public Dictionary<Guid, int[][]> Documents { get; set; }
    public abstract bool AllowAnnotation(string[] data);
    public abstract bool AllowValueChange(string[] data);

    public int GetDocumentLengthInSentences(Guid documentGuid)
    {
      return !Documents.ContainsKey(documentGuid) ? 0 : Documents[documentGuid].Length;
    }

    public int GetDocumentLengthInWords(Guid documentGuid)
    {
      return !Documents.ContainsKey(documentGuid) ? 0 : Documents[documentGuid].SelectMany(s => s).Count();
    }

    /// <summary>
    ///   Gibt einen AbstractLayerState zur�ck, der nur das gew�nschte Dokument beinhaltet.
    ///   Wird z. B. daf�r verwendet um ein Korpus in ein Lightweight-Korpus aufzuspalten.
    /// </summary>
    /// <param name="documentGuid">Ausgew�hltes Dokument</param>
    /// <returns>AbstractLayerState f�r ein Dokument</returns>
    public AbstractLayerState Reduce(Guid documentGuid)
    {
      if (!Documents.ContainsKey(documentGuid))
        return null;

      var doc = Documents[documentGuid];

      var res = new LayerRangeState(Displayname) {Documents = new Dictionary<Guid, int[][]> {{documentGuid, doc}}};

      var tmp = Cache.ToDictionary(x => x.Value, x => x.Key);
      var dic = new Dictionary<string, int>();
      foreach (var s in doc)
      foreach (var w in s)
      {
        var key = tmp[w];
        if (!dic.ContainsKey(key))
          dic.Add(key, w);
      }

      res.Cache = dic;

      return res;
    }

    public abstract int RequestIndex(string[] data, int lastIndex);

    protected int RequestIndex(string data)
    {
      lock (_cacheLock)
      {
        if (Cache.ContainsKey(data))
          return Cache[data];

        var res = Cache.Count;
        Cache.Add(data, res);
        return res;
      }
    }

    public void Dispose()
    {
      Cache.Clear();
      Documents.Clear();
    }
  }
}