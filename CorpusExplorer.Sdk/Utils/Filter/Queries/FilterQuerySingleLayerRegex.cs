using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;

namespace CorpusExplorer.Sdk.Utils.Filter.Queries
{
  [XmlRoot]
  [Serializable]
  public class FilterQuerySingleLayerRegex : AbstractFilterQuery
  {
    [XmlIgnore] private Dictionary<Guid, HashSet<int>> _cache;

    [XmlAttribute] private string _regexQuery;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractFilterQuerySingleLayer" /> class.
    /// </summary>
    public FilterQuerySingleLayerRegex()
    {
      LayerDisplayname = "Wort";
      RegexQuery = "";
      ClearCache();
    }

    /// <summary>
    ///   Gets or sets the layer displayname.
    /// </summary>
    [XmlAttribute("layer")]
    public string LayerDisplayname { get; set; }

    /// <summary>
    ///   Gets or sets the layer queries.
    /// </summary>
    [XmlIgnore]
    public string RegexQuery
    {
      get => _regexQuery;
      set
      {
        _regexQuery = value;
        ClearCache();
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
      int[][] doc;
      HashSet<int> indices;
      try
      {
        PrepareIndexCall(corpus, documentGuid, sentence, out doc, out indices);
      }
      catch (ArgumentException)
      {
        return null;
      }

      return indices != null && indices.Count > 0 ? GetWordIndicesCall(doc[sentence], indices) : null;
    }

    private void ClearCache()
    {
      lock (_getCachedIndicesLock)
      {
        _cache = new Dictionary<Guid, HashSet<int>>();
      }
    }

    #region Methods

    public override object Clone()
    {
      return new FilterQuerySingleLayerRegex
      {
        Inverse = Inverse,
        LayerDisplayname = LayerDisplayname,
        RegexQuery = RegexQuery,
        OrFilterQueries = OrFilterQueries = OrFilterQueries.Select(q => q.Clone() as AbstractFilterQuery)
      };
    }

    public override string Verbal =>
      $"Alle Dokumente, die im {LayerDisplayname} Werte enthalten, die auf den RegEx \"{RegexQuery}\" passen.";

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
      int[][] doc;
      HashSet<int> indices;
      try
      {
        PrepareIndexCall(corpus, documentGuid, sentence, out doc, out indices);
      }
      catch (ArgumentException)
      {
        return -1;
      }

      return indices != null && indices.Count > 0
               ? GetSentencesFirstIndexCall(doc[sentence], new HashSet<int>(indices))
               : -1;
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
    ///   The
    ///   <see>
    ///     <cref>IEnumerable</cref>
    ///   </see>
    ///   .
    /// </returns>
    protected override IEnumerable<int> GetSentencesCall(AbstractCorpusAdapter corpus, Guid documentGuid)
    {
      try
      {
        var layer = corpus.GetLayers(LayerDisplayname).FirstOrDefault();
        if (layer == null || !layer.ContainsDocument(documentGuid))
          return null;

        var doc = layer[documentGuid];
        if (doc == null || doc.Length == 0)
          return null;

        var indices = GetCachedIndices(layer);
        if (indices == null || indices.Count == 0)
          return null;

        var res = new List<int>();
        for (var i = 0; i < doc.Length; i++)
          res.AddRange(from w in doc[i] where indices.Contains(w) select i);

        return res;
      }
      catch (ArgumentNullException)
      {
        return null;
      }
    }

    private readonly object _getCachedIndicesLock = new object();

    private HashSet<int> GetCachedIndices(AbstractLayerAdapter layer)
    {
      lock (_getCachedIndicesLock)
      {
        if (_cache.ContainsKey(layer.Guid))
          return _cache[layer.Guid];

        var res = GetCachedIndicesCall(layer);
        _cache.Add(layer.Guid, res);
        return res;
      }
    }

    protected virtual HashSet<int> GetCachedIndicesCall(AbstractLayerAdapter layer)
    {
      try
      {
        var regex = new Regex(RegexQuery);
        return new HashSet<int>(layer.Values.Where(x => regex.IsMatch(x)).Select(x => layer[x]));
      }
      catch
      {
        return null;
      }
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
      var layer = corpus.GetLayerOfDocument(documentGuid, LayerDisplayname);

      var doc = layer?[documentGuid];
      if (doc == null)
        return false;

      var indices = GetCachedIndices(layer);
      return indices != null && indices.Count > 0 && doc.SelectMany(s => s).Any(indices.Contains);
    }

    // ReSharper disable ParameterTypeCanBeEnumerable.Global

    /// <summary>
    ///   The get sentences index call.
    /// </summary>
    /// <param name="sentence">
    ///   The sentence.
    /// </param>
    /// <param name="indices">
    ///   The indices.
    /// </param>
    /// <returns>
    ///   The <see cref="int" />.
    /// </returns>
    private static int GetSentencesFirstIndexCall(int[] sentence, HashSet<int> indices)
    {
      for (var i = 0; i < sentence.Length; i++)
        if (indices.Contains(sentence[i]))
          return i;

      return -1;
    }

    private static IEnumerable<int> GetWordIndicesCall(int[] sentence, HashSet<int> indices)
    {
      var res = new List<int>();
      for (var i = 0; i < sentence.Length; i++)
        if (indices.Contains(sentence[i]))
          res.Add(i);
      return res;
    }

    private void PrepareIndexCall(
      AbstractCorpusAdapter corpus,
      Guid documentGuid,
      // ReSharper disable once UnusedParameter.Local
      int sentence,
      out int[][] doc,
      out HashSet<int> indices)
    {
      if (sentence < 0)
        throw new ArgumentException("sentences < 0");

      var layer = corpus.GetLayers(LayerDisplayname).FirstOrDefault();
      if (layer == null)
        throw new ArgumentException("No Layer with given LayerDisplayname");
      if (!layer.ContainsDocument(documentGuid))
        throw new ArgumentException("No Layer contains Document(GUID)");

      doc = layer[documentGuid];
      if (doc == null)
        throw new ArgumentException("Document is null");

      if (sentence >= doc.Length)
        throw new ArgumentException("sentence is greater than document.Length");

      indices = GetCachedIndices(layer);
    }

    #endregion

    // ReSharper restore ParameterTypeCanBeEnumerable.Global
  }
}