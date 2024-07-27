using CorpusExplorer.Sdk.Extern.Plaintext.RelAnnis.NodeProcessor.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Extern.Plaintext.RelAnnis.NodeProcessor
{
  public class RelAnnisTokenValidatorAlternative : AbstractRelAnnisTokenValidator
  {
    public override bool IsInvalid(string[] split)
    {
      var tid = split[7];
      var tlf = int.Parse(split[8]);
      var tri = int.Parse(split[9]);

      return tlf != tri || tid != "NULL";
    }
  }
}
