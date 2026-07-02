using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

namespace CorpusExplorer.Sdk.Blocks
{
  [Serializable]
  public class Ngram1LayerSelectiveBlock : AbstractBlock
  {
    public Dictionary<string, double> NGramFrequency { get; private set; }
    public IEnumerable<string> LayerQueries { get; set; }
    public string LayerDisplayname { get; set; } = "Wort";
    public int NGramSize { get; set; } = 3;
    public bool AutoDetectNGramSize { get; set; } = false;

    public override void Calculate()
    {
      var anyFilter = new HashSet<string>(LayerQueries.SelectMany(x => x.Split(' ')));

      if (AutoDetectNGramSize)
      {
        NGramSize = 1;
        foreach (var q in LayerQueries)
        {
          var size = q.Split(' ').Length;
          if (size > NGramSize)
            NGramSize = size;
        }
      }

      var query = new FilterQuerySingleLayerAnyMatch
      {
        LayerDisplayname = LayerDisplayname,
        LayerQueries = anyFilter
      };
      var selection = Selection.CreateTemporary(new[] { query });

      NGramFrequency = new Dictionary<string, double>();

      if (selection.CountDocuments == 0)
        return;

      // Property FIX!
      if (NGramSize < 1)
        NGramSize = 1;
      if (NGramSize > 99)
        NGramSize = 99;

      var block = selection.CreateBlock<Ngram1LayerBlock>();
      block.NGramSize = NGramSize;
      block.LayerDisplayname = LayerDisplayname;
      block.Calculate();

      foreach(var q in LayerQueries)
      {
        if(block.NGramFrequency.ContainsKey(q))
          NGramFrequency.Add(q, block.NGramFrequency[q]);
      }
    }
  }
}