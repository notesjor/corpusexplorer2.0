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
  ///   Class CooccurrenceBlock.
  /// </summary>
  [Serializable]
  public class CooccurrencePolarisationBlock : AbstractBlock
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="CooccurrenceBlock" /> class.
    /// </summary>
    public CooccurrencePolarisationBlock()
    {
      LayerDisplayname = "Wort";
    }

    /// <summary>
    ///   Wort/Kollokator/Signifikanz-Wörterbuch
    ///   (Speicheroptimiert) - Für ein vollständiges Wörterbuch fragen Sie die Funktion
    ///   GetFullCooccurrencesSignificanceDictionary() ab.
    /// </summary>
    /// <value>The collocates significance.</value>
    // ReSharper disable once MemberCanBePrivate.Global
    public Dictionary<string, double> CooccurrencesPolarisation { get; set; }

    /// <summary>
    ///   Gets or sets the layer displayname.
    /// </summary>
    public string LayerDisplayname { get; set; }

    public string LayerValueA { get; set; }
    public string LayerValueB { get; set; }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      if (string.IsNullOrEmpty(LayerValueA) ||
          string.IsNullOrEmpty(LayerValueB))
        return;

      var block = Selection.CreateBlock<CooccurrenceBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.Calculate();

      var dic = block.CooccurrenceSignificance.CompleteDictionaryToFullDictionary();

      var dicA = dic.ContainsKey(LayerValueA) ? dic[LayerValueA] : new Dictionary<string, double>();
      var dicB = dic.ContainsKey(LayerValueB) ? dic[LayerValueB] : new Dictionary<string, double>();

      var sum = dicA.Sum(x => x.Value) + dicB.Sum(x => x.Value);

      dicA = NormDictionary(dicA, sum, -1, LayerValueB);
      dicB = NormDictionary(dicB, sum, 1, LayerValueA);

      CooccurrencesPolarisation = new Dictionary<string, double>();

      foreach (var a in dicA)
        if (dicB.ContainsKey(a.Key))
        {
          CooccurrencesPolarisation.Add(a.Key, a.Value + dicB[a.Key]);
          dicB.Remove(a.Key);
        }
        else
        {
          CooccurrencesPolarisation.Add(a.Key, -1);
        }

      foreach (var b in dicB)
        CooccurrencesPolarisation.Add(b.Key, 1);
    }

    private static Dictionary<string, double> NormDictionary(
      Dictionary<string, double> dic,
      double sum,
      double factor,
      string filterQuery)
    {
      return dic.Where(d => d.Key != filterQuery).ToDictionary(d => d.Key, d => d.Value / sum * factor);
    }
  }
}