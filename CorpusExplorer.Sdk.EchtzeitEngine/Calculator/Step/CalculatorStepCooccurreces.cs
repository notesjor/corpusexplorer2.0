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
  public class CalculatorStepCooccurreces : AbstractCalculatorStep, ICalculatorStepHasTopFilter
  {
    public CalculatorStepCooccurreces()
    {
      Top = 10;
    }

    public override string Method => "Cooccurreces";

    public override void Calculate(Selection selection, ref UniversalStorage output)
    {
      var block = selection.CreateBlock<CooccurrenceBlock>();
      block.Calculate();
      
      IEnumerable<KeyValuePair<string, Dictionary<string, double>>> tmp = block.CooccurrenceSignificance;
      var frequ = block.CooccurrenceFrequency;

      if (Top > 0)
        tmp = (from x in tmp
               from y in x.Value
               orderby y.Value
               descending
               select x).Take(Top);

      var dt = new DataTable();
      dt.Columns.Add("A", typeof(string));
      dt.Columns.Add("B", typeof(string));
      dt.Columns.Add("CrossFrequency", typeof(double));
      dt.Columns.Add("Significance", typeof(double));

      dt.BeginLoadData();

      foreach (var x in tmp)
      {
        foreach (var y in x.Value)
        {
          dt.Rows.Add(
            x.Key,
            y.Key,
            frequ.ContainsKey(x.Key) && frequ[x.Key].ContainsKey(y.Key) ? frequ[x.Key][y.Key] : -1,
            y.Value);
        }
      }

      dt.EndLoadData();


      output.Set(selection, Method, "", dt);
    }

    public int Top { get; set; }
  }
}