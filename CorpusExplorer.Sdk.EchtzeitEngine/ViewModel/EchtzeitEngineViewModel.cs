using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.EchtzeitEngine.Calculator;
using CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step.Abstract;
using CorpusExplorer.Sdk.EchtzeitEngine.Model;
using CorpusExplorer.Sdk.ViewModel.Abstract;

namespace CorpusExplorer.Sdk.EchtzeitEngine.ViewModel
{
  public class EchtzeitEngineViewModel : AbstractViewModel
  {
    protected override void ExecuteAnalyse()
    {
      ResultStorage = EchtzeitEngineCalculator.Calculate(Selection, CalculatorSteps);
    }

    public UniversalStorage ResultStorage { get; set; }
    public List<AbstractCalculatorStep> CalculatorSteps { get; set; } = new List<AbstractCalculatorStep>();

    protected override bool Validate() => CalculatorSteps != null;
  }
}
