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
  public class FilterQuerySingleLayerAlternativePhrase : AbstractFilterQuery
  {
    [XmlIgnore]
    private readonly object _getQueriesLock = new object();

    [XmlArray]
    private IEnumerable<IEnumerable<string>> _layerQueries;

    [XmlIgnore]
    private Dictionary<Guid, HashSet<int>[]> _layerQueryCache;

    public FilterQuerySingleLayerAlternativePhrase() { _layerQueryCache = new Dictionary<Guid, HashSet<int>[]>(); }

    /// <summary>
    ///   End of Index - wird von GetWordIndices verwendet um das Ende des Musters zu bestimmen.
    /// </summary>
    /// <value>The eoi.</value>
    [XmlIgnore]
    private int Eoi { get; set; }

    [XmlAttribute("layer")]
    public string LayerDisplayname { get; set; } = "Wort";

    [XmlIgnore]
    public IEnumerable<IEnumerable<string>> LayerQueries
    {
      get => _layerQueries;
      set
      {
        Eoi = value.Count() - 1;
        _layerQueries = value;
        _layerQueryCache = new Dictionary<Guid, HashSet<int>[]>();
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
        var values = string.Join(", ", LayerQueries.Select(x => $"({string.Join(",", x)})"));
        if (values.Length > 50)
          values = values.Substring(0, 47) + "...";
        return string.Format(Resources.SearchForPhrases, values);
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
      return new FilterQuerySingleLayerAlternativePhrase
      {
        Inverse = Inverse,
        LayerDisplayname = LayerDisplayname,
        LayerQueries = LayerQueries,
        OrFilterQueries = OrFilterQueries.Select(q => q.Clone() as AbstractFilterQuery)
      };
    }

    private HashSet<int>[] GetQueries(AbstractCorpusAdapter corpus)
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
        var res = new List<HashSet<int>>();
        foreach (var query in LayerQueries)
        {
          var position = new HashSet<int>();
          foreach (var x in query)
          {
            var idx = layer[x];
            if (idx == -1)
            {
              valid = false;
              break;
            }
            position.Add(idx);
          }
          if (!valid)
            break;
          res.Add(position);
        }

        if (res.Count == 0)
          valid = false;

        _layerQueryCache.Add(corpus.CorpusGuid, valid ? res.ToArray() : null);

        return valid ? res.ToArray() : null;
      }
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
      if (corpus == null ||
          documentGuid == Guid.Empty)
        return -1;
      var queries = GetQueries(corpus);
      if (queries == null ||
          queries.Length == 0)
        return -1;
      var layer = corpus.GetLayerOfDocument(documentGuid, LayerDisplayname);
      var doc = layer?[documentGuid];
      if (doc == null ||
          sentence < 0 ||
          sentence >= doc.Length)
        return -1;

      var s = doc[sentence];
      if (Configuration.RightToLeftSupport)
      {
        if (s.TakeWhile((t1, w) => w - queries.Length >= 0).Where((t1, w) => !queries.Where((t, q) => !queries[queries.Length - 1 - q].Contains(s[w - q])).Any()).Any())
          return sentence;
      }
      else
      {
        if (s.TakeWhile((t1, w) => w + queries.Length < s.Length).Where((t1, w) => !queries.Where((t, q) => !t.Contains(s[w + q])).Any()).Any())
          return sentence;
      }

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

      if (Configuration.RightToLeftSupport)
      {
        for (var sentence = 0; sentence < doc.Length; sentence++)
        {
          var s = doc[sentence];
          if (s.TakeWhile((t1, w) => w - queries.Length >= 0).Where((t1, w) => !queries.Where((t, q) => !queries[queries.Length - 1 - q].Contains(s[w - q])).Any()).Any())
            res.Add(sentence);
        }
      }
      else
      {
        for (var sentence = 0; sentence < doc.Length; sentence++)
        {
          var s = doc[sentence];
          if (s.TakeWhile((t1, w) => w + queries.Length < s.Length).Where((t1, w) => !queries.Where((t, q) => !t.Contains(s[w + q])).Any()).Any())
            res.Add(sentence);
        }
      }

      return res;
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
    protected override IEnumerable<int> GetWordIndices(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence)
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

      var res = new List<int>();
      var s = doc[sentence];
      if (Configuration.RightToLeftSupport)
      {
        if (s.TakeWhile((t1, w) => w - queries.Length >= 0).Where((t1, w) => !queries.Where((t, q) => !queries[queries.Length - 1 - q].Contains(s[w - q])).Any()).Any())
          res.Add(sentence);
      }
      else
      {
        if (s.TakeWhile((t1, w) => w + queries.Length < s.Length).Where((t1, w) => !queries.Where((t, q) => !t.Contains(s[w + q])).Any()).Any())
          res.Add(sentence);
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

      return Configuration.RightToLeftSupport ?
        doc.Any(s => s.TakeWhile((t1, w) => w - queries.Length >= 0).Where((t1, w) => !queries.Where((t, q) => !queries[queries.Length - 1 - q].Contains(s[w - q])).Any()).Any()) :
        doc.Any(s => s.TakeWhile((t1, w) => w + queries.Length < s.Length).Select((t1, w) => !queries.Where((t, q) => !t.Contains(s[w + q])).Any()).Any(any => any));
    }
  }
}