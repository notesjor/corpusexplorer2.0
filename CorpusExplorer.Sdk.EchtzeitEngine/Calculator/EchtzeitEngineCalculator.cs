using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Diagnostic;
using CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step.Abstract;
using CorpusExplorer.Sdk.EchtzeitEngine.Model;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.EchtzeitEngine.Calculator
{
  public static class EchtzeitEngineCalculator
  {
    public static UniversalStorage Calculate(Selection selection, IEnumerable<AbstractCalculatorStep> steps)
    {
      var res = new UniversalStorage();

      Parallel.ForEach(
        steps,
        Configuration.ParallelOptions,
        step =>
        {
          try
          {
            step.Calculate(selection, ref res);
          }
          catch (Exception ex)
          {
            InMemoryErrorConsole.Log(ex);
          }
        });

      return res;
    }
  }
}