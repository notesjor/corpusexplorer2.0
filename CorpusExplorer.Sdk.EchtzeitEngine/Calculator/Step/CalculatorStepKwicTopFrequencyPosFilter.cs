using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step.Abstract;
using CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step.Interface;
using CorpusExplorer.Sdk.EchtzeitEngine.Model;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

namespace CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step
{
  public class CalculatorStepKwicTopFrequencyPosFilter : AbstractCalculatorStepKwic, ICalculatorStepHasTopFilter,
    ICalculatorStepHasPosFilter
  {
    public CalculatorStepKwicTopFrequencyPosFilter()
    {
      Top = 10;
      PosTags = new string[0];
    }

    public override string Method => "KwicTopFrequencyPosFilter";

    public IEnumerable<string> PosTags { get; set; }

    public int Top { get; set; }

    public override void Calculate(Selection selection, ref UniversalStorage output)
    {
      var block = selection.CreateBlock<Frequency2LayerBlock>();
      block.Calculate();

      var queries = new HashSet<string>(Queries);
      foreach (var pos in PosTags)
        if (block.Frequency.ContainsKey(pos))
          foreach (string s in block.Frequency[pos].OrderByDescending(x => x.Value).Take(Top).Select(x => x.Key))
            queries.Add(s);

      foreach (var query in queries)
        output.Set(
          selection,
          Method,
          query,
          RequestDataTableViaTextLive(
            selection,
            new FilterQuerySingleLayerAnyMatch
            {
              LayerDisplayname = "Wort",
              LayerQueries = new[] {query}
            }));
    }
  }
}