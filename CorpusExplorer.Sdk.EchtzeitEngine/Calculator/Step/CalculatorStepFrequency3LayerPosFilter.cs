using System;
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
  public class CalculatorStepFrequency3LayerPosFilter : AbstractCalculatorStep, ICalculatorStepHasTopFilter,
    ICalculatorStepHasPosFilter
  {
    public CalculatorStepFrequency3LayerPosFilter()
    {
      Top = 10;
      PosTags = new string[0];
    }

    public override string Method => "Frequency3LayerPosFilter";

    public IEnumerable<string> PosTags { get; set; }

    public int Top { get; set; }

    public override void Calculate(Selection selection, ref UniversalStorage output)
    {
      var block = selection.CreateBlock<Frequency3LayerBlock>();
      block.Calculate();
      var tmp = block.Frequency;

      if (Top > 0)
      {
        var dic = new Dictionary<string, Dictionary<string, Dictionary<string, double>>>();
        foreach (var pos in PosTags)
        {
          if (!tmp.ContainsKey(pos))
            continue;

          var temp = (from x in tmp[pos]
            from y in x.Value
            orderby y.Value descending
            select new Tuple<string, string, double>(x.Key, y.Key, y.Value)).Take(Top);
          var tdic = new Dictionary<string, Dictionary<string, double>>();
          foreach (var x in temp)
            if (tdic.ContainsKey(x.Item1))
              tdic[x.Item1].Add(x.Item2, x.Item3);
            else
              tdic.Add(x.Item1, new Dictionary<string, double> {{x.Item2, x.Item3}});
          dic.Add(pos, tdic);
        }

        tmp = dic;
      }

      output.Set(
        selection,
        Method,
        "",
        tmp.ToDataTable(
          block.Layer1Displayname,
          block.Layer2Displayname,
          block.Layer3Displayname,
          "Frequency"));
    }
  }
}