using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  public class DocumentContainsMetadataBlock : AbstractDocumentMetadataBlock
  {
    private readonly object _lock = new object();

    public Dictionary<string, Dictionary<string, HashSet<Guid>>> MetadataToDocument { get; set; }

    /// <summary>
    ///   Führt die Berechnung aus
    /// </summary>
    /// <param name="dsel">
    ///   Dokument GUID
    /// </param>
    /// <param name="metadata">
    ///   Metadaten des Dokuments
    /// </param>
    protected override void CalculateCall(
      Guid dsel,
      Dictionary<string, object> metadata)
    {
      foreach (var entry in metadata)
      {
        var value = entry.Value?.ToString();
        if (string.IsNullOrEmpty(value) ||
            string.IsNullOrWhiteSpace(value))
          continue;

        lock (_lock)
        {
          if (MetadataToDocument.ContainsKey(entry.Key))
            if (MetadataToDocument[entry.Key].ContainsKey(value))
              MetadataToDocument[entry.Key][value].Add(dsel);
            else
              MetadataToDocument[entry.Key].Add(value, new HashSet<Guid> {dsel});
          else
            MetadataToDocument.Add(
                                   entry.Key,
                                   new Dictionary<string, HashSet<Guid>> {{value, new HashSet<Guid> {dsel}}});
        }
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
      MetadataToDocument = new Dictionary<string, Dictionary<string, HashSet<Guid>>>();
    }
  }
}