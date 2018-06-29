using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step.Abstract;
using CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step.Interface;
using CorpusExplorer.Sdk.EchtzeitEngine.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step
{
  public class CalculatorStepFrequency1Layer : AbstractCalculatorStep, ICalculatorStepHasTopFilter
  {
    public CalculatorStepFrequency1Layer()
    {
      Top = 10;
    }

    public override string Method => "Frequency1Layer";

    public int Top { get; set; }

    public override void Calculate(Selection selection, ref UniversalStorage output)
    {
      var block = selection.CreateBlock<Frequency1LayerBlock>();
      block.Calculate();

      IEnumerable<KeyValuePair<string, double>> tmp = block.Frequency;

      if (Top > 0)
        tmp = (from x in tmp
          orderby
            x.Value
              descending
          select x).Take(Top);

      output.Set(selection, Method, "", tmp.ToDataTable(block.LayerDisplayname, "Frequency"));
    }
  }
}