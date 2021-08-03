#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Helper;

#endregion

namespace CorpusExplorer.Sdk.Blocks
{
  /// <summary>
  ///   The single cooccurrence block.
  /// </summary>
  [Serializable]
  public class CooccurrenceSpreadingBlock : AbstractBlock
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="CooccurrenceSpreadingBlock" /> class.
    /// </summary>
    public CooccurrenceSpreadingBlock()
    {
      LayerDisplayname = "Wort";
      LayerQueries = new string[0];
    }

    /// <summary>
    ///   Frequenz Suchwort
    /// </summary>
    /// <value>The count sentences.</value>
    public long CountSentences { get; set; }

    /// <summary>
    ///   Gets or sets the layer displayname.
    /// </summary>
    /// <value>The layer displayname.</value>
    public string LayerDisplayname { get; set; }

    /// <summary>
    ///   Gets or sets the layer queries.
    /// </summary>
    /// <value>The layer queries.</value>
    public IEnumerable<string> LayerQueries { get; set; }

    /// <summary>
    ///   Gets or sets the significance average collocates.
    /// </summary>
    /// <value>The significance average collocates.</value>
    public Dictionary<string, double> SignificanceAverageCooccurrence { get; set; }

    /// <summary>
    ///   Kollokatoren/Signifikanz-Wörterbuch
    /// </summary>
    /// <value>The significance best collocates.</value>
    public Dictionary<string, double> SignificanceBestCooccurrence { get; set; }

    /// <summary>
    ///   Gets or sets the significance standard deviation collocates.
    /// </summary>
    /// <value>The significance standard deviation collocates.</value>
    public Dictionary<string, double> SignificanceStandardDeviationCooccurrence { get; set; }

    /// <summary>
    ///   Gets or sets the significance worst collocates.
    /// </summary>
    /// <value>The significance worst collocates.</value>
    public Dictionary<string, double> SignificanceWorstCooccurrence { get; set; }

    /// <summary>
    ///   The calculate.
    /// </summary>
    public override void Calculate()
    {
      var block = Selection.CreateBlock<CooccurrenceBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.Calculate();
      var dir = block.CooccurrenceSignificance.CompleteDictionaryToFullDictionary();

      CountSentences = block.CountSentences;

      var temp = new Dictionary<string, List<double>>();
      foreach (
        var coll in LayerQueries.Where(dir.ContainsKey).Select(query => dir[query]).SelectMany(colls => colls))
        if (temp.ContainsKey(coll.Key))
          temp[coll.Key].Add(coll.Value);
        else
          temp.Add(coll.Key, new List<double> {coll.Value});

      SignificanceBestCooccurrence = temp.ToDictionary(x => x.Key, x => x.Value.Max());
      SignificanceWorstCooccurrence = temp.ToDictionary(x => x.Key, x => x.Value.Min());
      SignificanceAverageCooccurrence = new Dictionary<string, double>();
      SignificanceStandardDeviationCooccurrence = new Dictionary<string, double>();

      foreach (var entry in temp)
      {
        var sum = entry.Value.Sum();
        var cnt = (double) entry.Value.Count;

        var avr = sum                                     / cnt;
        var std = entry.Value.Sum(x => Math.Abs(x - avr)) / cnt;

        SignificanceAverageCooccurrence.Add(entry.Key, avr);
        SignificanceStandardDeviationCooccurrence.Add(entry.Key, std);
      }
    }
  }
}