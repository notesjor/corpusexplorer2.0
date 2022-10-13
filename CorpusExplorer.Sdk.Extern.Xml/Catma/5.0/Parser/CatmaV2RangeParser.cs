using System;
using CorpusExplorer.Sdk.Extern.Xml.Catma._5._0.Parser.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.Catma._5._0.Parser
{
  public class CatmaV2RangeParser : AbstractCatmaRangeParser
  {
    private static char[] _separator = {'(', ' ', '/', '.', ',', ')'};

    public override Tuple<string, int, int> Parse(string target)
    {
      if (string.IsNullOrEmpty(target))
        return null;

      var ix = target.IndexOf("#", StringComparison.CurrentCulture);
      if (ix == -1)
        return null;

      var fn = target.Substring(0, ix);
      var rg = target.Substring(ix + 1).Replace("range", string.Empty).Split(_separator,
        StringSplitOptions.RemoveEmptyEntries);
      return rg.Length != 2 ? null : new Tuple<string, int, int>(fn, int.Parse(rg[0]), int.Parse(rg[1]));
    }
  }
}