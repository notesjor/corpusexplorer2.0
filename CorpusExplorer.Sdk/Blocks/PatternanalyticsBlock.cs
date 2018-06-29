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
  public class PatternanalyticsBlock : AbstractSimple2LayerBlock
  {
    private readonly object _lockPattern = new object();

    public PatternanalyticsBlock()
    {
      Layer1Displayname = "Wort";
      Layer2Displayname = "POS";

      Layer2PatternReplacements = new Dictionary<string, string>
      {
        {"NE", "NOM"},
        {"NE", "NOM"},

        {"PDS", "PP"},
        {"PDAT", "PP"},
        {"PIS", "PP"},
        {"PIAT", "PP"},
        {"PIDAT", "PP"},
        {"PPER", "PP"},
        {"PPOSS", "PP"},
        {"PPOSAT", "PP"},
        {"PRELS", "PP"},
        {"PRELAT", "PP"},
        {"PRF", "PP"},
        {"PWS", "PP"},
        {"PWAT", "PP"},
        {"PWAV", "PP"},

        {"KOUI", "+"},
        {"KOUS", "+"},
        {"KON", "+"},
        {"KOKOM", "+"}
      };
      PatternSize = 5;
    }

    public Dictionary<string, string> Layer2PatternReplacements { get; set; }
    public Dictionary<string, Dictionary<string, int>> Patterns { get; set; }
    public int PatternSize { get; set; }

    public Dictionary<string, int> PatternsSum
    {
      get { return Patterns.ToDictionary(x => x.Key, x => x.Value.Sum(y => y.Value)); }
    }

    /// <summary>
    ///   Führt die Berechnung aus
    /// </summary>
    /// <param name="corpus">
    ///   Korpus
    /// </param>
    /// <param name="dsel">
    ///   Dokument GUID
    /// </param>
    /// <param name="layer1">
    ///   Layer 1
    /// </param>
    /// <param name="doc1">
    ///   Dokument 1
    /// </param>
    /// <param name="layer2">
    ///   Layer 2
    /// </param>
    /// <param name="doc2">
    ///   Dokument 2
    /// </param>
    protected override void CalculateCall(
      AbstractCorpusAdapter corpus,
      Guid dsel,
      AbstractLayerAdapter layer1,
      int[][] doc1,
      AbstractLayerAdapter layer2,
      int[][] doc2)
    {
      var patterns = reciveHashsetDictionary(layer2);

      for (var i = 0; i < doc2.Length; i++)
      {
        var list = new List<string>();
        var text = new List<string>();

        for (var j = 0; j < doc2[i].Length; j++)
        {
          text.Add(layer1[doc1[i][j]]);

          var done = false;
          foreach (var pattern in patterns.Where(pattern => pattern.Value.Contains(doc2[i][j])))
          {
            list.Add(pattern.Key);
            done = true;
            break;
          }

          if (!done)
            list.Add(layer1[doc1[i][j]]);
        }

        var key1 = string.Join(" ", list);
        lock (_lockPattern)
        {
          if (!Patterns.ContainsKey(key1))
            Patterns.Add(key1, new Dictionary<string, int>());
          var key2 = string.Join(" ", text);
          if (Patterns[key1].ContainsKey(key2))
            Patterns[key1][key2] += 1;
          else
            Patterns[key1].Add(key2, 1);
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
      Patterns = new Dictionary<string, Dictionary<string, int>>();
    }

    private Dictionary<string, HashSet<int>> reciveHashsetDictionary(AbstractLayerAdapter layer2)
    {
      throw new NotImplementedException();
      /*
      lock (_lockHashsetDictionary)
      {
        if (_cachePattern.ContainsKey(layer2.Guid))
          return _cachePattern[layer2.Guid];

        var entry = new Dictionary<string, HashSet<int>>();
        foreach (var item in Layer2PatternReplacements)
        {
          var hash = new HashSet<int>();
          foreach (var i in item.Value)
            hash.Add(layer2[i]);
          entry.Add(item.Key, hash);
        }

        _cachePattern.Add(layer2.Guid, entry);
        return entry;
      }
      */
    }
  }
}