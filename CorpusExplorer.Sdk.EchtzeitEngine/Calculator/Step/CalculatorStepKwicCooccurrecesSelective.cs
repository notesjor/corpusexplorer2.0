using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step.Abstract;
using CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step.Interface;
using CorpusExplorer.Sdk.EchtzeitEngine.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

namespace CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step
{
  public class CalculatorStepKwicCooccurrecesSelective : AbstractCalculatorStepKwic, ICalculatorStepHasTopFilter
  {
    public override string Method => "KwicSelectiveCooccurreces";

    public int Top { get; set; }

    public override void Calculate(Selection selection, ref UniversalStorage output)
    {
      var block = selection.CreateBlock<CooccurrenceBlock>();
      block.Calculate();

      var signi = block.CooccurrenceSignificance.CompleteDictionaryToFullDictionary();

      foreach (var query in Queries)
      {
        if (!signi.ContainsKey(query))
          continue;

        IEnumerable<KeyValuePair<string, double>> tmp = signi[query];
        if (Top > 0)
          tmp = signi[query].OrderByDescending(x => x.Value).Take(Top);

        foreach (var cooc in tmp)
          output.Set(
            selection,
            Method,
            $"{query} - {cooc.Key}",
            RequestDataTableViaTextLive(
              selection,
              new FilterQuerySingleLayerAllInOneSentence
              {
                LayerDisplayname = "Wort",
                LayerQueries = new[] {query, cooc.Key}
              }));
      }
    }
  }
}