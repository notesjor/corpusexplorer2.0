using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.CorpusManipulation.CorpusRandomizerStrategy.Abstract;

namespace CorpusExplorer.Sdk.Utils.CorpusManipulation.CorpusRandomizerStrategy
{
  public class CorpusRandomizerStrategyTokens : AbstractCorpusRandomizerStrategy
  {
    protected override string[][] RandomizeDocument(IEnumerable<IEnumerable<string>> doc)
    {
      return doc.AsParallel().Select(x => Randomize(x)).ToArray();
    }

    private string[] Randomize(IEnumerable<string> x)
    {
      var tmp = x.ToList();
      var res = new List<string>();

      while (tmp.Count > 0)
      {
        var idx = Configuration.Random.Next(0, tmp.Count);
        res.Add(tmp[idx]);
        tmp.RemoveAt(idx);
      }

      return res.ToArray();
    }
  }
}