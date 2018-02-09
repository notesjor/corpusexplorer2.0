using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;

namespace CorpusExplorer.Sdk.Blocks
{
  /// <summary>
  ///   The hyphen block.
  /// </summary>
  [Serializable]
  public class WordHyphenResolverBlock : AbstractBlock
  {
    private readonly object _hyphenLock = new object();
    public string LayerDisplayname { get; set; } = "Wort";

    /// <summary>
    ///   Silbe/Frequenz-Wörterbuch
    /// </summary>
    public Dictionary<string, IEnumerable<string>> WordHyphens { get; set; }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      WordHyphens = new Dictionary<string, IEnumerable<string>>();
      var layers = Selection.GetLayers(LayerDisplayname);

      foreach (
        var value in from layer in layers from value in layer.Values where !WordHyphens.ContainsKey(value) select value)
        try
        {
          string w;
          lock (_hyphenLock)
          {
            w = Configuration.Hyphen.Hyphenate(value)?.HyphenatedWord;
          }
          if (w == null)
            continue;
          WordHyphens.Add(value, w.Split(new[] {"="}, StringSplitOptions.RemoveEmptyEntries));
        }
        catch
        {
          // ignore
        }
    }
  }
}