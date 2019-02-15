using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Blocks.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class DuplicateSentenceBlock : AbstractSimple1LayerBlock
  {
    private readonly object _lock = new object();

    public DuplicateSentenceBlock()
    {
      FrequencyMinimum = 1;
    }

    public int FrequencyMinimum { get; set; }
    public Dictionary<string, int> SentenceFrequency { get; set; }

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
      foreach (var s in doc)
      {
        var stb = new StringBuilder();
        foreach (var w in s.Select(x => layer[x]))
        {
          // Wenn w nur k/ein Zeichen lang ist entferne das zuvor führende Leerzeichen.
          if (w.Length   < 2 &&
              stb.Length > 0)
            stb.Remove(stb.Length - 1, 1);

          stb.AppendFormat("{0} ", w);
        }

        var key = stb.ToString();

        lock (_lock)
        {
          if (SentenceFrequency.ContainsKey(key))
            SentenceFrequency[key] += 1;
          else
            SentenceFrequency.Add(key, 1);
        }
      }
    }

    /// <summary>
    ///   Wird nach der Berechnung aufgerufen (nach CalculateCall)
    ///   und dient der Bereinigung von Daten
    /// </summary>
    protected override void CalculateCleanup()
    {
      if (FrequencyMinimum <= 1)
        return;

      var arr = (from s in SentenceFrequency where s.Value < FrequencyMinimum select s.Key).ToArray();

      foreach (var x in arr)
        SentenceFrequency.Remove(x);
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
      SentenceFrequency = new Dictionary<string, int>();
    }
  }
}