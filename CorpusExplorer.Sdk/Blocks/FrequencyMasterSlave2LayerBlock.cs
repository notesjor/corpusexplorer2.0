using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;

#region

using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class FrequencyMasterSlave2LayerBlock : AbstractSimple2LayerBlock, IProvideAggregatedDataItems
  {
    private object _lock;

    public FrequencyMasterSlave2LayerBlock()
    {
      Layer1Displayname = "POS";
      Layer2Displayname = "Phrase";
      MinimumSize = 1;
    }

    public Dictionary<string, Dictionary<string, double>> Frequency { get; set; }
    public int MinimumSize { get; set; }

    /// <summary>
    ///   Gebe eine aggregiertes Ergebnis des abgefragten Levels zurück.
    ///   Wenn null, dann gebe das aggregierte Ergebnis des Root-Levels zurück.
    /// </summary>
    /// <param name="level">Level</param>
    /// <returns>Wenn null, dann exsistieren auf diesem Level keine Items mehr die aggregiert werden könnten.</returns>
    public double? GetAggregatedValue(params string[] level)
    {
      switch (level.Length)
      {
        case 0:
          return Frequency.SelectMany(pos => pos.Value).Sum(w => w.Value);
        case 1:
          return Frequency[level[0]].Sum(w => w.Value);
        case 2:
          return Frequency[level[0]][level[1]];
        default:
          return null;
      }
    }

    /// <summary>
    ///   Gibt die Items des abgefragen Levels zurück.
    ///   Wenn null dann gebe die Items des Root-Levels zurück.
    /// </summary>
    /// <param name="level">Level</param>
    /// <returns>Wenn Level dann gibt es auf diesem Level keine Items mehr</returns>
    public IEnumerable<string> GetItems(params string[] level)
    {
      switch (level.Length)
      {
        case 0:
          return Frequency.Select(x => x.Key);
        case 1:
          return Frequency[level[0]].Select(x => x.Key);
        default:
          return null;
      }
    }

    protected override void CalculateCall(
      AbstractCorpusAdapter corpus,
      Guid dsel,
      AbstractLayerAdapter layer1,
      int[][] doc1,
      AbstractLayerAdapter layer2,
      int[][] doc2)
    {
      for (var i = 0; i < doc1.Length && i < doc2.Length; i++)
      {
        var current = -1;
        var currentKey = string.Empty;
        var chunk = new List<string>();

        for (var j = 0; j < doc1[i].Length && j < doc2[i].Length; j++)
        {
          if (doc1[i][j] != current)
          {
            if (!string.IsNullOrEmpty(currentKey) &&
                chunk.Count > MinimumSize)
              StoreValue(currentKey, string.Join(" ", chunk));

            current = doc1[i][j];
            currentKey = layer1[current];
            chunk = new List<string>();
          }
          if (current == -1)
            continue;

          var value = layer2[doc2[i][j]];
          if (string.IsNullOrEmpty(value))
            continue;

          chunk.Add(value);
        }

        if (!string.IsNullOrEmpty(currentKey) &&
            chunk.Count > MinimumSize)
          StoreValue(currentKey, string.Join(" ", chunk));
      }
    }

    protected override void CalculateCleanup() { }

    protected override void CalculateFinalize() { }

    protected override void CalculateInitProperties()
    {
      Frequency = new Dictionary<string, Dictionary<string, double>>();
      _lock = new object();
    }

    private void StoreValue(string currentKey, string k2)
    {
      lock (_lock)
      {
        if (Frequency.ContainsKey(currentKey))
          if (Frequency[currentKey].ContainsKey(k2))
            Frequency[currentKey][k2]++;
          else
            Frequency[currentKey].Add(k2, 1);
        else
          Frequency.Add(currentKey, new Dictionary<string, double> {{k2, 1}});
      }
    }
  }
}