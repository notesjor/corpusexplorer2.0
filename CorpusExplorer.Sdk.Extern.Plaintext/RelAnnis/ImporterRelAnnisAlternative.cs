using CorpusExplorer.Sdk.Extern.Plaintext.RelAnnis.NodeProcessor;
using CorpusExplorer.Sdk.Extern.Plaintext.RelAnnis.Stentenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Extern.Plaintext.RelAnnis
{
  public class ImporterRelAnnisAlternative : ImporterRelAnnis
  {
    public ImporterRelAnnisAlternative()
    {
      Sentenizer = new RelAnnisStentenizerSimpleAlternative();
      TokenValidator = new RelAnnisTokenValidatorAlternative();
    }
  }
}
