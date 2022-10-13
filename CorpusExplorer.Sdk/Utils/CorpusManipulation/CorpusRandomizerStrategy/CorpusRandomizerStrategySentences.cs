using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Utils.CorpusManipulation.CorpusRandomizerStrategy.Abstract;

namespace CorpusExplorer.Sdk.Utils.CorpusManipulation.CorpusRandomizerStrategy
{
  public class CorpusRandomizerStrategySentences : AbstractCorpusRandomizerStrategy
  {
    protected override string[][] RandomizeDocument(IEnumerable<IEnumerable<string>> doc)
    {
      var tmp = doc.ToList();
      var res = new List<IEnumerable<string>>();

      while(tmp.Count > 0)
      {
        var idx = Configuration.Random.Next(0, tmp.Count);
        
        res.Add(tmp[idx]);
        tmp.RemoveAt(idx);
      }

      return res.Select(x=>x.ToArray()).ToArray();
    }
  }
}
