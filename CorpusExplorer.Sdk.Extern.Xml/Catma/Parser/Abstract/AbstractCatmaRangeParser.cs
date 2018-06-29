using System;

namespace CorpusExplorer.Sdk.Extern.Xml.Catma.Parser.Abstract
{
  public abstract class AbstractCatmaRangeParser
  {
    public abstract Tuple<string, int, int> Parse(string target);
  }
}