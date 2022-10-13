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
      var res = doc.ToList();
      for (var i = 0; i < res.Count; i++)
      {
        var input = res[i].ToList();
        var output = new List<string>();

        while(input.Count > 0)
        {
          var idx = Configuration.Random.Next(0, input.Count);
        
          output.Add(input[idx]);
          input.RemoveAt(idx);
        }

        res[i] = output;
      }

      return res.Select(x=>x.ToArray()).ToArray();
    }
  }
}