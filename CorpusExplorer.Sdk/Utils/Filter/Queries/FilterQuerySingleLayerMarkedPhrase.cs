using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;

namespace CorpusExplorer.Sdk.Utils.Filter.Queries
{
  [XmlRoot]
  [Serializable]
  public class FilterQuerySingleLayerMarkedPhrase : AbstractFilterQuery
  {
    [XmlAttribute] public static readonly string SearchPattern = ".<*>.";

    [XmlIgnore] private readonly object _getQueriesLock = new object();

    [XmlIgnore] private readonly object _getSentenceCallLock = new object();

    [XmlArray] private string[] _layerQueries;

    [XmlIgnore] private ConcurrentDictionary<string, int[]> _layerQueryCache;

    public FilterQuerySingleLayerMarkedPhrase()
    {
      _layerQueryCache = new ConcurrentDictionary<string, int[]>();
    }

    [XmlAttribute("layer")]
    public string LayerDisplayname { get; set; }

    [XmlAttribute("mark")]
    public string Mark { get; private set; }

    /// <summary>
    ///   Gibt eine automatisch generierte Zusammenfassung des Inhalts/Bedeutung zur�ck.
    /// </summary>
    /// <value>The verbal.</value>
    [XmlIgnore]
    public override string Verbal
    {
      get
      {
        var values = string.Join(", ", _layerQueries);
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
      var res = new FilterQuerySingleLayerMarkedPhrase
      {
        Inverse = Inverse,
        LayerDisplayname = LayerDisplayname,
        OrFilterQueries = OrFilterQueries.Select(q => q.Clone() as AbstractFilterQuery)
      };
      res.SetLayerQueriesAndMark(_layerQueries, Mark);
      return res;
    }

    public void SetLayerQueriesAndMark(IEnumerable<string> layerQueries, string mark)
    {
      _layerQueries = layerQueries.ToArray();
      var hash = new HashSet<string>(_layerQueries);
      if (!hash.Contains(mark))
        throw new ArgumentException("mark muss in layerQueries enthalten sein.");

      Eoi = _layerQueries.Length - 1;
      _layerQueryCache = new ConcurrentDictionary<string, int[]>();
      Mark = mark;
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
      if (corpus       == null ||
          documentGuid == Guid.Empty)
        return -1;
      var queries = GetQueries(corpus);
      if (queries        == null ||
          queries.Length == 0)
        return -1;
      var layer = corpus.GetLayerOfDocument(documentGuid, LayerDisplayname);
      var doc = layer?[documentGuid];
      if (doc      == null ||
          sentence < 0     ||
          sentence >= doc.Length)
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
        if (corpus       == null ||
            documentGuid == Guid.Empty)
          return null;
        var queries = GetQueries(corpus);
        if (queries        == null ||
            queries.Length == 0)
          return null;
        var layer = corpus.GetLayerOfDocument(documentGuid, LayerDisplayname);
        var doc = layer?[documentGuid];
        if (doc == null)
          return null;

        var res = new List<int>();
        var sum = queries.Count(q => q > -1);

        for (var i = 0; i < doc.Length; i++)
        {
          if (doc[i] == null)
            continue;
          for (var j = 0; sum + j < doc[i].Length; j++)
            if (!queries.Where((t, k) => t != -1 && (j + k >= doc[i].Length || doc[i][j + k] != t)).Any())
              res.Add(i);
        }

        return res;
      }
    }

    /// <summary>
    ///   Gibt alle Wort-Index �bereinstimmungen zur�ck die das Query oder desseb OrQuery in gew�hlten Korpus - Dokument - Satz
    ///   hat.
    /// </summary>
    /// <param name="corpus">Korpus der das Dokument enth�lt.</param>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <param name="sentence">
    ///   ID des Satzes der die FUnstelle enthalten soll. Alle validen S�tze k�nnen zuvor mit
    ///   GetSentenceIndices() abgefragt werden.
    /// </param>
    /// <returns>Auflistung aller Vorkommen im Satz</returns>
    public override IEnumerable<int> GetWordIndices(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence)
    {
      if (corpus       == null ||
          documentGuid == Guid.Empty)
        return null;
      var queries = GetQueries(corpus);
      if (queries        == null ||
          queries.Length == 0)
        return null;
      var layer = corpus.GetLayerOfDocument(documentGuid, LayerDisplayname);
      if (layer == null)
        return null;

      var wIdx = layer[Mark];
      if (wIdx == -1)
        return null;

      var doc = layer[documentGuid];
      if (doc      == null ||
          sentence < 0     ||
          sentence >= doc.Length)
        return null;

      var s = doc[sentence];
      var res = new List<int>();

      for (var i = 0; i < s.Length; i++)
        if (wIdx == s[i])
          res.Add(i);

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
      if (corpus       == null ||
          documentGuid == Guid.Empty)
        return false;
      var queries = GetQueries(corpus);
      if (queries        == null ||
          queries.Length == 0)
        return false;
      var layer = corpus.GetLayerOfDocument(documentGuid, LayerDisplayname);
      var doc = layer?[documentGuid];
      if (doc == null)
        return false;

      foreach (var s in doc)
      {
        var sum = queries.Count(q => q > -1);

        for (var i = 0; sum + i < s.Length; i++)
          if (!queries.Where((t, j) => i + j >= s.Length || t != -1 && s[i + j] != t).Any())
            return true;
      }

      return false;
    }

    private int[] GetQueries(AbstractCorpusAdapter corpus)
    {
      if (_layerQueryCache.ContainsKey(corpus.ToString()))
        return _layerQueryCache[corpus.ToString()];

      lock (_getQueriesLock)
      {
        var layers = corpus.GetLayers(LayerDisplayname);
        var layer = layers?.FirstOrDefault();
        if (layer == null)
          return null;

        var res = new List<int>();
        foreach (var query in _layerQueries)
          if (query == SearchPattern)
          {
            res.Add(-1);
          }
          else
          {
            var idx = layer[query];
            if (idx == -1)
              continue;
            res.Add(idx);
          }

        if (res.Count == 0)
          return null;

        // Autooptimize
        while (res[0] < 0)
        {
          if (res.Count < 2)
            return null;
          res.RemoveAt(0);
        }

        while (res[res.Count - 1] < 0)
          res.RemoveAt(res[res.Count - 1]);

        _layerQueryCache.TryAdd(corpus.ToString(), res.ToArray());

        return res.ToArray();
      }
    }
  }
}