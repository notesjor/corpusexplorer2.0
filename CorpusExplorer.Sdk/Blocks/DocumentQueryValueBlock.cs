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
  [Serializable]
  public class DocumentQueryValueBlock : AbstractSimple1LayerBlock
  {
    private readonly object _lock = new object();

    public DocumentQueryValueBlock() { LayerDisplayname = "Wort"; }

    public Dictionary<Guid, HashSet<string>> DocumentValueDictionary { get; set; }

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
      var hash = new HashSet<string>();
      foreach (var w in doc.SelectMany(s => s))
        hash.Add(layer[w]);
      lock (_lock)
      {
        DocumentValueDictionary.Add(dsel, hash);
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
      DocumentValueDictionary = new Dictionary<Guid, HashSet<string>>();
    }

    /// <summary>
    ///   Gibt alle Dokumente zurück die deisen Wert enhalten
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public IEnumerable<Guid> GetDocumentsByValue(string value)
    {
      return from v in DocumentValueDictionary where v.Value.Contains(value) select v.Key;
    }
  }
}