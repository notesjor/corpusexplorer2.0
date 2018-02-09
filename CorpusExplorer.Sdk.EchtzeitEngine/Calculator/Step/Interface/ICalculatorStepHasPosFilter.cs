using System.Collections.Generic;

namespace CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step.Interface
{
  public interface ICalculatorStepHasPosFilter
  {
    IEnumerable<string> PosTags { get; set; }
  }
}