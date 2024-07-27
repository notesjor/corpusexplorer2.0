using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.CorpusManipulation.CorpusRandomizerStrategy.Abstract;

namespace CorpusExplorer.Sdk.Utils.CorpusManipulation.CorpusRandomizerStrategy
{
  public class CorpusRandomizerStrategySort : AbstractCorpusRandomizerStrategy
  {
    protected override string[][] RandomizeDocument(IEnumerable<IEnumerable<string>> doc)
    {
      return doc.AsParallel().Select(x => x.OrderBy(y => y).ToArray()).ToArray();
    }
  }
}