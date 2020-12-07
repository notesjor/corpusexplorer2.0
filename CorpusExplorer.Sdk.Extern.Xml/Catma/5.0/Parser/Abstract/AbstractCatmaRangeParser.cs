using System;

namespace CorpusExplorer.Sdk.Extern.Xml.Catma._5._0.Parser.Abstract
{
  public abstract class AbstractCatmaRangeParser
  {
    public abstract Tuple<string, int, int> Parse(string target);
  }
}