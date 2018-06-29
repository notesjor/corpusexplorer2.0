using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.Cache.Helper;
using CorpusExplorer.Sdk.Model.Cache.Helper.Exception;

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class FrequencyLeftRightBlock : AbstractSimple1LayerBlock
  {
    [NonSerialized] private readonly BlockCacheHelper _cache = new BlockCacheHelper();

    private readonly object _lockLeft = new object();
    private readonly object _lockRight = new object();

    public FrequencyLeftRightBlock()
    {
      MinimumFrequency = 10;
    }

    public Dictionary<string, Dictionary<string, int>> FrequencyLeft { get; set; }
    public Dictionary<string, Dictionary<string, int>> FrequencyRight { get; set; }
    public int MinimumFrequency { get; set; }

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
      var cache = new Dictionary<int, string>();

      foreach (var s in doc)
        for (var i = 0; i < s.Length; i++)
        {
          string key1;
          if (cache.ContainsKey(s[i]))
          {
            key1 = cache[s[i]];
          }
          else
          {
            key1 = layer[s[i]];
            cache.Add(s[i], key1);
          }

          for (var j = 0; j < s.Length; j++)
          {
            if (i == j)
              continue;

            string key2;
            if (cache.ContainsKey(s[j]))
            {
              key2 = cache[s[j]];
            }
            else
            {
              key2 = layer[s[j]];
              cache.Add(s[j], key2);
            }

            if (j < i)
              lock (_lockLeft)
              {
                if (FrequencyLeft.ContainsKey(key1))
                  if (FrequencyLeft[key1].ContainsKey(key2))
                    FrequencyLeft[key1][key2]++;
                  else
                    FrequencyLeft[key1].Add(key2, 1);
                else
                  FrequencyLeft.Add(key1, new Dictionary<string, int> {{key2, 1}});
              }
            else
              lock (_lockRight)
              {
                if (FrequencyRight.ContainsKey(key1))
                  if (FrequencyRight[key1].ContainsKey(key2))
                    FrequencyRight[key1][key2]++;
                  else
                    FrequencyRight[key1].Add(key2, 1);
                else
                  FrequencyRight.Add(key1, new Dictionary<string, int> {{key2, 1}});
              }
          }
        }
    }

    /// <summary>
    ///   Wird nach der Berechnung aufgerufen (nach CalculateCall)
    ///   und dient der Bereinigung von Daten
    /// </summary>
    protected override void CalculateCleanup()
    {
      if (MinimumFrequency <= 1)
        return;
      FrequencyLeft = FrequencyLeft.GetCleanDictionary(MinimumFrequency);
      FrequencyRight = FrequencyRight.GetCleanDictionary(MinimumFrequency);
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
      if (_cache.AbortCalculation(new Dictionary<string, object> {{nameof(LayerDisplayname), LayerDisplayname}}))
        throw new BlockAlreadyCachedException();

      FrequencyLeft = new Dictionary<string, Dictionary<string, int>>();
      FrequencyRight = new Dictionary<string, Dictionary<string, int>>();
    }
  }
}