﻿using System;
using CorpusExplorer.Sdk.Extern.Xml.Catma._5._0.Parser.Abstract;
using CorpusExplorer.Sdk.Helper;

namespace CorpusExplorer.Sdk.Extern.Xml.Catma._5._0.Parser
{
  public class CatmaV3RangeParser : AbstractCatmaRangeParser
  {
    public override Tuple<string, int, int> Parse(string target)
    {
      if (string.IsNullOrEmpty(target))
        return null;

      target = target.Replace("catma:///", string.Empty);

      var ix = target.IndexOf("#", StringComparison.CurrentCulture);
      if (ix == -1)
        return null;

      var fn = target.Substring(0, ix);
      var rg = target.Substring(ix + 1).Replace("char=", string.Empty)
        .Split(Splitter.Comma, StringSplitOptions.RemoveEmptyEntries);
      return rg.Length != 2 ? null : new Tuple<string, int, int>(fn, int.Parse(rg[0]), int.Parse(rg[1]));
    }
  }
}