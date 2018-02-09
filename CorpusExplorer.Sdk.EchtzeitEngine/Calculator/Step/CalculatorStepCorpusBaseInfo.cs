using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step.Abstract;
using CorpusExplorer.Sdk.EchtzeitEngine.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step
{
  public class CalculatorStepCorpusBaseInfo : AbstractCalculatorStep
  {
    public override string Method => "CorpusBaseInfo";

    public override void Calculate(Selection selection, ref UniversalStorage output)
    {
      var dt = new DataTable();
      dt.Columns.Add("Metric", typeof(string));
      dt.Columns.Add("Value", typeof(double));
      dt.BeginLoadData();
      
      dt.Rows.Add("Token", (double) selection.CountToken);
      dt.Rows.Add("Factor", 1000000.0 / selection.CountToken);
      dt.Rows.Add("Sentences", (double)selection.CountSentences);
      dt.Rows.Add("Documents", (double)selection.CountDocuments);

      dt.EndLoadData();
      output.Set(selection, Method, "", dt);
    }
  }
}
