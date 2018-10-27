#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Interface;

#endregion

namespace CorpusExplorer.Sdk.Utils.Filter.Abstract
{
  /// <summary>
  ///   The abstract single layer filter query.
  /// </summary>
  [XmlRoot]
  [Serializable]
  public abstract class AbstractFilterQuerySingleLayer : AbstractFilterQuery, IFilterQueryWithLayerValues
  {
    [XmlIgnore] protected Dictionary<Guid, HashSet<int>> _cache;

    [XmlAttribute] private IEnumerable<string> _layerQueries;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractFilterQuerySingleLayer" /> class.
    /// </summary>
    protected AbstractFilterQuerySingleLayer()
    {
      LayerDisplayname = "Wort";
      LayerQueries = new string[0];
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
    public IEnumerable<string> LayerQueries
    {
      get => _layerQueries;
      set
      {
        _layerQueries = value;
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

        return GetSentencesCall(doc, indices);
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

        var res = GetCachedIndicesCall(layer, LayerQueries);
        _cache.Add(layer.Guid, res);
        return res;
      }
    }

    protected virtual HashSet<int> GetCachedIndicesCall(AbstractLayerAdapter layer, IEnumerable<string> layerQueries)
    {
      return new HashSet<int>(layer.ValuesToIndices(layerQueries));
    }

    /// <summary>
    ///   The get sentences call.
    /// </summary>
    /// <param name="document">
    ///   The document.
    /// </param>
    /// <param name="indices">
    ///   The indices.
    /// </param>
    /// <returns>
    ///   Sentecne indices
    /// </returns>
    protected abstract IEnumerable<int> GetSentencesCall(int[][] document, HashSet<int> indices);

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
      return indices != null && indices.Count > 0 && ValidateCallCall(doc, indices);
    }

    // ReSharper disable ParameterTypeCanBeEnumerable.Global
    /// <summary>
    ///   The validate call call.
    /// </summary>
    /// <param name="document">
    ///   The document.
    /// </param>
    /// <param name="indices">
    ///   The indices.
    /// </param>
    /// <returns>
    ///   The <see cref="bool" />.
    /// </returns>
    protected abstract bool ValidateCallCall(int[][] document, HashSet<int> indices);

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