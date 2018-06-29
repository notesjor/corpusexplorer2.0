using System.Collections.Generic;
using CorpusExplorer.Sdk.EchtzeitEngine.Calculator;
using CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step.Abstract;
using CorpusExplorer.Sdk.EchtzeitEngine.Model;
using CorpusExplorer.Sdk.ViewModel.Abstract;

namespace CorpusExplorer.Sdk.EchtzeitEngine.ViewModel
{
  public class EchtzeitEngineViewModel : AbstractViewModel
  {
    public List<AbstractCalculatorStep> CalculatorSteps { get; set; } = new List<AbstractCalculatorStep>();

    public UniversalStorage ResultStorage { get; set; }

    protected override void ExecuteAnalyse()
    {
      ResultStorage = EchtzeitEngineCalculator.Calculate(Selection, CalculatorSteps);
    }

    protected override bool Validate()
    {
      return CalculatorSteps != null;
    }
  }
}