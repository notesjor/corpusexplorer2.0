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
  public class CalculatorStepFrequency2LayerPosFilter : AbstractCalculatorStep, ICalculatorStepHasTopFilter, ICalculatorStepHasPosFilter
  {
    public CalculatorStepFrequency2LayerPosFilter()
    {
      Top = 10;
    }

    public override string Method => "Frequency1LayerPosTags";

    public override void Calculate(Selection selection, ref UniversalStorage output)
    {
      var block = selection.CreateBlock<Frequency2LayerBlock>();
      block.Calculate();

      var tmp = block.Frequency;

      if (Top > 0)
      {
        tmp = PosTags.Where(pos => tmp.ContainsKey(pos))
                     .ToDictionary(
                       pos => pos,
                       pos =>
                         (from x in tmp[pos]
                          orderby x.Value descending
                          select x)
                         .Take(Top)
                         .ToDictionary(
                           x => x.Key,
                           x => x.Value));
      }

      output.Set(selection, Method, "", tmp.ToDataTable(block.Layer1Displayname, "Frequency"));
    }

    public int Top { get; set; }
    public IEnumerable<string> PosTags { get; set; }
  }
}