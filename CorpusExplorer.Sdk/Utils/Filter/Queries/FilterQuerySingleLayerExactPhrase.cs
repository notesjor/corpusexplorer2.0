using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;

namespace CorpusExplorer.Sdk.Utils.Filter.Queries
{
  [XmlRoot]
  [Serializable]
  public class FilterQuerySingleLayerExactPhrase : AbstractFilterQuery
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

    [XmlAttribute("layer")] public string LayerDisplayname { get; set; } = "Wort";

    [XmlIgnore]
    public IEnumerable<string> LayerQueries
    {
      get => _layerQueries;
      set
      {
        Eoi = value.Count() - 1;
        _layerQueries = value;
        _layerQueryCache = new Dictionary<Guid, int[]>();
      }
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
        var values = string.Join(", ", LayerQueries);
        if (values.Length > 50)
          values = values.Substring(0, 47) + "...";
        return string.Format(Resources.SearchForPhrases, values);
      }
    }

    /// <summary>
    ///   End of Index - wird von GetWordIndices verwendet um das Ende des Musters zu bestimmen.
    /// </summary>
    /// <value>The eoi.</value>
    [XmlIgnore]
    private int Eoi { get; set; }

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
    protected override int GetSentenceFirstIndexCall(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence)
    {
      if (corpus == null || documentGuid == Guid.Empty)
        return -1;
      var queries = GetQueries(corpus);
      if (queries == null || queries.Length == 0)
        return -1;
      var layer = corpus.GetLayerOfDocument(documentGuid, LayerDisplayname);
      var doc = layer?[documentGuid];
      if (doc == null || sentence < 0 || sentence >= doc.Length)
        return -1;

      var s = doc[sentence];
      var sum = queries.Count(q => q > -1);

      for (var i = 0; sum + i < s.Length; i++)
        if (!queries.Where((t, j) => t != -1 && (i + j >= s.Length || s[i + j] != t)).Any())
          return i;

      return -1;
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
        var doc = layer?[documentGuid];
        if (doc == null)
          return null;

        var res = new List<int>();
        var sum = queries.Count(q => q > -1);

        if (Configuration.RightToLeftSupport)
        {
        }
        else
        {
          for (var i = 0; i < doc.Length; i++)
          {
            if (doc[i] == null)
              continue;
            for (var j = 0; sum + j < doc[i].Length; j++)
              if (!queries.Where((t, k) => t != -1 && (j + k >= doc[i].Length || doc[i][j + k] != t)).Any())
                res.Add(i);
          }
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
    public override IEnumerable<int> GetWordIndices(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence)
    {
      if (corpus == null ||
          documentGuid == Guid.Empty)
        return null;
      var queries = GetQueries(corpus);
      if (queries == null ||
          queries.Length == 0)
        return null;
      var layer = corpus.GetLayerOfDocument(documentGuid, LayerDisplayname);
      var doc = layer?[documentGuid];
      if (doc == null ||
          sentence < 0 ||
          sentence >= doc.Length)
        return null;

      var s = doc[sentence];

      var sum = queries.Count(q => q > -1);
      var res = new List<int>();

      for (var i = 0; sum + i < s.Length; i++)
      {
        if (queries.Where((t, j) => t != -1 && (i + j >= s.Length || s[i + j] != t)).Any())
          continue;
        res.Add(i);
        res.Add(i + Eoi);
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
      var doc = layer?[documentGuid];
      if (doc == null)
        return false;

      foreach (var s in doc)
      {
        var sum = queries.Count(q => q > -1);

        if (Configuration.RightToLeftSupport)
          for (var i = s.Length; i > sum; i--)
          {
            var any = false;
            for (var j = queries.Length; j > 0; j--)
            {
              var t = queries[j];
              if (i + j < s.Length && (t == -1 || s[i + j] == t))
                continue;
              any = true;
              break;
            }

            if (!any)
              return true;
          }
        else
          for (var i = 0; sum + i < s.Length; i++)
            if (!queries.Where((t, j) => i + j >= s.Length || t != -1 && s[i + j] != t).Any())
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