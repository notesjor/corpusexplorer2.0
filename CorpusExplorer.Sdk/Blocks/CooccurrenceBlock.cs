﻿#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.Cooccurrence;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Cache.Helper;

#endregion

namespace CorpusExplorer.Sdk.Blocks
{
  /// <summary>
  ///   Class CooccurrenceBlock.
  /// </summary>
  [Serializable]
  public class CooccurrenceBlock : AbstractBlock
  {
    [NonSerialized] private readonly BlockCacheHelper _cache = new BlockCacheHelper();
    [NonSerialized] private CrossFrequencyBlock _block;

    /// <summary>
    ///   Initializes a new instance of the <see cref="CooccurrenceBlock" /> class.
    /// </summary>
    public CooccurrenceBlock()
    {
      LayerDisplayname = "Wort";
    }

    /// <summary>
    ///   Wort/Kollokator/Frequenz-Wörterbuch
    ///   (Speicheroptimiert) - Für ein vollständiges Wörterbuch fragen Sie die Funktion
    ///   GetFullCooccurrencesFrequencyDictionary()
    ///   ab.
    /// </summary>
    /// <value>The collocates frequency.</value>
    // ReSharper disable once MemberCanBePrivate.Global
    public Dictionary<string, Dictionary<string, double>> CooccurrenceFrequency => _block?.CooccurrencesFrequency;

    /// <summary>
    ///   Wort/Kollokator/Signifikanz-Wörterbuch
    ///   (Speicheroptimiert) - Für ein vollständiges Wörterbuch fragen Sie die Funktion
    ///   GetFullCooccurrencesSignificanceDictionary() ab.
    /// </summary>
    /// <value>The collocates significance.</value>
    // ReSharper disable once MemberCanBePrivate.Global
    public Dictionary<string, Dictionary<string, double>> CooccurrenceSignificance { get; private set; }

    /// <summary>
    ///   Satzanzahl
    /// </summary>
    /// <value>The count sentences.</value>
    // ReSharper disable once MemberCanBePrivate.Global
    public long CountSentences { get; private set; }

    /// <summary>
    ///   Gets or sets the layer displayname.
    /// </summary>
    public string LayerDisplayname { get; set; }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      if (_cache.AbortCalculation(new Dictionary<string, object> { { nameof(LayerDisplayname), LayerDisplayname } }))
        return;

      _block = Selection.CreateBlock<CrossFrequencyBlock>();
      _block.LayerDisplayname = LayerDisplayname;
      _block.Calculate();

      CountSentences = Selection.CountSentences;
      CooccurrenceSignificance = new Dictionary<string, Dictionary<string, double>>();
      var @lock = new object();

      Parallel.ForEach(
                       _block.CooccurrencesFrequency,
                       Configuration.ParallelOptions,
                       word =>
                       {
                         ISignificance signi;
                         try
                         {
                           signi = Configuration.GetSignificance(
                                                                 _block.CooccurrencesFrequency[word.Key][word.Key],
                                                                 CountSentences);
                         }
                         catch
                         {
                           return;
                         }

                         var dic = new Dictionary<string, double>();
                         var hsh = new HashSet<string> { word.Key };

                         foreach (var collocate in word.Value)
                         {
                           if (hsh.Contains(collocate.Key))
                             continue;
                           hsh.Add(collocate.Key);

                           var val = signi.Calculate(_block.CooccurrencesFrequency[collocate.Key][collocate.Key],
                                                     collocate.Value);

                           if (double.IsInfinity(val) || double.IsNaN(val) || val < Configuration.MinimumSignificance)
                             continue;

                           dic.Add(collocate.Key, val);
                         }

                         if (dic.Count <= 0)
                           return;

                         lock (@lock)
                         {
                           CooccurrenceSignificance.Add(word.Key, dic);
                         }
                       });
    }

    public Dictionary<string, double> GetCooccurrenceRank()
    {
      var keys = new Dictionary<string, double>();
      var cooc = CooccurrenceSignificance.CompleteDictionaryToFullDictionary();

      foreach (var x in cooc)
        foreach (var y in x.Value)
        {
          if (keys.ContainsKey(x.Key))
          {
            if (keys[x.Key] < y.Value)
              keys[x.Key] = y.Value;
          }
          else
          {
            keys.Add(x.Key, y.Value);
          }

          if (keys.ContainsKey(y.Key))
          {
            if (keys[y.Key] < y.Value)
              keys[y.Key] = y.Value;
          }
          else
          {
            keys.Add(y.Key, y.Value);
          }
        }

      return keys;
    }

    /// <summary>
    /// Gibt alle Kookkurrenzen zum Token zurück (erspart Konvertierung in Vollmatrix).
    /// </summary>
    /// <param name="token">Token</param>
    /// <returns>Alle Kookkurrenzen</returns>
    public Dictionary<string, double> SearchCooccurrence(string token)
    {
      var res = CooccurrenceSignificance.ContainsKey(token) ? CooccurrenceSignificance[token] : new Dictionary<string, double>();
      foreach (var pair in CooccurrenceSignificance.Where(pair => pair.Value.ContainsKey(token)))
        res.Add(pair.Key, pair.Value[token]);

      return res;
    }
  }
}