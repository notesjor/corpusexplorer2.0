using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Blocks.NGramQuickLookup;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Model.Extension;

namespace CorpusExplorer.Sdk.Blocks
{
  public class Ngram1LayerSelectiveQuickLookupBlock : AbstractBlock
  {
    public Dictionary<string, double> NGramFrequency { get; private set; }
    public IEnumerable<string> LayerQueries { get; set; }
    /// <summary>
    /// Ermöglicht es vorkompilierte Queries zu verwenden. Achtung: Wenn mehrere Korpora eingesetzt werden, müssen die Queries für jedes Korpus neu kompiliert werden.
    /// </summary>
    public Dictionary<int, QuickLookupItem> LayerQueriesPreCompiled { get; set; } = null;
    public string LayerDisplayname { get; set; } = "Wort";

    public override void Calculate()
    {
      var @lock = new object();
      NGramFrequency = new Dictionary<string, double>();

      Parallel.ForEach(Selection.CorporaAndDocumentGuids, csel =>
      {
        var corpus = Selection.GetCorpus(csel.Key);
        var layer = corpus.GetLayers(LayerDisplayname).FirstOrDefault();
        if (layer == null)
          return;

        var queries = LayerQueriesPreCompiled ?? QuickLookupCompiler.Compile(corpus.ToSelection(), LayerDisplayname, LayerQueries);
        if (queries == null || queries.Count == 0)
          return;

        Parallel.ForEach(csel.Value, dsel =>
        {
          var doc = layer[dsel];
          if (doc == null)
            return;

          for (var s = 0; s < doc.Length; s++)
            for (var t = 0; t < doc[s].Length; t++)
            {
              if (!queries.ContainsKey(doc[s][t]))
                continue;
              var match = GetLeafValue(ref doc[s], t + 1, queries[doc[s][t]]);
              if (match == null)
                continue;

              lock (@lock)
              {
                if (!NGramFrequency.ContainsKey(match))
                  NGramFrequency.Add(match, 0);
                NGramFrequency[match]++;
              }
            }
        });
      });
    }

    private string GetLeafValue(ref int[] sentence, int t, QuickLookupItem query)
    {
      if (query.Items.Count == 0)
        return query.LeafValue;
      if (t >= sentence.Length)
        return null;
      return query.Items.ContainsKey(sentence[t]) ? GetLeafValue(ref sentence, t + 1, query.Items[sentence[t]]) : null;
    }
  }
}
