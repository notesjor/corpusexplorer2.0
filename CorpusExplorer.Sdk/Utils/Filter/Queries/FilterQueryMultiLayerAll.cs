using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;

namespace CorpusExplorer.Sdk.Utils.Filter.Queries
{
  /// <summary>
  ///   The multi layer filter query.
  /// </summary>
  [XmlRoot]
  [Serializable]
  public class FilterQueryMultiLayerAll : AbstractFilterQuery
  {
    [XmlIgnore] [NonSerialized] private Dictionary<string, string> _multilayerValues;

    private KeyValuePair<string, string>[] _multilayerValuesSerialized;

    /// <summary>
    ///   Initializes a new instance of the <see cref="FilterQueryMultiLayerAny" /> class.
    /// </summary>
    public FilterQueryMultiLayerAll()
    {
      MultilayerValues = new Dictionary<string, string>();
    }

    /// <summary>
    ///   Gets or sets the multilayer values.
    /// </summary>
    [XmlIgnore]
    public Dictionary<string, string> MultilayerValues
    {
      get => _multilayerValues;
      set => _multilayerValues = value;
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
        return
          $"Multilayer-Abfrage der Layer: {string.Join(", ", MultilayerValues.Select(multilayerValue => multilayerValue.Key))}";
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
      return new FilterQueryMultiLayerAny
      {
        Inverse = Inverse,
        MultilayerValues = MultilayerValues,
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
      var res = SentenceIndexCall(corpus, documentGuid, sentence);
      return res?.FirstOrDefault() ?? -1;
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
    ///   Sentence indices.
    /// </returns>
    protected override IEnumerable<int> GetSentencesCall(AbstractCorpusAdapter corpus, Guid documentGuid)
    {
      var search = GetDictionary(corpus);
      return search == null ? null : ExploreSentences(documentGuid, search)?.Select(x => x.Key);
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
      return SentenceIndexCall(corpus, documentGuid, sentence);
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
      var search = GetDictionary(corpus);
      if (search == null || search.Count == 0)
        return false;
      var exploreSentence = ExploreSentences(documentGuid, search);
      if (exploreSentence == null ||
          !exploreSentence.Any())
        return false;
      return ExploreSentences(documentGuid, search).SelectMany(x => x.Value).Any();
    }

    /// <summary>
    ///   The dictionary to array.
    /// </summary>
    /// <param name="dictionary">
    ///   The dictionary.
    /// </param>
    /// <returns>
    ///   The int[][].
    /// </returns>
    // ReSharper disable once ReturnTypeCanBeEnumerable.Local
    private static int[][] DictionaryToArray(Dictionary<int, List<int>> dictionary)
    {
      return (from pair in dictionary from v in pair.Value select new[] { pair.Key, v }).ToArray();
    }

    /// <summary>
    ///   The explore sentences.
    /// </summary>
    /// <param name="documentGuid">
    ///   The document guid.
    /// </param>
    /// <param name="search">
    ///   The search.
    /// </param>
    /// <returns>
    ///   The result
    /// </returns>
    private Dictionary<int, List<int>> ExploreSentences(
      Guid documentGuid,
      IEnumerable<KeyValuePair<AbstractLayerAdapter, int>> search)
    {
      var res = new Dictionary<int, List<int>>();
      var query = search.ToList();

      var first = query.First();
      query.RemoveAt(0);

      var doc = first.Key[documentGuid];
      if (doc == null)
        return null;

      var docs = query.Select(x => x.Key[documentGuid]).ToArray();

      for (var i = 0; i < doc.Length; i++)
        for (var j = 0; j < doc[i].Length; j++)
          if (doc[i][j] == first.Value)
          {
            if (docs.Where((t, k) => t[i][j] != query[k].Value).Any())
              continue;

            if (res.ContainsKey(i))
              res[i].Add(j);
            else
              res.Add(i, new List<int> { j });
          }

      return res;
    }

    private Dictionary<Guid, List<KeyValuePair<AbstractLayerAdapter, int>>> _dicCache =
      new Dictionary<Guid, List<KeyValuePair<AbstractLayerAdapter, int>>>();

    private object _dicCacheLock = new object();

    /// <summary>
    ///   The get dictionary.
    /// </summary>
    /// <param name="corpus">
    ///   The corpus.
    /// </param>
    /// <returns>
    ///   Return layer
    /// </returns>
    private List<KeyValuePair<AbstractLayerAdapter, int>> GetDictionary(AbstractCorpusAdapter corpus)
    {
      lock (_dicCacheLock)
      {
        try
        {
          if (_dicCache.ContainsKey(corpus.CorpusGuid))
            return _dicCache[corpus.CorpusGuid];

          if (MultilayerValues.Count < 1)
            return null;

          var res = new List<KeyValuePair<AbstractLayerAdapter, int>>();
          foreach (var layerValue in MultilayerValues)
          {
            var layers = corpus.GetLayers(layerValue.Key);
            if (layers == null)
              return null;

            foreach (var layer in layers)
            {
              var value = layer[layerValue.Value];
              if (value == -1)
                return null;

              res.Add(new KeyValuePair<AbstractLayerAdapter, int>(layer, value));
            }
          }

          _dicCache[corpus.CorpusGuid] = res;
          return res;
        }
        catch
        {
          return null;
        }
      }
    }

    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
      _multilayerValues = _multilayerValuesSerialized.ToDictionary(x => x.Key, x => x.Value);
      _multilayerValuesSerialized = null;
    }

    [OnSerialized]
    private void OnSerialized(StreamingContext context)
    {
      _multilayerValuesSerialized = null;
    }

    [OnSerializing]
    private void OnSerializing(StreamingContext context)
    {
      _multilayerValuesSerialized = _multilayerValues.ToArray();
    }

    private IEnumerable<int> SentenceIndexCall(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence)
    {
      try
      {
        if (sentence < 0)
          return null;

        var search = GetDictionary(corpus).ToList();
        if (search.Count == 0)
          return null;

        var first = search.First();
        search.RemoveAt(0);

        var doc = first.Key[documentGuid][sentence];
        if (doc == null)
          return null;

        var docs = search.Select(x => x.Key[documentGuid][sentence]).ToArray();
        var res = new List<int>();

        for (var j = 0; j < doc.Length; j++)
          if (doc[j] == first.Value)
          {
            if (docs.Where((t, k) => t[j] != search[k].Value).Any())
              continue;

            res.Add(j);
          }

        return res;
      }
      catch
      {
        return null;
      }
    }
  }
}