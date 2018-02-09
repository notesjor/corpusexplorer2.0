#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Utils.Filter.Abstract
{
  [XmlRoot]
  [Serializable]
  public abstract class AbstractFilterQueryCompleteDocumentIndexing : AbstractFilterQuery
  {
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
      return ValidateCall(corpus, documentGuid) ? 0 : -1;
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
    /// <param name="layerDisplayname">
    ///   The layer displayname.
    /// </param>
    /// <returns>
    ///   The sentences - layer indices
    /// </returns>
    public static IEnumerable<int> GetSentences(
      AbstractCorpusAdapter corpus,
      Guid documentGuid,
      string layerDisplayname)
    {
      var layer = corpus.GetLayers(layerDisplayname).FirstOrDefault();
      if (layer == null || !layer.ContainsDocument(documentGuid))
        return null;

      var doc = layer[documentGuid];
      if (doc == null)
        return null;

      var max = doc.Length;
      var res = new List<int>();
      for (var i = 0; i < max; i++)
        res.Add(i);

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
    ///   Alle Sätz (als Index) die den Kriterien entsprechen.
    /// </returns>
    protected override IEnumerable<int> GetSentencesCall(AbstractCorpusAdapter corpus, Guid documentGuid)
    {
      return ValidateCall(corpus, documentGuid) ? GetSentences(corpus, documentGuid, "Wort") : null;
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
      return ValidateCall(corpus, documentGuid) ? new[] {0} : null;
    }
  }
}