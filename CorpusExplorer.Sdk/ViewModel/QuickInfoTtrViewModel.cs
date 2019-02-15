using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.ViewModel.Abstract;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class QuickInfoTtrViewModel : AbstractViewModel
  {
    public int CounterCorpora { get; private set; }
    public int CounterDocuments { get; private set; }
    public int CounterLayers { get; private set; }
    public int CounterTokens { get; private set; }
    public int CounterTypes { get; private set; }
    public double CounterTypeTokenRatio { get; private set; }
    public string LayerDisplayname { get; set; } = "Wort";

    /// <summary>
    ///   The analyse.
    /// </summary>
    protected override void ExecuteAnalyse()
    {
      CounterCorpora = Selection.CountCorpora;
      CounterDocuments = Selection.CountDocuments;
      CounterLayers = Selection.LayerGuids.Count();
      CounterTokens = Selection.CountToken;

      var all = new HashSet<int>();
      var lok = new object();

      Parallel.ForEach(Selection,
                       Configuration.ParallelOptions,
                       csel =>
                       {
                         var corpus = Selection.GetCorpus(csel.Key);
                         var layer = corpus?.GetLayers(LayerDisplayname)?.FirstOrDefault();
                         if (layer == null)
                           return;
                         Parallel.ForEach(csel.Value,
                                          Configuration.ParallelOptions,
                                          dsel =>
                                          {
                                            if (!layer.ContainsDocument(dsel))
                                              return;
                                            var doc = layer[dsel];
                                            if (doc == null)
                                              return;
                                            lock (lok)
                                            {
                                              foreach (var s in doc)
                                              {
                                                if (s == null)
                                                  continue;
                                                foreach (var w in s)
                                                  all.Add(w);
                                              }
                                            }
                                          });
                       });

      CounterTypes = all.Count;
      CounterTypeTokenRatio = CounterTypes / (double) CounterTokens;
    }

    protected override bool Validate()
    {
      return true;
    }
  }
}