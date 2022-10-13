using System.Linq;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.CorpusManipulation.CorpusRandomizerStrategy.Abstract;

namespace CorpusExplorer.Sdk.Utils.CorpusManipulation
{
  public static class CorpusRandomizer
  {
    public static AbstractCorpusAdapter Randomize(
      AbstractCorpusAdapter corpus, 
      AbstractCorpusRandomizerStrategy strategy)
    {
      strategy.Input(corpus);
      strategy.Execute();
      return strategy.Output.First();
    }
  }
}
