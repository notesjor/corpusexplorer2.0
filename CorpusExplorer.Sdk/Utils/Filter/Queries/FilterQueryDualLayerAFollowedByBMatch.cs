using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;

namespace CorpusExplorer.Sdk.Utils.Filter.Queries
{
  [XmlRoot]
  [Serializable]
  public class FilterQueryDualLayerAFollowedByBMatch : AbstractFilterQuery
  {
    protected readonly object _getCachedIndicesLock = new object();
    [XmlIgnore] protected Dictionary<string, KeyValuePair<int, int>> _cache;
    [XmlAttribute] private string _layerQuery1;
    [XmlAttribute] private string _layerQuery2;

    /// <summary>
    ///   Gets or sets the layer displayname.
    /// </summary>
    [XmlAttribute("layer1")]
    public string LayerDisplayname1 { get; set; } = "Wort";

    /// <summary>
    ///   Gets or sets the layer displayname.
    /// </summary>
    [XmlAttribute("layer2")]
    public string LayerDisplayname2 { get; set; } = "Wort";

    /// <summary>
    ///   Gibt eine automatisch generierte Zusammenfassung des Inhalts/Bedeutung zurück.
    /// </summary>
    /// <value>The verbal.</value>
    [XmlIgnore]
    public override string Verbal
    {
      get
      {
        return $"\"{LayerDisplayname1}\" = \"{LayerQuery1}\" gefolgt von \"{LayerDisplayname2}\" = \"{LayerQuery2}\" im Dokument.";
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
        _cache = new Dictionary<string, KeyValuePair<int, int>>();
      }
    }

    protected virtual KeyValuePair<int, int>? GetCachedIndices(AbstractLayerAdapter layer1, AbstractLayerAdapter layer2)
    {
      lock (_getCachedIndicesLock)
      {
        var key = $"{layer1.Guid:N}-{layer2.Guid:N}";
        if (_cache.ContainsKey(key))
          return _cache[key];

        var res = new KeyValuePair<int, int>(layer1[LayerQuery1], layer2[LayerQuery2]);
        _cache.Add(key, res);
        return res;
      }
    }

    private bool PrepareCall(AbstractCorpusAdapter corpus, Guid documentGuid, out int[][] doc1, out int[][] doc2, out KeyValuePair<int, int>? queries)
    {
      doc1 = doc2 = null;
      queries = null;

      if (corpus == null || documentGuid == Guid.Empty)
        return false;

      var layer1 = corpus.GetLayerOfDocument(documentGuid, LayerDisplayname1);
      doc1 = layer1?[documentGuid];
      if (doc1 == null)
        return false;

      var layer2 = corpus.GetLayerOfDocument(documentGuid, LayerDisplayname2);
      doc2 = layer2?[documentGuid];
      if (doc2 == null)
        return false;

      if (doc1.Length != doc2.Length)
        return false;

      queries = GetCachedIndices(layer1, layer2);
      return queries != null;
    }

    protected override CeRange? GetSentenceFirstIndexCall(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence)
    {
      if (!PrepareCall(corpus, documentGuid, out var doc1, out var doc2, out var queries))
        return null;
      if (sentence < 0 || sentence >= doc1.Length || doc1.Length != doc2.Length)
        return null;

      for (var s1 = 0; s1 < doc1[sentence].Length; s1++)
        if (doc1[s1].Any(w => w == queries.Value.Key) || doc2[s1].Any(w => queries.Value.Value == w))
          return new CeRange(s1);

      return null;
    }

    protected override IEnumerable<int> GetSentencesCall(AbstractCorpusAdapter corpus, Guid documentGuid)
    {
      if (!PrepareCall(corpus, documentGuid, out var doc1, out var doc2, out var queries))
        return null;

      var res = new HashSet<int>();
      for (var s1 = 0; s1 < doc1.Length; s1++)
        for (var t1 = 0; t1 < doc1[s1].Length; t1++)
          if (doc1[s1][t1] == queries.Value.Key)
            for (var t2 = t1 + 1; t2 < doc2[s1].Length; t2++)
              if (queries.Value.Value == doc2[s1][t2])
              {
                res.Add(s1);
                break;
              }

      return res;
    }

    public override IEnumerable<CeRange> GetWordIndices(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence)
    {
      if (!PrepareCall(corpus, documentGuid, out var doc1, out var doc2, out var queries))
        return null;
      if (sentence < 0 || sentence >= doc1.Length || doc1.Length != doc2.Length)
        return null;

      var res = new HashSet<CeRange>();
      for (var t1 = 0; t1 < doc1[sentence].Length; t1++)
        if (doc1[sentence][t1] == queries.Value.Key)
          for (var t2 = t1 + 1; t2 < doc2[sentence].Length; t2++)
            if (queries.Value.Value == doc2[sentence][t2])
            {
              res.Add(new CeRange(t1, t2));
              break;
            }

      return res;
    }

    protected override bool ValidateCall(AbstractCorpusAdapter corpus, Guid documentGuid)
    {
      if (!PrepareCall(corpus, documentGuid, out var doc1, out var doc2, out var queries))
        return false;

      for (var s1 = 0; s1 < doc1.Length; s1++)
        for (var t1 = 0; t1 < doc1[s1].Length; t1++)
          if (doc1[s1][t1] == queries.Value.Key)
            for (var t2 = t1 + 1; t2 < doc2[s1].Length; t2++)
              if (queries.Value.Value == doc2[s1][t2])
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
      return new FilterQueryDualLayerAFollowedByBMatch
      {
        Inverse = Inverse,
        LayerDisplayname1 = LayerDisplayname1,
        LayerDisplayname2 = LayerDisplayname2,
        LayerQuery1 = LayerQuery1,
        LayerQuery2 = LayerQuery2,
        OrFilterQueries = OrFilterQueries.Select(q => q.Clone() as AbstractFilterQuery)
      };
    }
  }
}