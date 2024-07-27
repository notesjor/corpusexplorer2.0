using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Extern.Plaintext.RelAnnis.NodeProcessor.Abstract
{
  public abstract class AbstractRelAnnisTokenValidator
  {
    public abstract bool IsInvalid(string[] split);
  }
}
