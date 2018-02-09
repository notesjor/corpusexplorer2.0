using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  public class DocumentBestSnippetBlock : AbstractSimple1LayerBlock
  {
    private readonly object _getLayerHashLock = new object();
    private readonly object _resultLock = new object();
    private Dictionary<Guid, HashSet<int>> _layerCache;

    public DocumentBestSnippetBlock()
    {
      LayerDisplayname = "Wort";
      LayerQueries = new List<string>();
    }

    public IEnumerable<string> LayerQueries { get; set; }
    public Dictionary<Guid, int[]> ResultDocumentSentenceRank { get; set; }

    protected override void CalculateCall(
      AbstractCorpusAdapter corpus,
      AbstractLayerAdapter layer,
      Guid dsel,
      int[][] doc)
    {
      var values = GetLayerHash(layer);

      var sentences = doc.Select(s => s.Count(w => values.Contains(w))).ToArray();

      lock (_resultLock)
      {
        ResultDocumentSentenceRank.Add(dsel, sentences);
      }
    }

    protected override void CalculateCleanup() { _layerCache.Clear(); }
    protected override void CalculateFinalize() { }

    protected override void CalculateInitProperties()
    {
      _layerCache = new Dictionary<Guid, HashSet<int>>();
      ResultDocumentSentenceRank = new Dictionary<Guid, int[]>();
    }

    public Dictionary<Guid, int> GetBestDocument()
    {
      return ResultDocumentSentenceRank.AsParallel().ToDictionary(doc => doc.Key, doc => doc.Value.Sum());
    }

    public Dictionary<Guid, string> GetBestReadableSnippet(int numberOfSenteces)
    {
      var res = new Dictionary<Guid, string>();
      foreach (var doc in ResultDocumentSentenceRank)
      {
        var sid = GetBestSentences(doc.Key, numberOfSenteces);
        if (sid < 0)
          continue;
        res.Add(
          doc.Key,
          Selection.GetReadableDocumentSnippet(
                     doc.Key,
                     LayerDisplayname,
                     sid,
                     sid + numberOfSenteces)
                   .ReduceDocumentToText());
      }
      return res;
    }

    public Dictionary<Guid, int> GetBestSentences(int numberOfSenteces)
    {
      var res = new Dictionary<Guid, int>();
      foreach (var doc in ResultDocumentSentenceRank)
      {
        var sid = GetBestSentences(doc.Key, numberOfSenteces);
        if (sid < 0)
          continue;
        res.Add(doc.Key, sid);
      }

      return res;
    }

    /// <summary>
    ///   Sucht nach den Sätzen mit dem höchsten Score in einem Dokument
    /// </summary>
    /// <param name="documentGuid">Dokument</param>
    /// <param name="numberOfSentences">Wieviele Sätze sollen berücksichtigt werden?</param>
    /// <returns>Index des ersten Satzes</returns>
    private int GetBestSentences(Guid documentGuid, int numberOfSentences)
    {
      if (!ResultDocumentSentenceRank.ContainsKey(documentGuid))
        return -1;

      var sents = ResultDocumentSentenceRank[documentGuid];
      var max = 0;
      var res = -1;

      for (var i = 0; i < sents.Length; i++)
      {
        var sum = 0;
        for (var j = 0; j < numberOfSentences; j++)
        {
          if (i + j == sents.Length)
            break;
          sum += sents[i + j];
        }
        if (sum > max)
        {
          max = sum;
          res = i;
        }
      }

      return res;
    }

    private HashSet<int> GetLayerHash(AbstractLayerAdapter layer)
    {
      lock (_getLayerHashLock)
      {
        if (_layerCache.ContainsKey(layer.Guid))
          return _layerCache[layer.Guid];

        var hash = new HashSet<int>(LayerQueries.Select(query => layer[query]));
        _layerCache.Add(layer.Guid, hash);
        return hash;
      }
    }
  }
}