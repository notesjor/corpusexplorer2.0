#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.Cooccurrence;
using CorpusExplorer.Sdk.Blocks.CrossFrequencySelected;
using CorpusExplorer.Sdk.Blocks.CrossFrequencySelected.Abstract;
using CorpusExplorer.Sdk.Blocks.Range;
using CorpusExplorer.Sdk.Blocks.Range.Abstract;
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
  public class CooccurrenceClassicBlock : AbstractBlock
  {
    [NonSerialized] private readonly BlockCacheHelper _cache = new BlockCacheHelper();
    [NonSerialized] private Frequency1LayerOneOccurrencePerSentenceBlock _blockFpS;
    [NonSerialized] private CrossFrequencySelectedRangeBlock _blockCF;

    /// <summary>
    ///   Initializes a new instance of the <see cref="CooccurrenceClassicBlock" /> class.
    /// </summary>
    public CooccurrenceClassicBlock()
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
    public Dictionary<string, Dictionary<string, double>> CooccurrenceFrequency => _blockCF?.CooccurrencesFrequency;

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
    /// Gets or sets the ranges.
    /// </summary>
    /// <value>The ranges.</value>
    public AbstractRange Ranges { get; set; } = new RangeSimple(-5, 5);

    public IEnumerable<string> LayerQueries { get; set; }
      = Array.Empty<string>();

    public AbstractCrossFrequencySelectedBehaviour Behaviour { get; set; }
      = new CrossFrequencySelectedBehaviourAnyMatch();

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      if (_cache.AbortCalculation(new Dictionary<string, object> { { nameof(LayerDisplayname), LayerDisplayname } }))
        return;

      _blockFpS = Selection.CreateBlock<Frequency1LayerOneOccurrencePerSentenceBlock>();
      _blockFpS.LayerDisplayname = LayerDisplayname;
      _blockFpS.Calculate();

      _blockCF = Selection.CreateBlock<CrossFrequencySelectedRangeBlock>();
      _blockCF.LayerDisplayname = LayerDisplayname;
      _blockCF.LayerQueries = LayerQueries;
      _blockCF.Behaviour = Behaviour;
      _blockCF.Ranges = Ranges;
      _blockCF.Calculate();

      CountSentences = Selection.CountSentences;
      CooccurrenceSignificance = new Dictionary<string, Dictionary<string, double>>();
      var @lock = new object();

      var signi = Configuration.GetSignificance(_blockCF.TotalMatches, CountSentences);

      Parallel.ForEach(
                       _blockCF.CooccurrencesFrequency,
                       Configuration.ParallelOptions,
                       word =>
                       {
                         var dic = new Dictionary<string, double>();
                         var hsh = new HashSet<string> { word.Key };

                         foreach (var collocate in word.Value.Where(collocate => !hsh.Contains(collocate.Key)))
                         {
                           hsh.Add(collocate.Key);

                           var val = signi.Calculate(_blockFpS.Frequency[collocate.Key], collocate.Value);

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
  }
}