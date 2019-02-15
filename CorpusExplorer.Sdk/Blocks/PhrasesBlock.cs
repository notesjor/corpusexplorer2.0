using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class PhrasesBlock : AbstractSimple2LayerBlock
  {
    private readonly object _lock = new object();

    public PhrasesBlock()
    {
      Layer1Displayname = "Phrase";
      Layer2Displayname = "Wort";
    }

    public Dictionary<string, double> Phrases { get; set; }

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
      var res = new Dictionary<string, double>();
      List<string> list = null;
      var idx = -1;

      for (var i = 0; i < doc1.Length; i++)
      {
        for (var j = 0; j < doc1[i].Length; j++)
        {
          if (doc1[i][j] == -1)
          {
            if (list       != null &&
                list.Count > 0)
            {
              var key = string.Join(" ", list);
              if (res.ContainsKey(key))
                res[key]++;
              else
                res.Add(key, 1);
              list = null;
            }

            continue;
          }

          if (list == null)
            list = new List<string>();
          if (doc1[i][j] != idx)
          {
            idx = doc1[i][j];
            if (list.Count > 0)
            {
              var key = string.Join(" ", list);
              if (res.ContainsKey(key))
                res[key]++;
              else
                res.Add(key, 1);
              list = new List<string>();
            }
          }

          list.Add(layer2[doc2[i][j]]);
        }

        if (list       != null &&
            list.Count > 0)
        {
          var key = string.Join(" ", list);
          if (res.ContainsKey(key))
            res[key]++;
          else
            res.Add(key, 1);
        }

        list = null;
      }

      lock (_lock)
      {
        foreach (var x in res)
          if (Phrases.ContainsKey(x.Key))
            Phrases[x.Key] += x.Value;
          else
            Phrases.Add(x.Key, x.Value);
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
      Layer1Displayname = "Phrase";
      Phrases = new Dictionary<string, double>();
    }
  }
}