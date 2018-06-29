using CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step.Abstract;
using CorpusExplorer.Sdk.EchtzeitEngine.Model;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

namespace CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step
{
  public class CalculatorStepKwicAnyMatch : AbstractCalculatorStepKwic
  {
    public override string Method => "KwicAnyMatch";

    public override void Calculate(Selection selection, ref UniversalStorage output)
    {
      foreach (var query in Queries)
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