using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step.Abstract;
using CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step.Interface;
using CorpusExplorer.Sdk.EchtzeitEngine.Model;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step
{
  public class CalculatorStepDistribution : AbstractCalculatorStep, ICalculatorStepHasTopFilter
  {
    public CalculatorStepDistribution()
    {
      Top = 10;
    }

    public override string Method => "CorpusDistribution";

    public int Top { get; set; } = -1;

    public override void Calculate(Selection selection, ref UniversalStorage output)
    {
      var block = selection.CreateBlock<DocumentMetadataWeightBlock>();
      block.Calculate();

      var tmp = block.GetAggregatedSize();
      if (Top > 0)
      {
        var dic = new Dictionary<string, Dictionary<string, double[]>>();
        foreach (var x in tmp)
        {
          var sub = x.Value.OrderByDescending(y => y.Value[0]).Take(Top);
          dic.Add(x.Key, sub.ToDictionary(y => y.Key, y => y.Value));
        }

        tmp = dic;
      }

      var dt = new DataTable();
      dt.Columns.Add("Category", typeof(string));
      dt.Columns.Add("MetaValue", typeof(string));
      dt.Columns.Add("Token", typeof(double));
      dt.Columns.Add("Types", typeof(double));
      dt.Columns.Add("Documents", typeof(double));
      dt.BeginLoadData();

      foreach (var x in tmp)
      foreach (var y in x.Value)
        dt.Rows.Add(x.Key, y.Key, y.Value[0], y.Value[1], y.Value[2]);

      dt.EndLoadData();
      output.Set(selection, Method, "", dt);
    }
  }
}