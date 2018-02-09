using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step.Abstract;
using CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step.Interface;
using CorpusExplorer.Sdk.EchtzeitEngine.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step
{
  public class CalculatorStepCooccurrecesSelective : AbstractCalculatorStep, ICalculatorStepHasMultiQueries
  {
    public CalculatorStepCooccurrecesSelective() { Queries = new string[0]; }

    public override string Method => "SelectiveCooccurreces";

    public override void Calculate(Selection selection, ref UniversalStorage output)
    {
      var block = selection.CreateBlock<CooccurrenceBlock>();
      block.Calculate();

      var signi = block.CooccurrenceSignificance.CompleteDictionaryToFullDictionary();
      var frequ = block.CooccurrenceFrequency.CompleteDictionaryToFullDictionary();

      foreach (var query in Queries)
      {
        if (!signi.ContainsKey(query))
          continue;

        var dt = new DataTable();
        dt.Columns.Add("B", typeof(string));
        dt.Columns.Add("CrossFrequency", typeof(double));
        dt.Columns.Add("Significance", typeof(double));

        dt.BeginLoadData();

        var temp = signi[query].OrderByDescending(x => x.Value);

        foreach (var x in temp)
        {
          dt.Rows.Add(
            x.Key,
            frequ.ContainsKey(x.Key) && frequ[x.Key].ContainsKey(x.Key) ? frequ[query][x.Key] : -1,
            x.Value);
        }

        dt.EndLoadData();

        output.Set(selection, Method, query, dt);
      }      
    }

    public IEnumerable<string> Queries { get; set; }
  }
}