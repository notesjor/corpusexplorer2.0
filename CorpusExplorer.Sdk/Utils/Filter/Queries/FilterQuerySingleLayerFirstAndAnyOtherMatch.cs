using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Interface;

namespace CorpusExplorer.Sdk.Utils.Filter.Queries
{
  [XmlRoot]
  [Serializable]
  public class FilterQuerySingleLayerFirstAndAnyOtherMatch : AbstractFilterQuery, IFilterQueryWithLayerValues
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
        return $"Wert \"{first}\" und einer der folgenden Werte ({values}) im Dokument.";
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

    protected override CeRange? GetSentenceFirstIndexCall(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence)
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

      for (var j = 0; j < doc[sentence].Length; j++)
        if (doc[j].Any(w => w == queries.Value.Key) || doc[j].Any(w => queries.Value.Value.Contains(w)))
          return new CeRange(j);

      return null;
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

      var res = new List<int>();
      for (var i = 0; i < doc.Length; i++)
        if (doc[i].Any(w => w == queries.Value.Key) && doc[i].Any(w => queries.Value.Value.Contains(w)))
          res.Add(i);

      return res;
    }

    public override IEnumerable<CeRange> GetWordIndices(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence)
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

      var res = new List<CeRange>();
      for (var j = 0; j < doc[sentence].Length; j++)
        if (doc[sentence][j] == queries.Value.Key || queries.Value.Value.Contains(doc[sentence][j]))
          res.Add(new CeRange(j));

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

      return doc.Any(s => s.Any(w => w == queries.Value.Key) && s.Any(w => queries.Value.Value.Contains(w)));
    }

    /// <summary>
    ///   Erstellt ein neues Objekt, das eine Kopie der aktuellen Instanz darstellt.
    /// </summary>
    /// <returns>
    ///   Ein neues Objekt, das eine Kopie dieser Instanz darstellt.
    /// </returns>
    public override object Clone()
    {
      return new FilterQuerySingleLayerFirstAndAnyOtherMatch
      {
        Inverse = Inverse,
        LayerDisplayname = LayerDisplayname,
        LayerQueries = LayerQueries,
        OrFilterQueries = OrFilterQueries.Select(q => q.Clone() as AbstractFilterQuery)
      };
    }
  }
}