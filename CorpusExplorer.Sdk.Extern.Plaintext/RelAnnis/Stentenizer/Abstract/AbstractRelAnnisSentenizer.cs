using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Extern.Plaintext.RelAnnis.Stentenizer.Abstract
{
  public abstract class AbstractRelAnnisSentenizer
  {
    public abstract Dictionary<int, List<KeyValuePair<int, int>>> GetSentences(string path);
  }
}
