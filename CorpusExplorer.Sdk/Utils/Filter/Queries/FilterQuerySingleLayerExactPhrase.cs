using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Interface;
using CorpusExplorer.Sdk.Utils.FlatDocument;

namespace CorpusExplorer.Sdk.Utils.Filter.Queries
{
  [XmlRoot]
  [Serializable]
  public class FilterQuerySingleLayerExactPhrase : AbstractFilterQuery, IFilterQueryWithLayerValues
  {
    [XmlAttribute("pattern")] public static readonly string SearchPattern = ".<*>.";

    [XmlIgnore] private readonly object _getQueriesLock = new object();

    [XmlIgnore] private readonly object _getSentenceCallLock = new object();

    [XmlArray] private IEnumerable<string> _layerQueries;

    [XmlIgnore] private Dictionary<Guid, int[]> _layerQueryCache;

    public FilterQuerySingleLayerExactPhrase()
    {
      _layerQueryCache = new Dictionary<Guid, int[]>();
    }

    [XmlAttribute("layer")]
    public string LayerDisplayname { get; set; } = "Wort";

    /// <summary>
    ///   Gibt eine automatisch generierte Zusammenfassung des Inhalts/Bedeutung zurück.
    /// </summary>
    /// <value>The verbal.</value>
    [XmlIgnore]
    public override string Verbal
    {
      get
      {
        var values = string.Join(", ", LayerQueries);
        if (values.Length > 50)
          values = values.Substring(0, 47) + "...";
        return string.Format(Resources.SearchForPhrases, values);
      }
    }

    [XmlIgnore]
    public IEnumerable<string> LayerQueries
    {
      get => _layerQueries;
      set
      {
        _layerQueries = value;
        _layerQueryCache = new Dictionary<Guid, int[]>();
      }
    }

    /// <summary>
    ///   Erstellt ein neues Objekt, das eine Kopie der aktuellen Instanz darstellt.
    /// </summary>
    /// <returns>
    ///   Ein neues Objekt, das eine Kopie dieser Instanz darstellt.
    /// </returns>
    public override object Clone()
    {
      return new FilterQuerySingleLayerExactPhrase
      {
        Inverse = Inverse,
        LayerDisplayname = LayerDisplayname,
        LayerQueries = LayerQueries,
        OrFilterQueries = OrFilterQueries.Select(q => q.Clone() as AbstractFilterQuery)
      };
    }

    /// <summary>
    ///   The get sentences index.
    /// </summary>
    /// <param name="corpus">
    ///   The corpus.
    /// </param>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <param name="sentence">
    ///   The sentence.
    /// </param>
    /// <returns>
    ///   The <see cref="int" />.
    /// </returns>
    protected override CeRange? GetSentenceFirstIndexCall(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence)
    {
      if (corpus == null || documentGuid == Guid.Empty)
        return null;
      var queries = GetQueries(corpus);
      if (queries == null || queries.Length == 0)
        return null;
      var layer = corpus.GetLayerOfDocument(documentGuid, LayerDisplayname);
      var odoc = layer?[documentGuid];
      if (odoc == null || sentence < 0 || sentence >= odoc.Length)
        return null;

      var sum = queries.Count();

      using (var doc = new DocumentFlattener(odoc))
      {
        var start = doc.GetSentenceStartIndex(sentence);
        if (start == -1)
          return null;

        for (var i = start; i < doc.FlatDocument.Length; i++)
        {
          if (doc.FlatDocument[i] != queries[0])
            continue;

          var valid = true;
          for (var q = 1; q < sum; q++)
          {
            if (doc.FlatDocument[i + q] == queries[q])
              continue;

            valid = false;
            break;
          }

          if (!valid)
            continue;

          var idx = doc.GetIndex(i).Value;
          return new CeRange(idx, idx + sum);
        }
      }

      return null;
    }

    /// <summary>
    ///   The get sentences.
    /// </summary>
    /// <param name="corpus">
    ///   The corpus.
    /// </param>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <returns>
    ///   The <see cref="IEnumerable{T}" />.
    /// </returns>
    protected override IEnumerable<int> GetSentencesCall(AbstractCorpusAdapter corpus, Guid documentGuid)
    {
      lock (_getSentenceCallLock)
      {
        if (corpus == null ||
            documentGuid == Guid.Empty)
          return null;
        var queries = GetQueries(corpus);
        if (queries == null ||
            queries.Length == 0)
          return null;
        var layer = corpus.GetLayerOfDocument(documentGuid, LayerDisplayname);
        var odoc = layer?[documentGuid];
        if (odoc == null)
          return null;

        var res = new HashSet<int>();
        var sum = queries.Count();

        using (var doc = new DocumentFlattener(odoc))
          for (var i = 0; i < doc.FlatDocument.Length; i++)
          {
            if (doc.FlatDocument[i] != queries[0])
              continue;

            var valid = true;
            for (var q = 1; q < sum; q++)
            {
              if (doc.FlatDocument[i + q] == queries[q])
                continue;

              valid = false;
              break;
            }

            if (valid)
              res.Add(doc.GetIndex(i).Key);
          }

        return res;
      }
    }

    /// <summary>
    ///   Gibt alle Wort-Index Übereinstimmungen zurück die das Query oder desseb OrQuery in gewählten Korpus - Dokument - Satz
    ///   hat.
    /// </summary>
    /// <param name="corpus">Korpus der das Dokument enthält.</param>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <param name="sentence">
    ///   ID des Satzes der die FUnstelle enthalten soll. Alle validen Sätze können zuvor mit
    ///   GetSentenceIndices() abgefragt werden.
    /// </param>
    /// <returns>Auflistung aller Vorkommen im Satz</returns>
    public override IEnumerable<CeRange> GetWordIndices(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence)
    {
      if (corpus == null ||
          documentGuid == Guid.Empty)
        return null;
      var queries = GetQueries(corpus);
      if (queries == null ||
          queries.Length == 0)
        return null;
      var layer = corpus.GetLayerOfDocument(documentGuid, LayerDisplayname);
      var odoc = layer?[documentGuid];
      if (odoc == null || sentence < 0 || sentence >= odoc.Length)
        return null;

      var sum = queries.Count();
      var res = new List<CeRange>();

      using (var doc = new DocumentFlattener(odoc))
      {
        var start = doc.GetSentenceStartIndex(sentence);
        if (start == -1)
          return null;
        var stop = doc.GetSentenceStartIndex(sentence + 1);
        if (stop == -1)
          stop = doc.FlatDocument.Length;

        for (var i = start; i < stop; i++)
        {
          if (doc.FlatDocument[i] != queries[0])
            continue;

          var valid = true;
          for (var q = 1; q < sum; q++)
          {
            if (doc.FlatDocument[i + q] == queries[q])
              continue;

            valid = false;
            break;
          }

          if (!valid)
            continue;

          var idx = doc.GetIndex(i).Value;
          res.Add(new CeRange(idx, idx + sum));
        }
      }

      return res;
    }

    /// <summary>
    ///   The validate call.
    /// </summary>
    /// <param name="corpus">
    ///   The corpus.
    /// </param>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <returns>
    ///   The <see cref="bool" />.
    /// </returns>
    protected override bool ValidateCall(AbstractCorpusAdapter corpus, Guid documentGuid)
    {
      if (corpus == null ||
          documentGuid == Guid.Empty)
        return false;
      var queries = GetQueries(corpus);
      if (queries == null ||
          queries.Length == 0)
        return false;
      var layer = corpus.GetLayerOfDocument(documentGuid, LayerDisplayname);
      var odoc = layer?[documentGuid];
      if (odoc == null)
        return false;

      var sum = queries.Count();

      using (var doc = new DocumentFlattener(odoc))
        for (var i = 0; i < doc.FlatDocument.Length; i++)
        {
          if (doc.FlatDocument[i] != queries[0])
            continue;

          var valid = true;
          for (var q = 1; q < sum; q++)
          {
            if (doc.FlatDocument[i + q] == queries[q])
              continue;

            valid = false;
            break;
          }

          if (!valid)
            continue;

          return true;
        }

      return false;
    }

    private int[] GetQueries(AbstractCorpusAdapter corpus)
    {
      lock (_getQueriesLock)
      {
        if (_layerQueryCache.ContainsKey(corpus.CorpusGuid))
          return _layerQueryCache[corpus.CorpusGuid];

        var layers = corpus.GetLayers(LayerDisplayname);
        var layer = layers?.FirstOrDefault();
        if (layer == null)
          return null;

        var valid = true;
        var res = new List<int>();
        foreach (var query in LayerQueries)
          if (query == SearchPattern)
          {
            res.Add(-1);
          }
          else
          {
            var idx = layer[query];
            if (idx == -1)
            {
              valid = false;
              break;
            }

            res.Add(idx);
          }

        if (res.Count == 0)
          valid = false;

        _layerQueryCache.Add(corpus.CorpusGuid, valid ? res.ToArray() : null);

        return valid ? res.ToArray() : null;
      }
    }
  }
}