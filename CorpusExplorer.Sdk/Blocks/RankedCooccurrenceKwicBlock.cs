using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

namespace CorpusExplorer.Sdk.Blocks
{
  public class RankedCooccurrenceKwicBlock : AbstractSimple1LayerBlock
  {
    public Dictionary<double, List<Tuple<Guid, Guid, int, string[]>>> RankedResults { get; set; } = new Dictionary<double, List<Tuple<Guid, Guid, int, string[]>>>();
    public Dictionary<string, double> Cooccurrences { get; set; } = new Dictionary<string, double>();
    public string LayerQuery { get; set; } = string.Empty;

    protected override void CalculateCall(AbstractCorpusAdapter corpus, AbstractLayerAdapter layer, Guid dsel, int[][] doc)
    {
      var queries = new List<string> { LayerQuery };
      queries.AddRange(Cooccurrences.Keys);

      var block = Selection.CreateBlock<TextLiveSearchBlock>();
      block.LayerQueries = new AbstractFilterQuery[]
      {
        new FilterQuerySingleLayerFirstAndAnyOtherMatch
        {
          LayerDisplayname = LayerDisplayname,
          LayerQueries = queries
        }
      };
      block.Calculate();

      var internalLock = new object();

      Parallel.ForEach(block.SearchResults, c =>
      {
        Parallel.ForEach(c.Value, d =>
        {
          foreach (var s in d.Value)
          {
            var sent = block.ResultSelection
                            .GetReadableDocument(d.Key, LayerDisplayname)
                            .ReduceToSentence(s.Key)
                            .ToArray();

            var value = sent.Where(x => Cooccurrences.ContainsKey(x)).Sum(x => Cooccurrences[x]);
            lock (internalLock)
            {
              if (RankedResults.ContainsKey(value))
                RankedResults[value].Add(new Tuple<Guid, Guid, int, string[]>(c.Key, d.Key, s.Key, sent));
              else
                RankedResults.Add(value, new List<Tuple<Guid, Guid, int, string[]>>
                {
                    new Tuple<Guid, Guid, int, string[]>(c.Key, d.Key, s.Key, sent)
                });
            }
          }
        });
      });
    }

    protected override void CalculateCleanup()
    {

    }

    protected override void CalculateFinalize()
    {

    }

    protected override void CalculateInitProperties()
    {
      RankedResults = new Dictionary<double, List<Tuple<Guid, Guid, int, string[]>>>();
    }
  }
}
