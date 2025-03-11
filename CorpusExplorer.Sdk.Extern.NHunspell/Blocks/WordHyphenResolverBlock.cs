#if UNIVERSAL
#else
using NHunspell;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Extern.NHunspell.Blocks
{
#if UNIVERSAL
#else
  /// <summary>
  ///   The hyphen block.
  /// </summary>
  [Serializable]
  public class WordHyphenResolverBlock : AbstractBlock
  {
    private readonly object _hyphenLock = new object();
    private readonly object _parallelLock = new object();
    public string LayerDisplayname { get; set; } = "Wort";

    /// <summary>
    ///   Silbe/Frequenz-W�rterbuch
    /// </summary>
    public Dictionary<string, IEnumerable<string>> WordHyphens { get; set; }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgef�hrt werden soll.
    /// </summary>
    public override void Calculate()
    {
      lock (_parallelLock)
      {
        using (var hyphen = new Hyphen(Configuration.GetDependencyPath(@"NHunspell\hyphenation\hyph_de_DE.dic")))
        {
          WordHyphens = new Dictionary<string, IEnumerable<string>>();
          var layers = Selection.GetLayers(LayerDisplayname);

          foreach (
            var value in from layer in layers
                         from value in layer.Values
                         where !WordHyphens.ContainsKey(value)
                         select value)
            try
            {
              string w;
              lock (_hyphenLock)
              {
                w = hyphen.Hyphenate(value)?.HyphenatedWord;
              }

              if (w == null)
                continue;
              WordHyphens.Add(value, w.Split(Splitter.Equal, StringSplitOptions.RemoveEmptyEntries));
            }
            catch
            {
              // ignore
            }
        }
      }
    }
  }
#endif
}