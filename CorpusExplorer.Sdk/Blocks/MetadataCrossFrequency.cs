#region

using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Properties;

#endregion

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class MetadataCrossFrequency : AbstractDocumentMetadataBlock
  {
    private readonly object _lock = new object();

    public Dictionary<string, Dictionary<string, long>> MetadataDistribution { get; set; }
    public string MetadataKey1 { get; set; }
    public string MetadataKey2 { get; set; }

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
      // Frage Werte ab
      var v1 = metadata.ContainsKey(MetadataKey1) ? metadata[MetadataKey1] : null;
      var v2 = metadata.ContainsKey(MetadataKey2) ? metadata[MetadataKey2] : null;

      // Konvertiere Werte in Schlüssel
      var k1 = string.IsNullOrEmpty(v1?.ToString()) ? Resources.NoData : v1.ToString();
      var k2 = string.IsNullOrEmpty(v2?.ToString()) ? Resources.NoData : v2.ToString();

      lock (_lock)
      {
        if (MetadataDistribution.ContainsKey(k1))
          if (MetadataDistribution[k1].ContainsKey(k2))
            MetadataDistribution[k1][k2] += Selection.GetDocumentLengthInWords(dsel);
          else
            MetadataDistribution[k1].Add(k1, Selection.GetDocumentLengthInWords(dsel));
        else
          MetadataDistribution.Add(k1, new Dictionary<string, long> {{k2, Selection.GetDocumentLengthInWords(dsel)}});
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
      MetadataDistribution = new Dictionary<string, Dictionary<string, long>>();

      if (MetadataKey1 == null)
        MetadataKey1 = string.Empty;
      if (MetadataKey2 == null)
        MetadataKey2 = string.Empty;
    }
  }
}