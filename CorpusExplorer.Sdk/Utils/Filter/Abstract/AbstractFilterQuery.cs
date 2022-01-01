#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper.Verbalizer;
using CorpusExplorer.Sdk.Model;
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
  [XmlInclude(typeof(AbstractFilterQuerySingleLayerFulltext))]
  [XmlInclude(typeof(FilterQueryCorpusComplete))]
  [XmlInclude(typeof(FilterQueryMetaContains))]
  [XmlInclude(typeof(FilterQueryMetaContainsCaseSensitive))]
  [XmlInclude(typeof(FilterQueryMetaEndsWith))]
  [XmlInclude(typeof(FilterQueryMetaExactMatch))]
  [XmlInclude(typeof(FilterQueryMetaExactMatchCaseSensitive))]
  [XmlInclude(typeof(FilterQueryMetaIsEmpty))]
  [XmlInclude(typeof(FilterQueryMetaRegex))]
  [XmlInclude(typeof(FilterQueryMetaStartsWith))]
  [XmlInclude(typeof(FilterQueryMultiLayerAll))]
  [XmlInclude(typeof(FilterQueryMultiLayerAny))]
  [XmlInclude(typeof(FilterQueryMultiLayerPhrase))]
  [XmlInclude(typeof(FilterQuerySingleLayerAllInExactSpanWords))]
  [XmlInclude(typeof(FilterQuerySingleLayerAllInOneDocument))]
  [XmlInclude(typeof(FilterQuerySingleLayerAllInOneSentence))]
  [XmlInclude(typeof(FilterQuerySingleLayerAllInSpanSentences))]
  [XmlInclude(typeof(FilterQuerySingleLayerAllInSpanWords))]
  [XmlInclude(typeof(FilterQuerySingleLayerAnyMatch))]
  [XmlInclude(typeof(FilterQuerySingleLayerExactPhrase))]
  [XmlInclude(typeof(FilterQuerySingleLayerMarkedPhrase))]
  [XmlInclude(typeof(FilterQuerySingleLayerRegexFulltext))]
  [XmlInclude(typeof(FilterQueryUnsupportedParserFeature))]
  [Serializable]
  public abstract class AbstractFilterQuery : IVerbalizerSimple, ICloneable
  {
    /// <summary>
    ///   The _or filter queries.
    /// </summary>
    [XmlArray("queries")] private List<AbstractFilterQuery> _orFilterQueries = new List<AbstractFilterQuery>();

    protected AbstractFilterQuery()
    {
      Guid = Guid.NewGuid();
    }

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
    /// <param name="documentGuidPreFilter">
    ///   Wenn angegeben, werden nur die angegebenen Dokumente durchsucht (müssen im Korpus
    ///   enthalten sein)
    /// </param>
    /// <returns>Key = DocumentGuid / Value => Key = Satzindex / Value = Fundstelle</returns>
    public Dictionary<Guid, Dictionary<int, HashSet<int>>> GetSentenceAndWordIndices(
      AbstractCorpusAdapter corpus, IEnumerable<Guid> documentGuidPreFilter = null)
    {
      var res = new Dictionary<Guid, Dictionary<int, HashSet<int>>>();
      var loc = new object();
      if (documentGuidPreFilter == null)
        documentGuidPreFilter = corpus.DocumentGuids;

      Parallel.ForEach(documentGuidPreFilter, Configuration.ParallelOptions, dsel =>
      {
        if (!corpus.ContainsDocument(dsel))
          return;

        var sen = GetSentenceAndWordIndices(corpus, dsel);
        if (sen == null || sen.Count == 0)
          return;
        lock (loc)
        {
          res.Add(dsel, sen);
        }
      });
      return res;
    }

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

      var res = new Dictionary<int, HashSet<int>>();
      foreach (var sentence in sentences)
      {
        var indices = GetWordIndices(corpus, documentGuid, sentence);
        if (indices == null)
          continue;
        res.Add(sentence, new HashSet<int>(indices));
      }

      return res;
    }

    /// <summary>
    ///   Gibt eine Auflistung aller Sätze und aller Fundstellen (Wortindex) zurück
    /// </summary>
    /// <param name="selection">Korpus das das Dokument enthält</param>
    /// <param name="documentGuidPreFilter">
    ///   Wenn angegeben, werden nur die angegebenen Dokumente durchsucht (müssen im Korpus
    ///   enthalten sein)
    /// </param>
    /// <returns>Key = KorpusGuid / Value => Key = DocumentGuid / Value => Key = Satzindex / Value = Fundstelle</returns>
    public Dictionary<Guid, Dictionary<Guid, Dictionary<int, HashSet<int>>>> GetSentenceAndWordIndices(
      Selection selection, IEnumerable<Guid> documentGuidPreFilter = null)
    {
      var lo = new object();
      var res = new Dictionary<Guid, Dictionary<Guid, Dictionary<int, HashSet<int>>>>();

      Parallel.ForEach(selection, Configuration.ParallelOptions, csel =>
      {
        var corpus = selection.GetCorpus(csel.Key);
        var tmp = GetSentenceAndWordIndices(corpus, documentGuidPreFilter);
        lock (lo)
        {
          res.Add(csel.Key, tmp);
        }
      });

      return res;
    }

    /// <summary>
    ///   Gibt die erste Übereinstimmung innerhalb eines Satze zurück
    /// </summary>
    /// <param name="corpus">
    ///   Korpus
    /// </param>
    /// <param name="documentGuid">
    ///   Dokument GUID
    /// </param>
    /// <param name="sentence">
    ///   SatzID
    /// </param>
    /// <returns>
    ///   Erste Übereinstimmung
    /// </returns>
    protected abstract int GetSentenceFirstIndexCall(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence);

    /// <summary>
    ///   Gibt eine Auflistung aller Sätze in allen Dokumenten aus, die durch diesen Query und durch dessen OrQueries
    ///   selektiert werden.
    /// </summary>
    /// <param name="corpus">Korpus das das Dokument enthält</param>
    /// <param name="documentGuidPreFilter">
    ///   Wenn angegeben, werden nur die angegebenen Dokumente durchsucht (müssen im Korpus
    ///   enthalten sein)
    /// </param>
    /// <returns>Auflistung Key = Dokument / Value = SatzId</returns>
    public Dictionary<Guid, HashSet<int>> GetSentenceIndices(AbstractCorpusAdapter corpus,
                                                             IEnumerable<Guid> documentGuidPreFilter = null)
    {
      var res = new Dictionary<Guid, HashSet<int>>();
      var loc = new object();
      if (documentGuidPreFilter == null)
        documentGuidPreFilter = corpus.DocumentGuids;

      Parallel.ForEach(documentGuidPreFilter, Configuration.ParallelOptions, dsel =>
      {
        var sen = GetSentenceIndices(corpus, dsel);
        if (sen == null || sen.Count == 0)
          return;
        lock (loc)
        {
          res.Add(dsel, sen);
        }
      });
      return res;
    }

    /// <summary>
    ///   Gibt eine Auflistung aller Sätze in einem bestimmten Dokument aus, die durch diesen Query und durch dessen OrQueries
    ///   selektiert werden.
    /// </summary>
    /// <param name="corpus">Korpus das das Dokument enthält</param>
    /// <param name="documentGuid">GUID des Dokuments</param>
    /// <returns>Auflistung der Sätze (unsortiert).</returns>
    public HashSet<int> GetSentenceIndices(AbstractCorpusAdapter corpus, Guid documentGuid)
    {
      try
      {
        var items = GetSentencesCall(corpus, documentGuid);
        var res = items == null ? new HashSet<int>() : new HashSet<int>(items);

        foreach (var x in _orFilterQueries.Select(query => query.GetSentenceIndices(corpus, documentGuid)).SelectMany(temp => temp)) 
          res.Add(x);

        return res;
      }
      catch
      {
        return new HashSet<int>();
      }
    }

    /// <summary>
    ///   Gibt alle passenden Sätze zurück.
    /// </summary>
    /// <param name="corpus">
    ///   Korpus
    /// </param>
    /// <param name="documentGuid">
    ///   Dokument GUID
    /// </param>
    /// <returns>
    ///   Satz Indices
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
    public abstract IEnumerable<int> GetWordIndices(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence);

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
    ///   Passt das Dokument zum Suchausdruck?
    /// </summary>
    /// <param name="corpus">
    ///   Korpus
    /// </param>
    /// <param name="documentGuid">
    ///   Dokument GUID
    /// </param>
    /// <returns>
    ///   Übereinstimmung: Suchausdruck = Dokument?
    /// </returns>
    protected abstract bool ValidateCall(AbstractCorpusAdapter corpus, Guid documentGuid);
  }
}