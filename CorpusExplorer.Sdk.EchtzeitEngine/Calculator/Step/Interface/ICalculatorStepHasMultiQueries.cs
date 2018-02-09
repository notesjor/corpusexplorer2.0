using System.Collections.Generic;

namespace CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step.Interface
{
  public interface ICalculatorStepHasMultiQueries
  {
    IEnumerable<string> Queries { get; set; }
  }
}