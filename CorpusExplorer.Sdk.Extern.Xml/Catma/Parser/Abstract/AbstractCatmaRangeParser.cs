using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Extern.Xml.Catma.Parser.Abstract
{
  public abstract class AbstractCatmaRangeParser
  {
    public abstract Tuple<string, int, int> Parse(string target);
  }
}
