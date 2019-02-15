using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;

namespace CorpusExplorer.Sdk.Utils.Filter.Queries
{
  [XmlRoot]
  [Serializable]
  public class FilterQuerySingleLayerAFollowedByBSpanMatch : AbstractFilterQuery
  {
    protected readonly object _getCachedIndicesLock = new object();
    [XmlIgnore] protected Dictionary<Guid, KeyValuePair<int, int>> _cache;
    [XmlAttribute] private string _layerQuery1;
    [XmlAttribute] private string _layerQuery2;
    [XmlAttribute("span")] private int _wordSpan;

    /// <summary>
    ///   Gets or sets the layer displayname.
    /// </summary>
    [XmlAttribute("layer")]
    public string LayerDisplayname { get; set; }

    [XmlIgnore]
    public int WordSpan
    {
      get => _wordSpan;
      set => _wordSpan = value;
    }

    /// <summary>
    ///   Gibt eine automatisch generierte Zusammenfassung des Inhalts/Bedeutung zurück.
    /// </summary>
    /// <value>The verbal.</value>
    [XmlIgnore]
    public override string Verbal
    {
      get
      {
        return $"Wert \"{LayerQuery1}\" gefolgt von Wert \"{LayerQuery2}\" im Dokument.";
      }
    }

    /// <summary>
    ///   Gets or sets the layer query A (first)
    /// </summary>
    [XmlIgnore]
    public string LayerQuery1
    {
      get => _layerQuery1;
      set
      {
        _layerQuery1 = value;
        ClearCache();
      }
    }

    /// <summary>
    ///   Gets or sets the layer query B (followed LayerQuery1)
    /// </summary>
    [XmlIgnore]
    public string LayerQuery2
    {
      get => _layerQuery2;
      set
      {
        _layerQuery2 = value;
        ClearCache();
      }
    }

    private void ClearCache()
    {
      lock (_getCachedIndicesLock)
      {
        _cache = new Dictionary<Guid, KeyValuePair<int, int>>();
      }
    }

    protected virtual KeyValuePair<int, int>? GetCachedIndices(AbstractLayerAdapter layer)
    {
      lock (_getCachedIndicesLock)
      {
        if (_cache.ContainsKey(layer.Guid))
          return _cache[layer.Guid];

        var res = new KeyValuePair<int, int>(layer[LayerQuery1], layer[LayerQuery2]);
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
      if (queries == null)
        return -1;

      for (var i = 0; i < doc[sentence].Length; i++)
        if (doc[sentence][i] == queries.Value.Key)
          for (var j = i + 1; j < doc[sentence].Length; j++)
            if (queries.Value.Value == doc[sentence][j] && j - i == WordSpan)
              return i;

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
      if (queries == null)
        return null;

      var res = new HashSet<int>();
      for (var s = 0; s < doc.Length; s++)
      for (var i = 0; i < doc[s].Length; i++)
        if (doc[s][i] == queries.Value.Key)
          for (var j = i + 1; j < doc[s].Length; j++)
            if (queries.Value.Value == doc[s][j] && j - i == WordSpan)
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
      if (queries == null)
        return null;

      var res = new HashSet<int>();
      for (var i = 0; i < doc[sentence].Length; i++)
        if (doc[sentence][i] == queries.Value.Key)
          for (var j = i + 1; j < doc[sentence].Length; j++)
            if (queries.Value.Value == doc[sentence][j] && j - i == WordSpan)
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
      if (queries == null)
        return false;

      foreach (var s in doc)
        for (var i = 0; i < s.Length; i++)
          if (s[i] == queries.Value.Key)
            for (var j = i + 1; j < s.Length; j++)
              if (queries.Value.Value == s[j] && j - i == WordSpan)
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
      return new FilterQuerySingleLayerAFollowedByBSpanMatch
      {
        Inverse = Inverse,
        LayerDisplayname = LayerDisplayname,
        LayerQuery1 = LayerQuery1,
        LayerQuery2 = LayerQuery2,
        WordSpan = WordSpan,
        OrFilterQueries = OrFilterQueries.Select(q => q.Clone() as AbstractFilterQuery)
      };
    }
  }
}