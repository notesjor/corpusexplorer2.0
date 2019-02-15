using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Interface;

namespace CorpusExplorer.Sdk.Utils.Filter.Queries
{
  [XmlRoot]
  [Serializable]
  public class FilterQuerySingleLayerFirstFollowedByAnyOtherMatch : AbstractFilterQuery, IFilterQueryWithLayerValues
  {
    protected readonly object _getCachedIndicesLock = new object();
    [XmlIgnore] protected Dictionary<Guid, KeyValuePair<int, HashSet<int>>> _cache;
    [XmlAttribute] private IEnumerable<string> _layerQueries;

    /// <summary>
    ///   Gets or sets the layer displayname.
    /// </summary>
    [XmlAttribute("layer")]
    public string LayerDisplayname { get; set; }

    /// <summary>
    ///   Gibt eine automatisch generierte Zusammenfassung des Inhalts/Bedeutung zurück.
    /// </summary>
    /// <value>The verbal.</value>
    [XmlIgnore]
    public override string Verbal
    {
      get
      {
        var vals = new List<string>(LayerQueries);
        var first = vals[0];
        vals.RemoveAt(0);
        var values = string.Join(", ", vals);
        if (values.Length > 50)
          values = values.Substring(0, 47) + "...";
        return $"Wert \"{first}\" gefolgt von einem der folgenden Werte ({values}) im Dokument.";
      }
    }

    /// <summary>
    ///   Gets or sets the layer queries.
    /// </summary>
    [XmlIgnore]
    public IEnumerable<string> LayerQueries
    {
      get => _layerQueries;
      set
      {
        _layerQueries = value;
        ClearCache();
      }
    }

    private void ClearCache()
    {
      lock (_getCachedIndicesLock)
      {
        _cache = new Dictionary<Guid, KeyValuePair<int, HashSet<int>>>();
      }
    }

    protected virtual KeyValuePair<int, HashSet<int>>? GetCachedIndices(AbstractLayerAdapter layer)
    {
      lock (_getCachedIndicesLock)
      {
        if (_cache.ContainsKey(layer.Guid))
          return _cache[layer.Guid];

        var vals = new List<string>(LayerQueries);
        var first = vals[0];
        vals.RemoveAt(0);

        var res = new KeyValuePair<int, HashSet<int>>(layer[first], new HashSet<int>(layer.ValuesToIndices(vals)));
        _cache.Add(layer.Guid, res);
        return res;
      }
    }

    protected override int GetSentenceFirstIndexCall(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence)
    {
      if (corpus == null || documentGuid == Guid.Empty)
        return -1;
      var layer = corpus.GetLayerOfDocument(documentGuid, LayerDisplayname);
      var doc = layer?[documentGuid];
      if (doc == null || sentence < 0 || sentence >= doc.Length)
        return -1;
      var queries = GetCachedIndices(layer);
      if (queries == null || queries.Value.Value.Count == 0)
        return -1;

      for (var j = 0; j < doc[sentence].Length; j++)
        if (doc[j].Any(w => w == queries.Value.Key) || doc[j].Any(w => queries.Value.Value.Contains(w)))
          return j;

      return -1;
    }

    protected override IEnumerable<int> GetSentencesCall(AbstractCorpusAdapter corpus, Guid documentGuid)
    {
      if (corpus == null || documentGuid == Guid.Empty)
        return null;
      var layer = corpus.GetLayerOfDocument(documentGuid, LayerDisplayname);
      var doc = layer?[documentGuid];
      if (doc == null)
        return null;
      var queries = GetCachedIndices(layer);
      if (queries == null || queries.Value.Value.Count == 0)
        return null;

      var res = new HashSet<int>();
      for (var s = 0; s < doc.Length; s++)
        for (var i = 0; i < doc[s].Length; i++)
          if (doc[s][i] == queries.Value.Key)
            for (var j = i + 1; j < doc[s].Length; j++)
              if (queries.Value.Value.Contains(doc[s][j]))
              {
                res.Add(s);
                break;
              }

      return res;
    }

    public override IEnumerable<int> GetWordIndices(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence)
    {
      if (corpus == null || documentGuid == Guid.Empty)
        return null;
      var layer = corpus.GetLayerOfDocument(documentGuid, LayerDisplayname);
      var doc = layer?[documentGuid];
      if (doc == null || sentence < 0 || sentence >= doc.Length)
        return null;
      var queries = GetCachedIndices(layer);
      if (queries == null || queries.Value.Value.Count == 0)
        return null;

      var res = new HashSet<int>();
      for (var i = 0; i < doc[sentence].Length; i++)
        if (doc[sentence][i] == queries.Value.Key)
          for (var j = i + 1; j < doc[sentence].Length; j++)
            if (queries.Value.Value.Contains(doc[sentence][j]))
            {
              res.Add(i);
              res.Add(j);
              break;
            }

      return res;
    }

    protected override bool ValidateCall(AbstractCorpusAdapter corpus, Guid documentGuid)
    {
      if (corpus == null || documentGuid == Guid.Empty)
        return false;
      var layer = corpus.GetLayerOfDocument(documentGuid, LayerDisplayname);
      var doc = layer?[documentGuid];
      if (doc == null)
        return false;
      var queries = GetCachedIndices(layer);
      if (queries == null || queries.Value.Value.Count == 0)
        return false;

      foreach (var s in doc)
        for (var i = 0; i < s.Length; i++)
          if (s[i] == queries.Value.Key)
            for (var j = i + 1; j < s.Length; j++)
              if (queries.Value.Value.Contains(s[j]))
                return true;

      return false;
    }

    /// <summary>
    ///   Erstellt ein neues Objekt, das eine Kopie der aktuellen Instanz darstellt.
    /// </summary>
    /// <returns>
    ///   Ein neues Objekt, das eine Kopie dieser Instanz darstellt.
    /// </returns>
    public override object Clone()
    {
      return new FilterQuerySingleLayerFirstFollowedByAnyOtherMatch
      {
        Inverse = Inverse,
        LayerDisplayname = LayerDisplayname,
        LayerQueries = LayerQueries,
        OrFilterQueries = OrFilterQueries.Select(q => q.Clone() as AbstractFilterQuery)
      };
    }
  }
}