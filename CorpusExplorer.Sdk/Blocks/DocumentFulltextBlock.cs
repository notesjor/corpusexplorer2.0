using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  public class DocumentFulltextBlock : AbstractSimple1LayerBlock
  {
    private readonly object _documentLock = new object();

    public DocumentFulltextBlock() { LayerDisplayname = "Wort"; }

    public Dictionary<Guid, string> Documents { get; set; }

    /// <summary>
    ///   F�hrt die Berechnung aus
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
      var text =
        string.Join(" ", from s in doc from w in s select layer[w])
              .Replace(" ,", ",")
              .Replace(" .", ".")
              .Replace(" !", "!")
              .Replace(" ?", "?")
              .Trim();

      lock (_documentLock)
      {
        Documents.Add(dsel, text);
      }
    }

    /// <summary>
    ///   Wird nach der Berechnung aufgerufen (nach CalculateCall)
    ///   und dient der Bereinigung von Daten
    /// </summary>
    protected override void CalculateCleanup() { }

    /// <summary>
    ///   Wird nach der Bereinigung aufgerufen (nach CalculateCall + CalculateCleanup)
    ///   und dient dem zusammenfassen der bereinigen Ergebnisse
    /// </summary>
    protected override void CalculateFinalize() { }

    /// <summary>
    ///   Wird vor der Berechnung aufgerufen (vor CalculateCall)
    /// </summary>
    protected override void CalculateInitProperties()
    {
      Documents = new Dictionary<Guid, string>();
    }
  }
}