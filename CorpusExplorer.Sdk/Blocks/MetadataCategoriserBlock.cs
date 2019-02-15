#region

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class MetadataCategoriserBlock : AbstractDocumentMetadataBlock
  {
    private object _level1;
    private object _level2;
    public Dictionary<string, Dictionary<string, IEnumerable<Guid>>> Categories { get; set; }

    /// <summary>
    ///   Gibt alle Dokumente zurück die
    /// </summary>
    /// <param name="label"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public IEnumerable<Guid> GetDocumentsByValue(string label, string value)
    {
      return
        Categories.Where(category => category.Key == label)
                  .TakeWhile(category => category.Value.ContainsKey(value))
                  .SelectMany(category => category.Value[label]);
    }

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
      foreach (var m in metadata)
      {
        lock (_level1)
        {
          if (!Categories.ContainsKey(m.Key))
            Categories.Add(m.Key, new Dictionary<string, IEnumerable<Guid>>());
        }

        foreach (var x in metadata)
        {
          string key;
          try
          {
            key = x.Value.ToString();
          }
          catch
          {
            key = "";
          }

          lock (_level2)
          {
            if (!Categories[m.Key].ContainsKey(key))
              Categories[m.Key].Add(key, new ConcurrentBag<Guid>());
          }

          ((ConcurrentBag<Guid>) Categories[m.Key][key]).Add(dsel);
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
      Categories = new Dictionary<string, Dictionary<string, IEnumerable<Guid>>>();
      _level1 = new object();
      _level2 = new object();
    }
  }
}