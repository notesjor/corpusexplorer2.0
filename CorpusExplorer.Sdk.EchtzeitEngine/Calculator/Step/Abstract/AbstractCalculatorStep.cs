using CorpusExplorer.Sdk.EchtzeitEngine.Model;
using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.EchtzeitEngine.Calculator.Step.Abstract
{
  public abstract class AbstractCalculatorStep
  {
    public abstract string Method { get; }
    public abstract void Calculate(Selection selection, ref UniversalStorage output);
  }
}