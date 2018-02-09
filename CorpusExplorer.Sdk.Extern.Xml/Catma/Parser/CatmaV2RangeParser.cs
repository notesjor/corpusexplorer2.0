using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.Xml.Catma.Parser.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.Catma.Parser
{
  public class CatmaV2RangeParser : AbstractCatmaRangeParser
  {
    public override Tuple<string, int, int> Parse(string target)
    {
      if (string.IsNullOrEmpty(target))
        return null;

      var ix = target.IndexOf("#", StringComparison.CurrentCulture);
      if (ix == -1)
        return null;

      var fn = target.Substring(0, ix);
      var rg = target.Substring(ix + 1).Replace("range", string.Empty).Split(new[] { "(", " ", "/", ".", ",", ")" }, StringSplitOptions.RemoveEmptyEntries);
      return rg.Length != 2 ? null : new Tuple<string, int, int>(fn, int.Parse(rg[0]), int.Parse(rg[1]));
    }
  }
}
