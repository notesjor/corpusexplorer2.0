#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;

#endregion

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class NgramPhoneticBlock : AbstractBlock
  {
    public NgramPhoneticBlock()
    {
      NGramSeparator = "*";
      NGramSize = 3;
      NGramFrequency = null;
    }

    /// <summary>
    ///   Ngramm/Frequenz-Wörterbuch
    /// </summary>
    public Dictionary<string, double> NGramFrequency { get; set; }

    public string NGramSeparator { get; set; }

    /// <summary>
    ///   Gets or sets the n gram size.
    /// </summary>
    public int NGramSize { get; set; }

    /// <summary>
    ///   Funktion die aufgerufen wird, wenn eine Berechnung durchgeführt werden soll.
    /// </summary>
    public override void Calculate()
    {
      var block = Selection.CreateBlock<Frequency1LayerBlock>();
      block.LayerDisplayname = "Wort";
      block.Calculate();

      var @lock = new object();

      NGramFrequency = new Dictionary<string, double>();

      Parallel.ForEach(
        block.Frequency,
        Configuration.ParallelOptions,
        entry =>
        {
          var chunks = GetChunks(entry.Key);
          foreach (var chunk in chunks)
            lock (@lock)
            {
              if (NGramFrequency.ContainsKey(chunk))
                NGramFrequency[chunk] += entry.Value;
              else
                NGramFrequency.Add(chunk, entry.Value);
            }
        });
    }

    private IEnumerable<string> GetChunks(string text)
    {
      var start = 0;
      var stop = start + NGramSize;

      if (stop > text.Length)
        return new[] {text};

      var res = new HashSet<string>();
      while (stop < text.Length)
      {
        var chunk = start == 0
          ? text.Substring(0, NGramSize) + NGramSeparator
          : (stop == text.Length - 1
            ? NGramSeparator + text.Substring(start)
            : NGramSeparator + text.Substring(start, NGramSize) + NGramSeparator);

        if (!res.Contains(chunk))
          res.Add(chunk);

        start++;
        stop = start + NGramSize;
      }

      return res;
    }
  }
}