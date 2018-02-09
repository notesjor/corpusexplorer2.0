#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

#endregion

namespace CorpusExplorer.Sdk.Utils.Filter.Abstract
{
  /// <summary>
  ///   The abstract filter query.
  /// </summary>
  [XmlRoot]
  [XmlInclude(typeof(AbstractFilterQueryCompleteDocumentIndexing))]
  [XmlInclude(typeof(AbstractFilterQueryMeta))]
  [XmlInclude(typeof(AbstractFilterQuerySingleLayer))]
  [XmlInclude(typeof(FilterQuerySingleLayerAllInOneSentence))]
  [XmlInclude(typeof(FilterQuerySingleLayerAllInOnDocument))]
  [XmlInclude(typeof(FilterQuerySingleLayerAllInSpanSentences))]
  [XmlInclude(typeof(FilterQuerySingleLayerAnyMatch))]
  [XmlInclude(typeof(FilterQuerySingleLayerAllInSpanWords))]
  [XmlInclude(typeof(FilterQueryCorpusComplete))]
  [XmlInclude(typeof(FilterQuerySingleLayerMarkedPhrase))]
  [XmlInclude(typeof(FilterQueryMetaContainsCaseSensitive))]
  [XmlInclude(typeof(FilterQueryMetaContains))]
  [XmlInclude(typeof(FilterQueryMetaIsEmpty))]
  [XmlInclude(typeof(FilterQueryMetaRegex))]
  [XmlInclude(typeof(FilterQueryMultiLayer))]
  [XmlInclude(typeof(FilterQuerySingleLayerExactPhrase))]
  [Serializable]
  public abstract class AbstractFilterQuery : IVerbalize, ICloneable
  {
    /// <summary>
    ///   The _or filter queries.
    /// </summary>
    [XmlArray("queries")]
    private List<AbstractFilterQuery> _orFilterQueries = new List<AbstractFilterQuery>();

    protected AbstractFilterQuery() { Guid = Guid.NewGuid(); }

    [XmlAttribute("guid")]
    public Guid Guid { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether inverse.
    /// </summary>
    [XmlAttribute("inverse")]
    public bool Inverse { get; set; }

    /// <summary>
    ///   Gets or sets the or filter queries.
    /// </summary>
    [XmlIgnore]
    public IEnumerable<AbstractFilterQuery> OrFilterQueries
    {
      get => _orFilterQueries;
      set => _orFilterQueries = value?.ToList() ?? new List<AbstractFilterQuery>();
    }

    /// <summary>
    ///   Erstellt ein neues Objekt, das eine Kopie der aktuellen Instanz darstellt.
    /// </summary>
    /// <returns>
    ///   Ein neues Objekt, das eine Kopie dieser Instanz darstellt.
    /// </returns>
    public abstract object Clone();

    /// <summary>
    ///   Gibt eine automatisch generierte Zusammenfassung des Inhalts/Bedeutung zurück.
    /// </summary>
    /// <value>The verbal.</value>
    [XmlIgnore]
    public abstract string Verbal { get; }

    /// <summary>
    ///   Gibt eine Auflistung aller Sätze und aller Fundstellen (Wortindex) zurück
    /// </summary>
    /// <param name="corpus">Korpus das das Dokument enthält</param>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <returns>Key = Satzindex / Value = Fundstelle</returns>
    public Dictionary<int, HashSet<int>> GetSentenceAndWordIndices(AbstractCorpusAdapter corpus, Guid documentGuid)
    {
      var sentences = GetSentenceIndices(corpus, documentGuid);
      if (sentences == null || sentences.Count == 0)
        return null;

      var dictionary = new Dictionary<int, HashSet<int>>();
      foreach (var sentence in sentences)
      {
        var indices = GetWordIndices(corpus, documentGuid, sentence);
        if (indices == null)
          continue;
        dictionary.Add(sentence, new HashSet<int>(indices));
      }
      return dictionary;
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
    protected abstract int GetSentenceFirstIndexCall(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence);

    /// <summary>
    ///   Gibt eine Auflistung aller Sätze in einem bestimmten Dokument aus die durch diesen Query und durch dessen OrQueries
    ///   selektiert werden.
    /// </summary>
    /// <param name="corpus">Korpus das das Dokument enthält</param>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <returns>Auflistung der Sätze (unsortiert).</returns>
    public HashSet<int> GetSentenceIndices(AbstractCorpusAdapter corpus, Guid documentGuid)
    {
      var items = GetSentencesCall(corpus, documentGuid);
      var res = items == null ? new HashSet<int>() : new HashSet<int>(items);

      foreach (
        var x in
        _orFilterQueries.Select(query => query.GetSentenceIndices(corpus, documentGuid)).SelectMany(temp => temp))
        res.Add(x);
      return res;
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
    ///   Sentence indices
    /// </returns>
    protected abstract IEnumerable<int> GetSentencesCall(AbstractCorpusAdapter corpus, Guid documentGuid);

    /// <summary>
    ///   Gibt den ersten Wort-Index der Übereinstimmung zurück die das Query oder dessen OrQuery im gewähltem Korpus -
    ///   Dokument - Satz hat.
    /// </summary>
    /// <param name="corpus">Korpus das das Dokument enthält.</param>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <param name="sentence">
    ///   ID des Satzes der die FUnstelle enthalten soll. Alle validen Sätze können zuvor mit
    ///   GetSentenceIndices() abgefragt werden.
    /// </param>
    /// <returns>Wort-Index der ersten Fundstelle</returns>
    public int GetWordFirstIndex(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence)
    {
      var res = GetSentenceFirstIndexCall(corpus, documentGuid, sentence);
      if (res > -1)
        return res;
      foreach (var query in _orFilterQueries)
      {
        res = query.GetWordFirstIndex(corpus, documentGuid, sentence);
        if (res > -1)
          return res;
      }
      return -1;
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
    protected abstract IEnumerable<int> GetWordIndices(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence);

    /// <summary>
    ///   The validate.
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
    public bool Validate(AbstractCorpusAdapter corpus, Guid documentGuid)
    {
      // Prüfe zuerst ob die Hauptbedingung wahr ist.
      // Inverse erlaubt es die Hauptbedingung umzukerhen.
      // Sollte nicht Hauptbedingung nicht wahr sein, prüfe die Unterbedingungen.
      return (Inverse ? !ValidateCall(corpus, documentGuid) : ValidateCall(corpus, documentGuid))
             || OrFilterQueries.Any(query => query.Validate(corpus, documentGuid));
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
    protected abstract bool ValidateCall(AbstractCorpusAdapter corpus, Guid documentGuid);
  }
}