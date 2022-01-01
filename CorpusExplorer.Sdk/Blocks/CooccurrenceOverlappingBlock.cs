using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.Filter;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

namespace CorpusExplorer.Sdk.Blocks
{
  public class CooccurrenceOverlappingBlock : AbstractBlock
  {
    private Dictionary<string, Dictionary<string, double>> _crossFrequency;
    public Dictionary<string, double> CooccurrenceFrequency { get; set; }
    public bool IgnoreSentenceMarks { get; set; }
    public Dictionary<string, double> CooccurrenceSignificance { get; set; }
    public string LayerDisplayname { get; set; } = "Wort";
    public IEnumerable<string> LayerQueries { get; set; }

    public override void Calculate()
    {
      if (LayerQueries == null)
        return;

      var queries = new HashSet<string>(LayerQueries);
      var filter = QuickQuery.SearchOnSentenceLevel(
                                                     Selection,
                                                     new[]
                                                     {
                                                       new FilterQuerySingleLayerAllInOneSentence
                                                       {
                                                         LayerDisplayname = LayerDisplayname,
                                                         LayerQueries = queries
                                                       }
                                                     });

      var matches = filter.SelectMany(c => c.Value).Sum(d => d.Value.Count);
      CooccurrenceFrequency = new Dictionary<string, double>();

      if (matches == 0)
        return;
      var sentences = Selection.CountSentences;

      CalculateCrossFrequency();

      var cflock = new object();
      Parallel.ForEach(
                       filter,
                       Configuration.ParallelOptions,
                       csel =>
                       {
                         var corpus = Selection.GetCorpus(csel.Key);
                         var layer = corpus?.GetLayers(LayerDisplayname)?.FirstOrDefault();
                         if (layer == null)
                           return;

                         Parallel.ForEach(
                                          csel.Value,
                                          Configuration.ParallelOptions,
                                          dsel =>
                                          {
                                            var doc = layer[dsel.Key];
                                            if (doc == null)
                                              return;

                                            foreach (var sidx in dsel.Value)
                                            {
                                              var once = new HashSet<string>(doc[sidx].Select(x => layer[x]));
                                              foreach (var x in once)
                                              {
                                                if (string.IsNullOrEmpty(x) || queries.Contains(x))
                                                  continue;

                                                lock (cflock)
                                                {
                                                  if (CooccurrenceFrequency.ContainsKey(x))
                                                    CooccurrenceFrequency[x]++;
                                                  else
                                                    CooccurrenceFrequency.Add(x, 1.0);
                                                }
                                              }
                                            }
                                          });
                       });

      CooccurrenceSignificance = new Dictionary<string, double>();
      var signi = Configuration.GetSignificance(matches, sentences);
      foreach (var x in CooccurrenceFrequency)
        try
        {
          if (string.IsNullOrEmpty(x.Key))
            continue;

          var val = signi.Calculate(_crossFrequency[x.Key][x.Key], x.Value);
          if (double.IsNaN(val) || double.IsInfinity(val) || val <= Configuration.MinimumSignificance)
            continue;
          CooccurrenceSignificance.Add(x.Key, val);
        }
        catch
        {
          // ignore
        }
    }

    private void CalculateCrossFrequency()
    {
      if (IgnoreSentenceMarks)
      {
        var block = Selection.CreateBlock<CrossFrequencyDocumentBasedBlock>();
        block.LayerDisplayname = LayerDisplayname;
        block.Calculate();
        _crossFrequency = block.CooccurrencesFrequency;
      }
      else
      {
        var block = Selection.CreateBlock<CrossFrequencyBlock>();
        block.LayerDisplayname = LayerDisplayname;
        block.Calculate();
        _crossFrequency = block.CooccurrencesFrequency;
      }
    }
  }
}