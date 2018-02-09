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
  public class CalculatorStepCrossFrequency : AbstractCalculatorStep, ICalculatorStepHasTopFilter
  {
    public CalculatorStepCrossFrequency()
    {
      Top = 10;
    }

    public override string Method => "CrossFrequency";

    public override void Calculate(Selection selection, ref UniversalStorage output)
    {
      var block = selection.CreateBlock<CrossFrequencyBlock>();
      block.Calculate();

      IEnumerable<KeyValuePair<string, Dictionary<string, double>>> tmp = block.CooccurrencesFrequency;

      if (Top > 0)
        tmp = (from x in tmp
               from y in x.Value
               orderby y.Value
               descending
               select x).Take(Top);

      output.Set(selection, Method, "", tmp.ToDataTable("A", "B", "CrossFrequency"));
    }

    public int Top { get; set; }
  }
}