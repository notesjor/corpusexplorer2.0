#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks
{
  /// <summary>
  ///   Class DocumentSizeBlock.
  /// </summary>
  [Serializable]
  public class DocumentSizeBlock : AbstractSimple1LayerBlock
  {
    private readonly object _lock = new object();

    public DocumentSizeBlock()
    {
      DocumentSentenceCount = new Dictionary<Guid, int>();
      DocumentWordCount = new Dictionary<Guid, int>();
    }

    /// <summary>
    ///   DokumentGuid/Satzanzahl-Wörterbuch
    /// </summary>
    /// <value>The document sentence count.</value>
    public Dictionary<Guid, int> DocumentSentenceCount { get; set; }

    /// <summary>
    ///   DokumentGuid/Wortanzahl-Wörterbuch
    /// </summary>
    /// <value>The document word count.</value>
    public Dictionary<Guid, int> DocumentWordCount { get; set; }

    /// <summary>
    ///   Führt die Berechnung aus
    /// </summary>
    /// <param name="corpus">
    ///   Korpus
    /// </param>
    /// <param name="layer">
    ///   Layer
    /// </param>
    /// <param name="dsel">
    ///   Dokument GUID
    /// </param>
    /// <param name="doc">
    ///   Dokument
    /// </param>
    protected override void CalculateCall(
      AbstractCorpusAdapter corpus,
      AbstractLayerAdapter layer,
      Guid dsel,
      int[][] doc)
    {
      var d = doc.Length;
      var w = doc.Sum(s => s.Length);

      lock (_lock)
      {
        if (DocumentSentenceCount.ContainsKey(dsel))
          return;
        DocumentSentenceCount.Add(dsel, d);
        DocumentWordCount.Add(dsel, w);
      }
    }

    /// <summary>
    ///   Wird nach der Berechnung aufgerufen (nach CalculateCall)
    ///   und dient der Bereinigung von Daten
    /// </summary>
    protected override void CalculateCleanup()
    {
    }

    /// <summary>
    ///   Wird nach der Bereinigung aufgerufen (nach CalculateCall + CalculateCleanup)
    ///   und dient dem zusammenfassen der bereinigen Ergebnisse
    /// </summary>
    protected override void CalculateFinalize()
    {
    }

    /// <summary>
    ///   Wird vor der Berechnung aufgerufen (vor CalculateCall)
    /// </summary>
    protected override void CalculateInitProperties()
    {
    }
  }
}