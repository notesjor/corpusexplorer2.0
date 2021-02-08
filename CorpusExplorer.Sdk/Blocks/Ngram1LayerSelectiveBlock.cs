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

    public override void Calculate()
    {
      var query = new FilterQuerySingleLayerAnyMatch
      {
        LayerDisplayname = LayerDisplayname,
        LayerQueries = LayerQueries
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

      var sub = selection.CreateBlock<Ngram1LayerBlock>();
      sub.NGramSize = NGramSize;
      sub.LayerDisplayname = LayerDisplayname;
      sub.Calculate();

      var @lock = new object();
      var filter = new HashSet<string>(LayerQueries);

      Parallel.ForEach(sub.NGramFrequency, ngram =>
      {
        var split = ngram.Key.Split(' ');
        if (!split.Any(s => filter.Contains(s))) 
          return;

        lock (@lock)
          if (NGramFrequency.ContainsKey(ngram.Key))
            NGramFrequency[ngram.Key] += ngram.Value;
          else
            NGramFrequency.Add(ngram.Key, ngram.Value);
      });
    }
  }
}